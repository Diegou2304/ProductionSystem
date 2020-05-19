

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using Microsoft.EntityFrameworkCore;
    using ProductionSystem.Web.Data.Entities;
    using ProductionSystem.Web.Data.Repositories.Interfaz;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmpleadoProduccionRepository : GenericRepository<EmpleadoProduccion> , IEmpleadoProduccionRepository
    {
        private readonly DataContext context;

        public EmpleadoProduccionRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<EmpleadoProduccion> GetEmpleadoConFase(int id)
        {
            return await this.context.EmpleadosProducciones
            .Include(c => c.Fase)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }




    }
}
