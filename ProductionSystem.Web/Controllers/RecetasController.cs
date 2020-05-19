using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductionSystem.Web.Data;
using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Data.Repositories.Interfaz;
using ProductionSystem.Web.Helpers;
using ProductionSystem.Web.Models;

namespace ProductionSystem.Web.Controllers
{
    public class RecetasController : Controller
    {
        //data context no deberia estar aqui
        private readonly DataContext _context;
        private readonly IRecetaRepository _recetaRepository;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public RecetasController(DataContext context,
            IRecetaRepository recetaRepository,
            ICombosHelper combosHelper,
            IConverterHelper converterHelper)
        {
            _context = context;
            _recetaRepository = recetaRepository;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
        }

        // GET: Recetas
        public IActionResult Index()
        {
            return View(_recetaRepository.GetRecetas());
        }

        // GET: Recetas/Details/5
        //TODO: sacar el context e implementar el repositorio en esta funcion
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _context.Recetas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receta == null)
            {
                return NotFound();
            }

            return View(receta);
        }

        // GET: Recetas/Create
        public IActionResult Create()
        {

            var model = new RecetaViewModel
            {
                Insumos = _combosHelper.GetComboInsumo(),

                ProductosReales = _combosHelper.GetComboProductosReales(),  

            };

            return View(model);
        }

        // POST: Recetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecetaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var receta = await _converterHelper.ToRecetaAsync(model);

                await _recetaRepository.CreateAsync(receta);
               
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Recetas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = _recetaRepository.GetRecetas(id);
            if (receta == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToRecetaViewModel(receta);
            return View(model);
        }

        // POST: Recetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RecetaViewModel model)
        {
           

            if (ModelState.IsValid)
            {
                //El id de la presentacion tiene que ser igual al id de la etiqueta por la relacion 1-1
                var receta = await _converterHelper.ToRecetaAsync(model);

                await _recetaRepository.UpdateAsync(receta);


                //Dtalles del propietario
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Recetas/Delete/5
        //TODO: sacar el context de aqui tambien
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _context.Recetas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receta == null)
            {
                return NotFound();
            }

            return View(receta);
        }

        // POST: Recetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receta = await _context.Recetas.FindAsync(id);
            _context.Recetas.Remove(receta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecetaExists(int id)
        {
            return _context.Recetas.Any(e => e.Id == id);
        }
    }
}
