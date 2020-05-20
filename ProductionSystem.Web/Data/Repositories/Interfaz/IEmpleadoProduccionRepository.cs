

namespace ProductionSystem.Web.Data.Repositories.Interfaz
{
    using ProductionSystem.Web.Data.Entities;
    using System.Threading.Tasks;

    public interface IEmpleadoProduccionRepository:IGenericRepository<EmpleadoProduccion>
    {

        Task<EmpleadoProduccion> GetEmpleadoConFase(int id);

        Task<EmpleadoProduccion> GetEmpleadoPorCI(int ci);


    }
}
