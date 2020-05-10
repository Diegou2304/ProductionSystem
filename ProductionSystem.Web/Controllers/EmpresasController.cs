

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

    public class EmpresasController : Controller
    {
        private readonly IEmpresaRepository empresaRepository;

        public EmpresasController(IEmpresaRepository empresaRepository)
        {
            this.empresaRepository = empresaRepository;
        }

        // GET: Empresas
        public IActionResult Index()
        {
            return View(this.empresaRepository.GetAll());
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await this.empresaRepository.GetByIdAsync(id.Value);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                await this.empresaRepository.CreateAsync(empresa);
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await this.empresaRepository.GetByIdAsync(id.Value);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Empresa empresa)
        {
            
            if (ModelState.IsValid)
            {
                try
                {               
                    await this.empresaRepository.UpdateAsync(empresa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.empresaRepository.ExistAsync(empresa.Id))
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
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await this.empresaRepository.GetByIdAsync(id.Value);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await this.empresaRepository.GetByIdAsync(id);
            await this.empresaRepository.DeleteAsync(empresa);
            return RedirectToAction(nameof(Index));
        }

    }
}
