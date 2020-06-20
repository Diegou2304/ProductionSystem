

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using Microsoft.EntityFrameworkCore;
    using ProductionSystem.Web.Data.Entities;
    using ProductionSystem.Web.Data.Repositories.Interfaz;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class InsumoUsadoRepository : GenericRepository<InsumoUsado>, IInsumoUsadoRepository
    {
        private readonly DataContext context;

        public InsumoUsadoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        //Insumo Usado por Id

        public InsumoUsado GetInsumoUsadoById(int id)
        {
            return context.InsumoUsados
                .Include(i => i.Insumo)
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }



    }
}
