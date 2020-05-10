using Microsoft.EntityFrameworkCore;
using ProductionSystem.Web.Controllers;
using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Data.Repositories.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        private readonly DataContext _dataContext;

        //Lo que inyecta se lo pasa al constructor de la super clase
        public ProductoRepository(DataContext context) : base(context)
        {
            _dataContext = context;


        }

        public IQueryable GetProductosCompletos()
        {
            return _dataContext.Productos
                .Include(c => c.Categoria)
                .Include(tp => tp.TipoProducto)
                .Include(s => s.Sabor)
                .Include(p => p.Presentacion)
                    .ThenInclude(et => et.Etiqueta)
                .Include(p => p.Presentacion)
                    .ThenInclude(en => en.Envase);
               
        }

        public Producto GetProductosCompletos(int? id)
        {
            return _dataContext.Productos
                .Include(c => c.Categoria)
                .Include(tp => tp.TipoProducto)
                .Include(s => s.Sabor)
                .Include(p => p.Presentacion)
                    .ThenInclude(et => et.Etiqueta)
                .Include(p => p.Presentacion)
                    .ThenInclude(en => en.Envase)
                 .FirstOrDefault(o => o.Id == id);

        }





    }
}
