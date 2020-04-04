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
    public class EnvasesController : Controller
    {
        private readonly DataContext _context;

        public EnvasesController(DataContext context)
        {
            _context = context;
        }

        // GET: Envases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Envases.ToListAsync());
        }

        // GET: Envases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var envase = await _context.Envases
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,Capacidad,Isplastic")] Envase envase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(envase);
                await _context.SaveChangesAsync();
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

            var envase = await _context.Envases.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Capacidad,Isplastic")] Envase envase)
        {
            if (id != envase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(envase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnvaseExists(envase.Id))
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

            var envase = await _context.Envases
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var envase = await _context.Envases.FindAsync(id);
            _context.Envases.Remove(envase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnvaseExists(int id)
        {
            return _context.Envases.Any(e => e.Id == id);
        }
    }
}
