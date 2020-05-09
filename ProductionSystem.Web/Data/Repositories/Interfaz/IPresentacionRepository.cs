using ProductionSystem.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Repositories.Interfaz
{
    using Entities;
    using ProductionSystem.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IPresentacionRepository : IGenericRepository<Presentacion>
    {
        IQueryable GetPresentacionConEtiquetaEnvase();
        Presentacion GetDetailsPresentacion(int? id);
        Presentacion GetPresentacionAsync(int id);


    }
}
