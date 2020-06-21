

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
    using ProductionSystem.Web.Data.Repositories.Repository;
    using ProductionSystem.Web.Helpers;
    using ProductionSystem.Web.Models;
    using Remotion.Linq.Parsing.ExpressionVisitors.TreeEvaluation;

    public class ProduccionesController : Controller
    {
        private readonly IProduccionRepository produccionRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IUserHelper userHelper;
        private readonly IConverterHelper converterHelper;
        private readonly ICombosHelper combosHelper;
        private readonly IInsumoUsadoRepository insumoUsadoRepository;
        private readonly IDeshechoRepository deshechoRepository;
        private readonly IResultadoRepository resultadoRepository;

        public ProduccionesController(
            IProduccionRepository produccionRepository, 
            IPedidoRepository pedidoRepository,
            IUserHelper userHelper,
            IConverterHelper converterHelper,
            ICombosHelper combosHelper,
            IInsumoUsadoRepository insumoUsadoRepository,
            IDeshechoRepository deshechoRepository,
            IResultadoRepository resultadoRepository)
        {
            this.produccionRepository = produccionRepository;
            this.pedidoRepository = pedidoRepository;
            this.userHelper = userHelper;
            this.converterHelper = converterHelper;
            this.combosHelper = combosHelper;
            this.insumoUsadoRepository = insumoUsadoRepository;
            this.deshechoRepository = deshechoRepository;
            this.resultadoRepository = resultadoRepository;
        }

        // GET: Producciones
        public IActionResult Index()
        {
            return View(this.produccionRepository.GetAll());
        }

        // GET: Producciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = await this.produccionRepository.GetByIdAsync(id.Value);
            if (produccion == null)
            {
                return NotFound();
            }

            return View(produccion);
        }

        // GET: Producciones/Create
        public async Task<IActionResult> Create(int? id)
        {
            
            if (id == null)
                return NotFound();

            var pedido = await this.pedidoRepository.GetByIdAsync(id.Value);
            if (pedido == null)
                return NotFound();

            var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
            if (user == null)
                return NotFound();

            
            var model = new ProduccionViewModel
            {
                PedidoId = pedido.Id,
                UserCi = user.Ci,
                FaseId = user.CargoNumero,
            };
            
            return View(model);
        }

        // POST: Producciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProduccionViewModel model)
        {
            if (ModelState.IsValid)
            {

                var produccion = await converterHelper.ToProduccionAsync(model);

                await produccionRepository.CreateAsync(produccion);
                
                //TODO: Habilitar esto
                //cambio de estados
                var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await this.userHelper.CambiarEstadoANoDisponible(user);
                await this.pedidoRepository.CambiarEstadoAProceso(produccion.Pedido);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Producciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = await this.produccionRepository.GetByIdAsync(id.Value);
            if (produccion == null)
            {
                return NotFound();
            }
            return View(produccion);
        }

        // POST: Producciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Produccion produccion)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    await this.produccionRepository.UpdateAsync(produccion);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.produccionRepository.ExistAsync(produccion.Id))
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
            return View(produccion);
        }

        // GET: Producciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = await this.produccionRepository.GetByIdAsync(id.Value);
            if (produccion == null)
            {
                return NotFound();
            }

            return View(produccion);
        }

        // POST: Producciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produccion = await this.produccionRepository.GetByIdAsync(id);
            await this.produccionRepository.DeleteAsync(produccion);
            return RedirectToAction(nameof(Index));
        }

        //lo shido
        //Las producciones en proceso de cada usuario
        public async Task<IActionResult> ProduccionUsuario()
        {

            var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
            if (user == null)
                return NotFound();
            if (user.Disponible == true)
                return NotFound();
            var model = this.produccionRepository.GetProduccionUsuario(user);


            return View(model);

        }

        //el id que llega como parametro es el id de la produccion
        //
        //Get
        public IActionResult AddInsumoUsado(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = this.produccionRepository.GetProduccionById(id.Value);
            if (produccion == null)
            {
                return NotFound();
            }

            var model = new InsumoUsadoViewModel
            {

                ProduccionId = produccion.Id,
                Insumos = combosHelper.GetComboInsumo()

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddInsumoUsado(InsumoUsadoViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var insumoUsado = converterHelper.ToInsumoUsado(model);
                //await produccionRepository.ActulizarInsumosUsadosenProduccion(insumoUsado, model.ProduccionId);
                await insumoUsadoRepository.CreateAsync(insumoUsado);
                //

                return this.RedirectToAction("ProduccionUsuario");
            }

            return this.View(model);
        }

        public IActionResult DetailsInsumoUsado(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumoUsado = this.insumoUsadoRepository.GetInsumoUsadoById(id.Value);
            if (insumoUsado == null)
            {
                return NotFound();
            }

            return View(insumoUsado);
        }
                
        public IActionResult AddDeshecho(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = this.produccionRepository.GetProduccionById(id.Value);
            if (produccion == null)
            {
                return NotFound();
            }

            var model = new DeshechoViewModel
            {

                ProduccionId = produccion.Id,
                
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDeshecho(DeshechoViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var deshecho = converterHelper.ToDeshecho(model);
                
                await deshechoRepository.CreateAsync(deshecho);
                //

                return this.RedirectToAction("ProduccionUsuario");
            }

            return this.View(model);
        }

        public IActionResult AddResultado(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = this.produccionRepository.GetProduccionById(id.Value);
            if (produccion == null)
            {
                return NotFound();
            }

            var model = new ResultadoViewModel
            {

                ProduccionId = produccion.Id,

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddResultado(ResultadoViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var resultado = converterHelper.ToResultado(model);
                
                await resultadoRepository.CreateAsync(resultado);
                //

                return this.RedirectToAction("ProduccionUsuario");
            }

            return this.View(model);
        }


        
        public async Task<IActionResult> Confirmar(int? id)
        {

            if(id == null)
            {
                return NotFound();
            }
            var produccion = this.produccionRepository.GetProduccionById(id.Value);
            if (produccion == null)
            {
                return NotFound();
            }

            //cambio de estados
            var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
            
            await this.pedidoRepository.CambiarAFaseSiguiente(produccion.Pedido);
            await this.userHelper.CambiarEstadoADisponible(user);

            return RedirectToAction("ProduccionUsuario");

        }
        








    }
}
