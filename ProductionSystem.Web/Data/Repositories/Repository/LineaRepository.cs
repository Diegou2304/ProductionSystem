

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using ProductionSystem.Web.Models;
    using Repositories.Interfaz;
    using System.Linq;
    using System.Threading.Tasks;

    public class LineaRepository : GenericRepository<Linea>, ILineaRepository
    {
        private readonly DataContext context;

        public LineaRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        //Categoria

        public async Task AddCategoriaAsync(CategoriaViewModel model)
        {
            var linea = await this.GetLineaConCategoriaAsync(model.PoseedorId);
            if (linea == null)
            {
                return;
            }

            var categoria = new Categoria
            {
                Nombre = model.Nombre
            };
            linea.Categorias.Add(categoria);
            this.context.Lineas.Update(linea);
            await this.context.SaveChangesAsync();
        }

        public async Task<int> DeleteCategoriaAsync(Categoria categoria)
        {
            var linea = await this.context.Lineas.Where(c => c.Categorias.Any(ci => ci.Id == categoria.Id)).FirstOrDefaultAsync();
            if (linea == null)
            {
                return 0;
            }

            this.context.Categorias.Remove(categoria);
            await this.context.SaveChangesAsync();
            return linea.Id;
        }

        public async Task<int> UpdateCategoriaAsync(Categoria categoria)
        {
            var linea = await this.context.Lineas.Where(c => c.Categorias.Any(ci => ci.Id == categoria.Id)).FirstOrDefaultAsync();
            if (linea == null)
            {
                return 0;
            }

            this.context.Categorias.Update(categoria);
            await this.context.SaveChangesAsync();
            return linea.Id;
        }




        public async Task<Linea> GetLineaConCategoriaAsync(int id)
        {
            return await this.context.Lineas
            .Include(c => c.Categorias)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        }

        public IQueryable GetLineasConCategorias()
        {
            return this.context.Lineas
            .Include(c => c.Categorias)
            .OrderBy(c => c.Nombre);
        }

        public async Task<Categoria> GetCategoriaAsync(int id)
        {
            return await this.context.Categorias.FindAsync(id);
        }

        

    }
}
