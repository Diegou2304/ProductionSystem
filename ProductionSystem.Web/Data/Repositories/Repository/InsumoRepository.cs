

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaz;
    using System.Linq;

    public class InsumoRepository : GenericRepository<Insumo>, IInsumoRepository
    {

        private readonly DataContext context;

        public InsumoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public Insumo GetInsumoById(int id)
        {
            return context.Insumos        
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

    }
}
