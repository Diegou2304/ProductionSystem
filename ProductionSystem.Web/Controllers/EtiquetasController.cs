

namespace ProductionSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using ProductionSystem.Web.Data;
    using ProductionSystem.Web.Data.Entities;
    using ProductionSystem.Web.Data.Repositories.Interfaz;

    //[Authorize]
    public class EtiquetasController : Controller
    {
        private readonly IEtiquetaRepository etiquetaRepository;

        public EtiquetasController(IEtiquetaRepository etiquetaRepository)
        {
            this.etiquetaRepository = etiquetaRepository;
        }

        // GET: Etiquetas
        public IActionResult Index()
        {
            return View(this.etiquetaRepository.GetAll());
        }

        // GET: Etiquetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etiqueta = await this.etiquetaRepository.GetByIdAsync(id.Value);
            if (etiqueta == null)
            {
                return NotFound();
            }

            return View(etiqueta);
        }

        // GET: Etiquetas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etiquetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                await this.etiquetaRepository.CreateAsync(etiqueta);
                return RedirectToAction(nameof(Index));
            }
            return View(etiqueta);
        }

        // GET: Etiquetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etiqueta = await this.etiquetaRepository.GetByIdAsync(id.Value);
            if (etiqueta == null)
            {
                return NotFound();
            }
            return View(etiqueta);
        }

        // POST: Etiquetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Etiqueta etiqueta)
        {

            if (ModelState.IsValid)
            {
                try
                {  
                    await this.etiquetaRepository.UpdateAsync(etiqueta);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.etiquetaRepository.ExistAsync(etiqueta.Id))
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
            return View(etiqueta);
        }

        // GET: Etiquetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etiqueta = await this.etiquetaRepository.GetByIdAsync(id.Value);
            if (etiqueta == null)
            {
                return NotFound();
            }

            return View(etiqueta);
        }

        // POST: Etiquetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etiqueta = await this.etiquetaRepository.GetByIdAsync(id);
            await this.etiquetaRepository.DeleteAsync(etiqueta);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
