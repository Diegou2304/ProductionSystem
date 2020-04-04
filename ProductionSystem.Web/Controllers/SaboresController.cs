using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductionSystem.Web.Data;
using ProductionSystem.Web.Data.Entities;

namespace ProductionSystem.Web.Controllers
{
    public class SaboresController : Controller
    {
        private readonly DataContext _context;

        public SaboresController(DataContext context)
        {
            _context = context;
        }

        // GET: Saboresontroller
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sabores.ToListAsync());
        }

        // GET: Saboresontroller/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sabor = await _context.Sabores
                .FirstOrDefaultAsync(m => m.Id == id);
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

        // POST: Saboresontroller/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Sabor sabor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sabor);
                await _context.SaveChangesAsync();
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

            var sabor = await _context.Sabores.FindAsync(id);
            if (sabor == null)
            {
                return NotFound();
            }
            return View(sabor);
        }

        // POST: Saboresontroller/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Sabor sabor)
        {
            if (id != sabor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sabor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaborExists(sabor.Id))
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

            var sabor = await _context.Sabores
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var sabor = await _context.Sabores.FindAsync(id);
            _context.Sabores.Remove(sabor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaborExists(int id)
        {
            return _context.Sabores.Any(e => e.Id == id);
        }
    }
}
