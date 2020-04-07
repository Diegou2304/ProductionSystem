

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using Entities;
    using Repositories.Interfaz;

    public class LineaRepository : GenericRepository<Linea>, ILineaRepository
    {
        public LineaRepository(DataContext context) : base(context)
        {

        }



    }
}
