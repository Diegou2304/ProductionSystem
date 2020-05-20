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

namespace ProductionSystem.Web.Controllers
{
    public class PedidosController : Controller
    {
        private readonly DataContext _context;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IValidatorHelper _validatorHelper;
        private readonly IUserHelper userHelper;

        public PedidosController(
            DataContext context,
            IPedidoRepository pedidoRepository,
            ICombosHelper combosHelper,
            IConverterHelper converterHelper,
            IValidatorHelper validatorHelper,
            IUserHelper userHelper)
        {
            _context = context;
            _pedidoRepository = pedidoRepository;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _validatorHelper = validatorHelper;
            this.userHelper = userHelper;
        }

        // GET: Pedidos
        

        // GET: Pedidos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = _pedidoRepository.GetDetailsPedido(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {

            var model = new PedidoViewModel
            {
                ProductosReales =  _combosHelper.GetComboProductosReales(),
            };
            return View(model);
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidoViewModel model)
        {
            if (ModelState.IsValid)
            {


                var pedido = await _converterHelper.ToPedidoAsync(model);

                await _pedidoRepository.CreateAsync(pedido);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        //No puedo modificar un pedido si este ya esta en proceso
        // GET: Pedidos/Edit/5
        public IActionResult Edit(int? id)
        {
            //TODO: arreglar esta validacion para funcione de otra forma
            /*
            if(!_validatorHelper.IsPedidoPendiente(id))
            {
                return RedirectToAction("Error");
            }*/



            if (id == null)
            {
                return NotFound();
            }

            var model = _pedidoRepository.GetPedidos(id);

            var pedido = _converterHelper.ToPedidoViewModel(model);


            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }
        public IActionResult Error()
        {


            return View();
        }



        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PedidoViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                

                    var pedido = await  _converterHelper.ToPedidoAsync(model);


                    await _pedidoRepository.UpdateAsync(pedido);
               
                  
                
                     return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return View("NoEncontrado");
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }

        //Lo shido

        public IActionResult Index()
        {
            return View(_pedidoRepository.GetPedidos());
        }

        //View para mostrar los pedidos pendientes por usuario
        public async Task<IActionResult> PedidosPendientesUsuario()
        {







            var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
            //valida que el usuario no este con un pedido en proceso
            if (user.Disponible == true)
            {
                return View(_pedidoRepository.GetPedidosPendientesUsuario(user));
            }
            else
            {
                //TODO: hacer vista de Usurio Ocupado
                return View("NoEncontrado");
            }
            
        }





    }
}
