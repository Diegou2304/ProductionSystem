using Microsoft.EntityFrameworkCore;
using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Data.Repositories.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        private readonly DataContext context;
        private readonly IFaseRepository faseRepository;

        public PedidoRepository(DataContext context,
            IFaseRepository faseRepository) : base(context)
        {
            this.context = context;
            this.faseRepository = faseRepository;
        }

        
        public IQueryable GetPedidos()
        {
            return context.Pedidos
                .Include(p => p.ProductoReal)
                .ThenInclude(pr => pr.Producto);
        }
        public Pedido GetPedidos(int? id)
        {
            return context.Pedidos
                .Include(p => p.ProductoReal)
                .ThenInclude(pr => pr.Producto)
                .FirstOrDefault(i => i.Id ==id);
        }

        public Pedido GetDetailsPedido(int? id)
        {
            return context.Pedidos
                .Include(p => p.ProductoReal)
                .ThenInclude(pr => pr.Producto)
                .ThenInclude(tp => tp.TipoProducto)
                .Include(p => p.ProductoReal)
                .ThenInclude(pr => pr.Producto)
                .ThenInclude(tp => tp.Sabor)
                 .Include(p => p.ProductoReal)
                .ThenInclude(pr => pr.Producto)
                .ThenInclude(tp => tp.Categoria)
                 .Include(p => p.ProductoReal)
                .ThenInclude(pr => pr.Producto)
                .ThenInclude(tp => tp.Presentacion)
                .ThenInclude(e => e.Envase)
                 .Include(p => p.ProductoReal)
                .ThenInclude(pr => pr.Producto)
                .ThenInclude(tp => tp.Presentacion)
                .ThenInclude(e => e.Etiqueta)
                
                .FirstOrDefault(i => i.Id == id);
        }

        //Por probar
        //Obtengo los pedidos pendientes por usuario logeado
        public IQueryable GetPedidosPendientesUsuario(User user)
        {
            return context.Pedidos
                .Include(p => p.ProductoReal)
                .ThenInclude(pr => pr.Producto)
                .Where(c => (c.estado == "Pendiente" || c.estado == "Proceso") && c.NumeroFase == user.CargoNumero);
        }

        //Por probar
        //Hacer la que cambia de estado 

        
        public async Task CambiarEstadoAProceso(Pedido pedido)
        {
            pedido.estado = "Proceso";
            await this.UpdateAsync(pedido);
        }

        public async Task CambiarEstadoAFinalizado(Pedido pedido)
        {
            pedido.estado = "Finalizado";
            await this.UpdateAsync(pedido);
        }

        public async Task CambiarAFaseSiguiente(Pedido pedido)
        {

            int aux = faseRepository.GetNumeroUltimaFase();
            int aux2 = pedido.NumeroFase;

            if (pedido.NumeroFase == aux)
            {
                pedido.estado = "Finalizado";
                await this.UpdateAsync(pedido);
            }
            if (aux2 < aux)
            {
                pedido.NumeroFase += 1;
                await this.UpdateAsync(pedido);
            }
            
                        
        }





    }
}
