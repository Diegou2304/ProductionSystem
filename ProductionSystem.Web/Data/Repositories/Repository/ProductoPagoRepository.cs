using Microsoft.EntityFrameworkCore;
using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Data.Repositories.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    public class ProductoPagoRepository : GenericRepository<ProductoPago>,IProductoPagoRepository
    {
        private readonly DataContext context;

        public ProductoPagoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

       public ProductoPago GetAllPagos(int? id)
        {
            var pr3 = context.ProductoPagos
                .Include(pr => pr.ProductoReal)
                .Include(p => p.Pago)
                .ThenInclude(em => em.Empresa)
                .FirstOrDefault(e => e.Pago.Id == id);
            return pr3;
        }
    }
}
