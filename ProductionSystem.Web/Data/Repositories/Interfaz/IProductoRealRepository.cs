﻿using ProductionSystem.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Repositories.Interfaz
{
   public interface IProductoRealRepository : IGenericRepository<ProductoReal>
    {
        IQueryable GetProductosReales();
        ProductoReal GetProductosReales(int? id);
    }
}
