

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using ProductionSystem.Web.Data.Entities;
    using ProductionSystem.Web.Data.Repositories.Interfaz;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EtiquetaRepository : GenericRepository<Etiqueta>, IEtiquetaRepository
    {

        private readonly DataContext context;

        public EtiquetaRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public Etiqueta GetEtiqueta(int Id)
        {
           return   context.Etiquetas.FirstOrDefault(e => e.Id== Id);
        }
    }
}
