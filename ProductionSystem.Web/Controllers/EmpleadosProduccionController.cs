

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

    public class EmpleadosProduccionController : Controller
    {
        private readonly IEmpleadoProduccionRepository empleadoProduccionRepository;
        private readonly ICombosHelper combosHelper;
        private readonly IConverterHelper converterHelper;

        public EmpleadosProduccionController(IEmpleadoProduccionRepository empleadoProduccionRepository, ICombosHelper combosHelper, IConverterHelper converterHelper)
        {
            this.empleadoProduccionRepository = empleadoProduccionRepository;
            this.combosHelper = combosHelper;
            this.converterHelper = converterHelper;
        }

        // GET: EmpleadosProduccion
        public IActionResult Index()
        {
            return View(this.empleadoProduccionRepository.GetAll());
        }

        // GET: EmpleadosProduccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadoProduccion = await this.empleadoProduccionRepository.GetEmpleadoConFase(id.Value);
            if (empleadoProduccion == null)
            {
                return NotFound();
            }

            return View(empleadoProduccion);
        }

        // GET: EmpleadosProduccion/Create
        public IActionResult Create()
        {
            var model = new EmpleadoProduccionViewModel
            {
                Fases = combosHelper.GetComboFases(),
            };

            return View(model);
        }

        // POST: EmpleadosProduccion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpleadoProduccionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var empleadoProduccion = await converterHelper.ToEmpleadoProduccionAsync(model);


                await this.empleadoProduccionRepository.CreateAsync(empleadoProduccion);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: EmpleadosProduccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadoProduccion = await this.empleadoProduccionRepository.GetEmpleadoConFase(id.Value);
            if (empleadoProduccion == null)
            {
                return NotFound();
            }

            var model = converterHelper.ToEmpleadoProduccionViewModel(empleadoProduccion);
            return View(model);
        }

        // POST: EmpleadosProduccion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmpleadoProduccionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var empleadoProduccion = await converterHelper.ToEmpleadoProduccionAsync(model);
                try
                {
                    await this.empleadoProduccionRepository.UpdateAsync(empleadoProduccion);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.empleadoProduccionRepository.ExistAsync(empleadoProduccion.Id))
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
            return View(model);
        }

        // GET: EmpleadosProduccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadoProduccion = await this.empleadoProduccionRepository.GetByIdAsync(id.Value);
            if (empleadoProduccion == null)
            {
                return NotFound();
            }

            return View(empleadoProduccion);
        }

        // POST: EmpleadosProduccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleadoProduccion = await this.empleadoProduccionRepository.GetByIdAsync(id);
            await this.empleadoProduccionRepository.DeleteAsync(empleadoProduccion);
            return RedirectToAction(nameof(Index));
        }

    }
}
