


namespace ProductionSystem.Web.Data.Repositories.Interfaz
{
    using ProductionSystem.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IEtiquetaRepository:IGenericRepository<Etiqueta>
    {
        Etiqueta GetEtiqueta(int Id);

    }
}
