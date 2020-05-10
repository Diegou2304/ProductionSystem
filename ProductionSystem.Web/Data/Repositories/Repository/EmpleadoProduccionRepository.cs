

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using ProductionSystem.Web.Data.Entities;
    using ProductionSystem.Web.Data.Repositories.Interfaz;
   
    public class EmpleadoProduccionRepository : GenericRepository<EmpleadoProduccion> , IEmpleadoProduccionRepository
    {
        private readonly DataContext context;

        public EmpleadoProduccionRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
