

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using Entities;
    using Repositories.Interfaz;

    public class InsumoRepository : GenericRepository<Insumo>, IInsumoRepository
    {

        private readonly DataContext context;

        public InsumoRepository(DataContext context) : base(context)
        {
            this.context = context;
        } 

    }
}
