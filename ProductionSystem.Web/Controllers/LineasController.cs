

namespace ProductionSystem.Web.Controllers
{
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
    using ProductionSystem.Web.Models;

    public class LineasController : Controller
    {
        private readonly ILineaRepository lineaRepository;

        public LineasController(ILineaRepository lineaRepository)
        {
            this.lineaRepository = lineaRepository;
        }


        public async Task<IActionResult> EditCategoria(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await this.lineaRepository.GetCategoriaAsync(id.Value);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategoria(Categoria categoria)
        {
            if (this.ModelState.IsValid)
            {
                var lineaId = await this.lineaRepository.UpdateCategoriaAsync(categoria);
                if (lineaId != 0)
                {
                    //TODO: revisar por que esta cosa me da error
                    return this.RedirectToAction("Index");
                }
            }

            return this.View(categoria);
        }

        public async Task<IActionResult> AddCategoria(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linea = await this.lineaRepository.GetByIdAsync(id.Value);
            if (linea == null)
            {
                return NotFound();
            }

            var model = new CategoriaViewModel { PoseedorId = linea.Id };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoria(CategoriaViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.lineaRepository.AddCategoriaAsync(model);
                //TODO: revisar por que esta cosa me da error
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }


        public async Task<IActionResult> DeleteCategoria(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await this.lineaRepository.GetCategoriaAsync(id.Value);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        
        [HttpPost, ActionName("DeleteCategoria")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedCategoria(int id)
        {
            var categoria = await this.lineaRepository.GetCategoriaAsync(id);
            await this.lineaRepository.DeleteCategoriaAsync(categoria);
            return RedirectToAction(nameof(Index));
        }





        // GET: Lineas
        public IActionResult Index()
        {
            return View(this.lineaRepository.GetLineasConCategorias());
        }

        // GET: Lineas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linea = await this.lineaRepository.GetLineaConCategoriaAsync(id.Value);
            if (linea == null)
            {
                return NotFound();
            }

            return View(linea);
        }

        // GET: Lineas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lineas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Linea linea)
        {
            if (ModelState.IsValid)
            {
                await this.lineaRepository.CreateAsync(linea);
                return RedirectToAction(nameof(Index));
            }
            return View(linea);
        }

        // GET: Lineas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linea = await this.lineaRepository.GetByIdAsync(id.Value);
            if (linea == null)
            {
                return NotFound();
            }
            return View(linea);
        }

        // POST: Lineas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Linea linea)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await this.lineaRepository.UpdateAsync(linea);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.lineaRepository.ExistAsync(linea.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(linea);
        }

        // GET: Lineas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linea = await this.lineaRepository.GetByIdAsync(id.Value);
            if (linea == null)
            {
                return NotFound();
            }

            return View(linea);
        }

        // POST: Lineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var linea = await this.lineaRepository.GetByIdAsync(id);
            await this.lineaRepository.DeleteAsync(linea);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
