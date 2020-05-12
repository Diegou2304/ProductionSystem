using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Data.Repositories.Interfaz;

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    public class RecetaRepository : GenericRepository<Receta>, IRecetaRepository
    {
        private readonly DataContext context;

        public EtiquetaRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

    }
}
