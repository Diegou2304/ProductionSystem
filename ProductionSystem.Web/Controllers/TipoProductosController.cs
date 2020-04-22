

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

    public class TipoProductosController : Controller
    {
        private readonly ITipoProductoRepository tipoProductoRepository;

        public TipoProductosController(ITipoProductoRepository tipoProductoRepository)
        {
            this.tipoProductoRepository = tipoProductoRepository;
        }

        // GET: TipoProductos
        public IActionResult Index()
        {
            return View(this.tipoProductoRepository.GetAll());
        }

        // GET: TipoProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProducto = await this.tipoProductoRepository.GetByIdAsync(id.Value);
            if (tipoProducto == null)
            {
                return NotFound();
            }

            return View(tipoProducto);
        }

        // GET: TipoProductos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoProductos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoProducto tipoProducto)
        {
            if (ModelState.IsValid)
            {
                await this.tipoProductoRepository.CreateAsync(tipoProducto);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProducto);
        }

        // GET: TipoProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProducto = await this.tipoProductoRepository.GetByIdAsync(id.Value);
            if (tipoProducto == null)
            {
                return NotFound();
            }
            return View(tipoProducto);
        }

        // POST: TipoProductos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TipoProducto tipoProducto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.tipoProductoRepository.UpdateAsync(tipoProducto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.tipoProductoRepository.ExistAsync(tipoProducto.Id))
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
            return View(tipoProducto);
        }

        // GET: TipoProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProducto = await this.tipoProductoRepository.GetByIdAsync(id.Value);
            if (tipoProducto == null)
            {
                return NotFound();
            }

            return View(tipoProducto);
        }

        // POST: TipoProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoProducto = await this.tipoProductoRepository.GetByIdAsync(id);
            await this.tipoProductoRepository.DeleteAsync(tipoProducto);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
