

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
    public class SaboresController : Controller
    {
        private readonly ISaborRepository saborRepository;

        public SaboresController(ISaborRepository saborRepository)
        {
            this.saborRepository = saborRepository;
        }

        // GET: Saboresontroller
        public IActionResult Index()
        {
            return View(this.saborRepository.GetAll());
        }

        // GET: Saboresontroller/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sabor = await this.saborRepository.GetByIdAsync(id.Value);
            if (sabor == null)
            {
                return NotFound();
            }

            return View(sabor);
        }

        // GET: Saboresontroller/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sabor sabor)
        {
            if (ModelState.IsValid)
            {
                await this.saborRepository.CreateAsync(sabor);
                return RedirectToAction(nameof(Index));
            }
            return View(sabor);
        }

        // GET: Saboresontroller/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sabor = await this.saborRepository.GetByIdAsync(id.Value);
            if (sabor == null)
            {
                return NotFound();
            }
            return View(sabor);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Sabor sabor)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    await this.saborRepository.UpdateAsync(sabor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.saborRepository.ExistAsync(sabor.Id))
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
            return View(sabor);
        }

        // GET: Saboresontroller/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sabor = await this.saborRepository.GetByIdAsync(id.Value);
            if (sabor == null)
            {
                return NotFound();
            }

            return View(sabor);
        }

        // POST: Saboresontroller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sabor = await this.saborRepository.GetByIdAsync(id);
            await this.saborRepository.DeleteAsync(sabor);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
