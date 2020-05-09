
namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using ProductionSystem.Web.Data.Repositories.Interfaz;
    using System.Linq;
    using System.Threading.Tasks;

    public class PresentacionRepository : GenericRepository<Presentacion>, IPresentacionRepository
    {
        private readonly DataContext _dataContext;

        //Lo que inyecta se lo pasa al constructor de la super clase
        public PresentacionRepository(DataContext context) : base(context)
        {
            _dataContext = context;


        }

        public Presentacion GetDetailsPresentacion(int? id)
        {
            return _dataContext.Presentaciones
                  .Include(e => e.Envase)
                  .Include(et => et.Etiqueta)
                  .FirstOrDefault(p => p.Id == id);
        }



        public IQueryable GetPresentacionConEtiquetaEnvase()
        {
            return _dataContext.Presentaciones
                    .Include(p => p.Etiqueta)
                    .Include(p => p.Envase);
        }

        public  Presentacion GetPresentacionAsync(int id)
        {


           return  _dataContext.Presentaciones
                .Include(e => e.Etiqueta)
                .FirstOrDefault(m => m.Id == id);
        }


    }
}
