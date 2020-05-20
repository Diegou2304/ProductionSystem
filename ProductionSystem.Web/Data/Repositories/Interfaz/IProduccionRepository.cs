

namespace ProductionSystem.Web.Data.Repositories.Interfaz
{
    using ProductionSystem.Web.Data.Entities;
    using ProductionSystem.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IProduccionRepository : IGenericRepository<Produccion>
    {
        Produccion GetProduccionUsuario(User user);

        Produccion GetProduccionById(int id);

        Task ActulizarInsumosUsadosenProduccion(InsumoUsado insumo, int id);

    }
}
