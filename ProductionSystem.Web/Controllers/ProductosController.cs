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
    //[Authorize]
    public class ProductosController : Controller
    {
        private readonly IProductoRepository _productoRepository;
        private readonly ICombosHelper _combosHelper;
 

        private readonly IConverterHelper _converterHelper;
        public ProductosController(
           
            IProductoRepository productoRepository,
            ICombosHelper combosHelper,
            IConverterHelper converterHelper
            )

        {
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
                Categorias = null,
                TiposProductos = _combosHelper.GetComboTipoProducto(),
                Sabores = _combosHelper.GetComboSabores(),
                Presentaciones = _combosHelper.GetComboPresentaciones(),
                Lineas = _combosHelper.GetComboLineas(),


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


        // GET: Se encarga de traer las categorias que tiene la linea seleccionada, pero deberia ser un post.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetCategorias(ProductoViewModel model)
        {

            // Aqui tenemos cargado el id de la linea correspondiente

            //Tenemos que buscar un combo con la categoria que tiene las lineas y para eso hacemos otro combo box.


            var productomodel = new ProductoViewModel
            {

                Categorias = _combosHelper.GetComboCategorias(model.LineaId),
                TiposProductos = _combosHelper.GetComboTipoProducto(),
                Sabores = _combosHelper.GetComboSabores(),
                Presentaciones = _combosHelper.GetComboPresentaciones(),
                Lineas = _combosHelper.GetComboLineas(),



            };

            return View(productomodel);

           
        }



        // GET: Productoes/Edit/5
        public IActionResult Edit(int? id)
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
        public IActionResult Delete(int? id)
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

        
    }
}
