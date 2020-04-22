

namespace ProductionSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ProductionSystem.Web.Data;
    using ProductionSystem.Web.Helpers;
    using ProductionSystem.Web.Models;

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


        public IActionResult Error ()
        { 
           

            return View();
        }

        //TODO : Tenemos que validad que las etiquetas no lleguen al combo si es que estan usadas
        [HttpPost]
        public async Task<IActionResult> Create(AddPresentacionViewModel model)
        {

            //Aqui igual tenemos que hacer lo corresopndiente
            if(_validatorHelper.IsEtiquetaUsed(model.EtiquetaId))
            {
                return RedirectToAction("Error");
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

            var presentacion = _dataContext.Presentaciones
                .Include(p => p.Envase)
                .Include(et => et.Etiqueta)
                .FirstOrDefault(pre => pre.Id == id);

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
            if(_validatorHelper.IsEtiquetaUsed(model.EtiquetaId))
            {
                //Aqui tiene que venir una ventana de error.
                return RedirectToAction("Error");
            }
            
       
            
            if (ModelState.IsValid)
            {
                //El id de la presentacion tiene que ser igual al id de la etiqueta por la relacion 1-1
                var presentacion = await _converterHelper.ToPresentacionAsync(model);

                var etiqueta = _dataContext.Etiquetas.FirstOrDefault(et => et.Id == model.FormerEtiquetaId);

                
                

                _dataContext.Presentaciones.Update(presentacion);
                await _dataContext.SaveChangesAsync();

                etiqueta.IsUsed = false;

                _dataContext.Etiquetas.Update(etiqueta);


                etiqueta = _dataContext.Etiquetas.FirstOrDefault(et => et.Id == model.EtiquetaId);
                etiqueta.IsUsed = true ;


                _dataContext.Etiquetas.Update(etiqueta);



                await _dataContext.SaveChangesAsync();


                //Dtalles del propietario
                return RedirectToAction("Index");

            }

            return View(model);
        }









    }
}