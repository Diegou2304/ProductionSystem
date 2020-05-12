using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using Microsoft.EntityFrameworkCore;
using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Data.Repositories.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    public class ProductoRealRepository : GenericRepository<ProductoReal>, IProductoRealRepository
    {

        private readonly DataContext _context;

        public ProductoRealRepository(DataContext context) : base(context)
        {
            _context = context;
        }


        public IQueryable GetProductosReales() 
        {

            return _context.ProductoReal
                .Include(p => p.Producto);
        
        }

        public ProductoReal GetProductosReales(int? id)
        {
            return _context.ProductoReal
                .Include(p => p.Producto)
                    .ThenInclude(tp => tp.TipoProducto)
                 .Include(pr => pr.Producto)
                    .ThenInclude(p => p.Presentacion)
                 
                    .ThenInclude(et => et.Etiqueta)
                   .Include(pr => pr.Producto)
                    .ThenInclude(p => p.Presentacion)

                    .ThenInclude(et => et.Envase)




                .FirstOrDefault(p => p.Id == id);
        }
    }
}
