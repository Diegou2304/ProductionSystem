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
    public class InventarioEmpresasController : Controller
    {
        private readonly DataContext _context;

        public InventarioEmpresasController(DataContext context)
        {
            _context = context;
        }

        // GET: InventarioEmpresas
        public async Task<IActionResult> Index()
        {
            return View(_context.InventarioEmpresas.Include(e => e.Empresa).Include(em => em.ProductoReal).ToList());
        }

        // GET: InventarioEmpresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioEmpresa = await _context.InventarioEmpresas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventarioEmpresa == null)
            {
                return NotFound();
            }

            return View(inventarioEmpresa);
        }

        // GET: InventarioEmpresas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventarioEmpresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Stock")] InventarioEmpresa inventarioEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventarioEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventarioEmpresa);
        }

        // GET: InventarioEmpresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioEmpresa = await _context.InventarioEmpresas.FindAsync(id);
            if (inventarioEmpresa == null)
            {
                return NotFound();
            }
            return View(inventarioEmpresa);
        }

        // POST: InventarioEmpresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Stock")] InventarioEmpresa inventarioEmpresa)
        {
            if (id != inventarioEmpresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarioEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioEmpresaExists(inventarioEmpresa.Id))
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
            return View(inventarioEmpresa);
        }

        // GET: InventarioEmpresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioEmpresa = await _context.InventarioEmpresas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventarioEmpresa == null)
            {
                return NotFound();
            }

            return View(inventarioEmpresa);
        }

        // POST: InventarioEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventarioEmpresa = await _context.InventarioEmpresas.FindAsync(id);
            _context.InventarioEmpresas.Remove(inventarioEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioEmpresaExists(int id)
        {
            return _context.InventarioEmpresas.Any(e => e.Id == id);
        }
    }
}
