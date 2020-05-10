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
using ProductionSystem.Web.Helpers;
using ProductionSystem.Web.Models;

namespace ProductionSystem.Web.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        private readonly IProductoRepository _productoRepository;
        private readonly ICombosHelper _combosHelper;
        private readonly DataContext _context;

        private readonly IConverterHelper _converterHelper;
        public ProductosController(
            DataContext dataContext,
            IProductoRepository productoRepository,
            ICombosHelper combosHelper,
            IConverterHelper converterHelper
            )

        {
            _context = dataContext;
            _productoRepository = productoRepository;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
        }

        // GET: Productoes
        public IActionResult Index()
        {
            return View(_productoRepository.GetProductosCompletos());
        }

        // GET: Productoes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _productoRepository.GetProductosCompletos(id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            var model = new ProductoViewModel
            {
                Categorias = _combosHelper.GetComboCategorias(),
                TiposProductos = _combosHelper.GetComboTipoProducto(),
                Sabores = _combosHelper.GetComboSabores(),
                Presentaciones = _combosHelper.GetComboPresentaciones()
                


            };
            return View(model);
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var producto = await _converterHelper.ToProductoAsync(model);

                await _productoRepository.CreateAsync(producto);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto =  _productoRepository.GetProductosCompletos(id);
            if (producto == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToProductoViewModel(producto);
            return View(model);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductoViewModel model)
        {
           

            if (ModelState.IsValid)
            {
                var producto = await  _converterHelper.ToProductoAsync(model);
              

                await  _productoRepository.UpdateAsync(producto);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _productoRepository.GetProductosCompletos(id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var producto = _productoRepository.GetProductosCompletos(id);

            await _productoRepository.DeleteAsync(producto);

            return RedirectToAction(nameof(Index));

        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
