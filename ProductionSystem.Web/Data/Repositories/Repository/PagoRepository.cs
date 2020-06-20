using Microsoft.EntityFrameworkCore;
using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Data.Repositories.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    public class PagoRepository:  GenericRepository<Pago> , IPagoRepository
    {
             private readonly DataContext context;

            public PagoRepository(DataContext context) : base(context)
            {
                this.context = context;
            }

        public Pago GetPagosCompletos(int ? id)
        {
            var pr3 = context.Pagos
                .Include(p => p.ProductoPago)

                 .Include(pr => pr.Empresa)
                .FirstOrDefault(p => p.Id == id);
            return pr3;
        }

       
    }
}
