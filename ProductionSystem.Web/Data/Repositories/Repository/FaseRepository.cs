

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using ProductionSystem.Web.Data.Entities;
    using ProductionSystem.Web.Data.Repositories.Interfaz;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class FaseRepository : GenericRepository<Fase>, IFaseRepository
    {
        private readonly DataContext context;

        public FaseRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

    }
}
