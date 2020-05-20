

namespace ProductionSystem.Web.Data.Repositories.Repository
{
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


    }
}
