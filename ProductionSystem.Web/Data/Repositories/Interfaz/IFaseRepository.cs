

namespace ProductionSystem.Web.Data.Repositories.Interfaz
{
    using ProductionSystem.Web.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IFaseRepository : IGenericRepository<Fase>
    {

        Task<Fase> GetFase(int id);

        Task<string> GetNombreFaseAsync(int id);
        Task<Fase> GetLastRecord();


        Task<int> GetNumeroFaseAsync(int id);

    }
}
