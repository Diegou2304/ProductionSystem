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

        public PedidoRepository(DataContext context) : base(context)
        {
            this.context = context;
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
    }
}
