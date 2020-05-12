using ProductionSystem.Web.Data.Entities;
using System.Linq;

namespace ProductionSystem.Web.Data.Repositories.Interfaz
{
    public interface IRecetaRepository : IGenericRepository<Receta>
    {
        IQueryable GetRecetas();
        Receta GetRecetas(int? id);

    }
}
