

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using Entities;
    using Repositories.Interfaz;

    public class InsumoRepository : GenericRepository<Insumo>, IInsumoRepository
    {
       public InsumoRepository(DataContext context) : base(context)
        {


        } 

    }
}
