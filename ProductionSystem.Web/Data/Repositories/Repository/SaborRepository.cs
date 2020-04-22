

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using ProductionSystem.Web.Data.Entities;
    using ProductionSystem.Web.Data.Repositories.Interfaz;

    public class SaborRepository :GenericRepository<Sabor> , ISaborRepository
    {

        private readonly DataContext context;

        public SaborRepository(DataContext context) : base(context)
        {
            this.context = context;
        }


    }
}
