

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using ProductionSystem.Web.Data.Entities;
    using ProductionSystem.Web.Data.Repositories.Interfaz;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmpresaRepository : GenericRepository<Empresa>, IEmpresaRepository
    {
        private readonly DataContext context;

        public EmpresaRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
