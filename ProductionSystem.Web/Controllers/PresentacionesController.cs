using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductionSystem.Web.Data;
using ProductionSystem.Web.Helpers;
using ProductionSystem.Web.Models;

namespace ProductionSystem.Web.Controllers
{
    public class PresentacionesController : Controller
    {
        private readonly DataContext _dataContext;

        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IValidatorHelper _validatorHelper;

        public PresentacionesController(
            DataContext dataContext,
            ICombosHelper comboHelper,
            IConverterHelper converterHelper,
            IValidatorHelper validatorHelper)
        {
            _dataContext = dataContext;

            _combosHelper = comboHelper;
            _converterHelper = converterHelper;
            _validatorHelper = validatorHelper;
        }

        public IActionResult Index()
        {
            return View(_dataContext.Presentaciones
                .Include(p => p.Etiqueta)
                .Include (p => p.Envase));
        }


        public  async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {

                return NotFound();

            }

            var presentacion =  _dataContext.Presentaciones
                .Include(e => e.Envase)
                .Include(et => et.Etiqueta)
                .FirstOrDefault(p => p.Id == id);

            if (presentacion == null)
            {
                return NotFound();
            }

            return View(presentacion);
        
        
        
        }


        public IActionResult Create ()
        {

            //Aqui necesitamos enviar los combo box respectiivos

            var model = new AddPresentacionViewModel
            {

                Envases = _combosHelper.GetComboEnvases(),
                Etiquetas = _combosHelper.GetComboEtiqueta()


            };

            return View(model);
        }

        //TODO : Tenemos que validad que las etiquetas no lleguen al combo si es que estan usadas
        [HttpPost]
        public async Task<IActionResult> Create(AddPresentacionViewModel model)
        {

            //Aqui igual tenemos que hacer lo corresopndiente
            if(_validatorHelper.IsEtiquetaUsed(model.EtiquetaId))
            {
                  return RedirectToAction("Index");
            }
          
            if (ModelState.IsValid)
            {
               
                var etiqueta = await _dataContext.Etiquetas.FindAsync(model.EtiquetaId);
                var presentacion = await _converterHelper.ToPresentacionAsync(model);


                _dataContext.Presentaciones.Add(presentacion);
                await _dataContext.SaveChangesAsync();

                //Solo depsues que se haya guardado los datos, tenemos que insertar la etiqueta

                etiqueta.IsUsed = true;

                _dataContext.Etiquetas.Update(etiqueta);
                await _dataContext.SaveChangesAsync();

                return RedirectToAction("Index");
               

            }

            return View(model);


           
        }

        //Cuando eliminamos una presentacion debemos cambiar el estado de esta etiqueta a disponible.
        //La pantalla de edit tambien
        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _dataContext.Presentaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presentacion == null)
            {
                return NotFound();
            }

            return View(presentacion);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presentacion = await _dataContext.Presentaciones
                .Include(e => e.Etiqueta)
                .FirstAsync(m => m.Id == id);
                

            var etiqueta = await _dataContext.Etiquetas.FindAsync(presentacion.Etiqueta.Id);

            _dataContext.Presentaciones.Remove(presentacion);

            await _dataContext.SaveChangesAsync();

            etiqueta.IsUsed = false;

            _dataContext.Etiquetas.Update(etiqueta);

            await _dataContext.SaveChangesAsync();


            return RedirectToAction(nameof(Index));



        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = _dataContext.Presentaciones
                .Include(p => p.Envase)
                .Include(et => et.Etiqueta)
                .FirstOrDefault(pre => pre.Id == id);

            if (presentacion == null)
            {
                return NotFound();
            }

            
           var model = _converterHelper.ToPresentacionViewModelAsync(presentacion);

           
          

            return View(model);
        }
        
        //Hay un problema, tenemos que validar que el estado de una etiqueta no sea true, asi no cambiamos
        //No podemos validar que el atributo tenga solamente un metodo, debemos crear una clase o algo que nos ayude a verificar,
        //Pero tiene que aparecer en el model.
        [HttpPost]
        public async Task<IActionResult> Edit(AddPresentacionViewModel model)
        {
           

            //No me esta llegando bien los datos que escojo en el view
            //Aqui tendremos que hacer la validacion respectiva.
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");

            }

            return View(model);
        }









    }
}