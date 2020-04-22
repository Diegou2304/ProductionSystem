

namespace ProductionSystem.Web.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.CodeAnalysis.Operations;
    using Microsoft.EntityFrameworkCore;
    using ProductionSystem.Web.Data;
    using ProductionSystem.Web.Data.Entities;
    using ProductionSystem.Web.Data.Repositories.Interfaz;
    using Remotion.Linq.Clauses.ResultOperators;


    public class InsumosController : Controller
    {

        private readonly IInsumoRepository insumoRepository;

        public InsumosController(IInsumoRepository insumoRepository)
        {
            this.insumoRepository = insumoRepository;
        }


        // GET: Insumos
        public IActionResult Index()
        {

            return View(this.insumoRepository.GetAll());
        }

        // GET: Insumos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumo = await this.insumoRepository.GetByIdAsync(id.Value);
            if (insumo == null)
            {
                return NotFound();
            }

            return View(insumo);
        }

        // GET: Insumos/Create
        public IActionResult Create()
        {
            return View();
        }

        //cambia aqui
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                await this.insumoRepository.CreateAsync(insumo);
                return RedirectToAction(nameof(Index));
            }
            return View(insumo);
        }

        // GET: Insumos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumo = await this.insumoRepository.GetByIdAsync(id.Value);
            if (insumo == null)
            {
                return NotFound();
            }
            return View(insumo);
        }

        // POST: Insumos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Insumo insumo)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await this.insumoRepository.UpdateAsync(insumo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.insumoRepository.ExistAsync(insumo.Id))
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
            return View(insumo);
        }

        // GET: Insumos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumo = await this.insumoRepository.GetByIdAsync(id.Value);

            if (insumo == null)
            {
                return NotFound();
            }

            return View(insumo);
        }

        // POST: Insumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insumo = await this.insumoRepository.GetByIdAsync(id);
            await this.insumoRepository.DeleteAsync(insumo);
            return RedirectToAction(nameof(Index));
        }

    }
}
