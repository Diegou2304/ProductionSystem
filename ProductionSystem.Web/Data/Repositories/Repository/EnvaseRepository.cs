

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using ProductionSystem.Web.Data.Entities;
    using ProductionSystem.Web.Data.Repositories.Interfaz;
    

    public class EnvaseRepository : GenericRepository<Envase> , IEnvaseRepository
    {

        private readonly DataContext context;

        public EnvaseRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

    }
}
