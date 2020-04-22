

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

    [Authorize]
    public class EnvasesController : Controller
    {
        private readonly IEnvaseRepository envaseRepository;

        public EnvasesController(IEnvaseRepository envaseRepository)
        {
            this.envaseRepository = envaseRepository;
        }

        // GET: Envases
        public IActionResult Index()
        {
            return View(this.envaseRepository.GetAll());
        }

        // GET: Envases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var envase = await this.envaseRepository.GetByIdAsync(id.Value);
            if (envase == null)
            {
                return NotFound();
            }

            return View(envase);
        }

        // GET: Envases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Envases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Envase envase)
        {
            if (ModelState.IsValid)
            {           
                await this.envaseRepository.CreateAsync(envase);
                return RedirectToAction(nameof(Index));
            }
            return View(envase);
        }

        // GET: Envases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var envase = await this.envaseRepository.GetByIdAsync(id.Value);
            if (envase == null)
            {
                return NotFound();
            }
            return View(envase);
        }

        // POST: Envases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Envase envase)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await this.envaseRepository.UpdateAsync(envase);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.envaseRepository.ExistAsync(envase.Id))
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
            return View(envase);
        }

        // GET: Envases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var envase = await this.envaseRepository.GetByIdAsync(id.Value);
            if (envase == null)
            {
                return NotFound();
            }

            return View(envase);
        }

        // POST: Envases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var envase = await this.envaseRepository.GetByIdAsync(id);
            await this.envaseRepository.DeleteAsync(envase);
            return RedirectToAction(nameof(Index));
        }       
    }
}
