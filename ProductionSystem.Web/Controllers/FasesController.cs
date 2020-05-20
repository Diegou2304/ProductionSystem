

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

    public class FasesController : Controller
    {
        private readonly IFaseRepository faseRepository;

        public FasesController(IFaseRepository faseRepository)
        {
            this.faseRepository = faseRepository;
        }

        // GET: Fases
        public IActionResult Index()
        {
            return View(this.faseRepository.GetAll());
        }

        // GET: Fases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fase = await this.faseRepository.GetByIdAsync(id.Value);
            if (fase == null)
            {
                return NotFound();
            }

            return View(fase);
        }

        // GET: Fases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //Funcion para cambiar de fase, se llama cuando terminemos un proceso
        
        //Ir a produccion, ligado con el empleado, sacar d eacuerdo con la cuenta, buscar el empleado sacar el pedido y vamos a la tabla de pedidos para mostrarle el usuario
        //Deshechos aceptar los deshechos producto rterminado se cree solo, solo en despues de la fase 3.
        // Pedido tiene fase.
        

//Numero de la ultima fase nomas.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fase fase)
        {
            if (ModelState.IsValid)
            {
               
                await this.faseRepository.CreateAsync(fase);

                var temp = this.faseRepository.GetLastRecord();

                fase.Numero = fase.Id;

                await this.faseRepository.UpdateAsync(fase);

                return RedirectToAction(nameof(Index));
            }
            return View(fase);
        }

        // GET: Fases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fase = await this.faseRepository.GetByIdAsync(id.Value);
            if (fase == null)
            {
                return NotFound();
            }
            return View(fase);
        }

        // POST: Fases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Fase fase)
        {
    
            if (ModelState.IsValid)
            {
                try
                {
                    await this.faseRepository.UpdateAsync(fase);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.faseRepository.ExistAsync(fase.Id))
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
            return View(fase);
        }

        // GET: Fases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fase = await this.faseRepository.GetByIdAsync(id.Value);
            if (fase == null)
            {
                return NotFound();
            }

            return View(fase);
        }

        // POST: Fases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fase = await this.faseRepository.GetByIdAsync(id);
            await this.faseRepository.DeleteAsync(fase);
            return RedirectToAction(nameof(Index));
        }
    }
}
