using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductionSystem.Web.Data;
using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Data.Repositories.Interfaz;
using ProductionSystem.Web.Helpers;
using ProductionSystem.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Controllers
{
    public class ProductosRealesController : Controller
    {
        private readonly DataContext _context;
        private readonly IProductoRealRepository _productoRealRepository;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public ProductosRealesController(
            DataContext context,
            IProductoRealRepository productoRealRepository,
            ICombosHelper combosHelper,
            IConverterHelper converterHelper
          )
        {
            _context = context;
            _productoRealRepository = productoRealRepository;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;

        }

        // GET: ProductosReales
        public IActionResult Index()
        {
            return View(_productoRealRepository.GetProductosReales());
        }

        // GET: ProductosReales/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _productoRealRepository.GetProductosReales(id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: ProductosReales/Create
        public IActionResult Create()
        {


            var model = new ProductoRealViewModel
            {
                Productos = _combosHelper.GetComboProductos(),

            };
            return View(model);
        }

        // POST: ProductosReales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoRealViewModel model)
        {
            if (ModelState.IsValid)
            {
                var producto = await _converterHelper.ToProductoRealAsync(model);

                await _productoRealRepository.CreateAsync(producto);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: ProductosReales/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoReal = _productoRealRepository.GetProductosReales(id);
            ; if (productoReal == null)
            {
                return NotFound();
            }
            return View(productoReal);
        }

        // POST: ProductosReales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,stock")] ProductoReal productoReal)
        {
            if (id != productoReal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productoRealRepository.UpdateAsync(productoReal);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoRealExists(productoReal.Id))
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
            return View(productoReal);
        }

        // GET: ProductosReales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoReal = _productoRealRepository.GetProductosReales(id);
            if (productoReal == null)
            {
                return NotFound();
            }

            return View(productoReal);
        }

        // POST: ProductosReales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productoReal = _productoRealRepository.GetProductosReales(id);
            await _productoRealRepository.DeleteAsync(productoReal);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoRealExists(int id)
        {
            return _context.ProductoReal.Any(e => e.Id == id);
        }
    }
}
