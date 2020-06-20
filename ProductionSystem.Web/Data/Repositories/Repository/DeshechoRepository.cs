using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Data.Repositories.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    public class DeshechoRepository : GenericRepository<Deshecho> , IDeshechoRepository
    {
        private readonly DataContext context;

        public DeshechoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }


    }
}
