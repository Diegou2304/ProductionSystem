

namespace ProductionSystem.Web.Data.Repositories.Interfaz
{
    using Entities;
    using ProductionSystem.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;

    //se implementaran los metodos de acceso a categoria ya que linea es el metodo de acceder a ellos
    public interface ILineaRepository : IGenericRepository<Linea>
    {
        //Categoria
        Task AddCategoriaAsync(CategoriaViewModel model);

        Task<int> DeleteCategoriaAsync(Categoria categoria);

        Task<int> UpdateCategoriaAsync(Categoria categoria);





        Task<Linea> GetLineaConCategoriaAsync(int id);

        IQueryable GetLineasConCategorias();

        Task<Categoria> GetCategoriaAsync(int id);

        

    }
}
