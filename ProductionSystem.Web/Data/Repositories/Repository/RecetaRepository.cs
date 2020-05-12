using Microsoft.EntityFrameworkCore;
using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Data.Repositories.Interfaz;
using System.Linq;

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    public class RecetaRepository : GenericRepository<Receta>, IRecetaRepository
    {
        private readonly DataContext context;

        public RecetaRepository(DataContext context) : base(context)
        {
            this.context = context;
        }


        public IQueryable GetRecetas()
        {
            return context.Recetas
                .Include(pr => pr.ProductoReal)
                .Include(ins => ins.Insumo);


        }
        public Receta GetRecetas(int? id)
        {
            return context.Recetas
                .Include(pr => pr.ProductoReal)
                .Include(ins => ins.Insumo)
                .FirstOrDefault(r => r.Id == id);


        }
    }
}
