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

        public PresentacionesController(
            DataContext dataContext,
            ICombosHelper comboHelper,
            IConverterHelper converterHelper)
        {
            _dataContext = dataContext;

            _combosHelper = comboHelper;
            _converterHelper = converterHelper;
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

            if(ModelState.IsValid)
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









    }
}