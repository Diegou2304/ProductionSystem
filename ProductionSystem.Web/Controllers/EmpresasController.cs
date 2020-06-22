

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
    using ProductionSystem.Web.Helpers;
    using ProductionSystem.Web.Models;

    public class EmpresasController : Controller
    {
        private readonly IEmpresaRepository empresaRepository;
        private readonly IConverterHelper _converterHelper;
        private readonly DataContext _dataContext;

        public EmpresasController(IEmpresaRepository empresaRepository
            , IConverterHelper converterHelper,
            DataContext dataContext)
        {
            this.empresaRepository = empresaRepository;
            _converterHelper = converterHelper;
            _dataContext = dataContext;
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

        public async Task<IActionResult> AddSucursal(int? id)
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

            var model = new SucursalViewModel
            {
                EmpresaId = empresa.Id,
                NombreEmpresa = empresa.Nombre,

            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddSucursal(SucursalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var sucursal = await _converterHelper.ToSucursal(model);
            if (sucursal == null)
            {
                return NotFound();
            }

            _dataContext.Sucursales.Add(sucursal);
            _dataContext.SaveChanges();

            return RedirectToAction($"Details/{model.EmpresaId}");
        }

        public IActionResult ViewSucursales(int? id)
        {
            return View(_dataContext.Sucursales
           .Where(c => c.Empresa.Id == id));



        }

        public async Task<IActionResult> EditSucursales(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursal = await _dataContext.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            return View(sucursal);


        }
        [HttpPost]
        public IActionResult EditSucursales(Sucursal model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _dataContext.Sucursales.Update(model);

          

            _dataContext.SaveChanges();

            return RedirectToAction("Index");


        }

        public async Task<IActionResult> AdminEncargado(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encargado =  _dataContext.EncargadosEmpresas.Include(em => em.Empresa).FirstOrDefault(em => em.Empresa.Id == id);

            var empresa = await this.empresaRepository.GetByIdAsync(id.Value);

            var model = new EncargadoViewModel
            {
                EmpresaId = empresa.Id,
                NombreEmpresa = empresa.Nombre,
                
                EncargadoEmpresa = encargado,

            };
            return View(model);


        }

        [HttpPost]
        public async Task<IActionResult> AdminEncargado(EncargadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var encargado = model.EncargadoEmpresa;

            encargado.Empresa = await _dataContext.Empresas.FindAsync(model.EmpresaId);

            if (encargado == null)
            {
                return NotFound();
            }

            _dataContext.EncargadosEmpresas.Add(encargado);
            _dataContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
