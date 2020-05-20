

namespace ProductionSystem.Web.Data.Repositories.Repository
{
    using Microsoft.EntityFrameworkCore;
    using ProductionSystem.Web.Data.Entities;
    using ProductionSystem.Web.Data.Repositories.Interfaz;
    using ProductionSystem.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProduccionRepository : GenericRepository<Produccion>, IProduccionRepository
    {
        private readonly DataContext context;
        private readonly IEmpleadoProduccionRepository empleadoProduccionRepository;
        private readonly IFaseRepository faseRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IInsumoRepository insumoRepository;
        private readonly IInsumoUsadoRepository insumoUsadoRepository;

        public ProduccionRepository(DataContext context, 
            IEmpleadoProduccionRepository empleadoProduccionRepository,
            IFaseRepository faseRepository,
            IPedidoRepository pedidoRepository,
            IInsumoRepository insumoRepository,
            IInsumoUsadoRepository insumoUsadoRepository) : base(context)
        {
            this.context = context;
            this.empleadoProduccionRepository = empleadoProduccionRepository;
            this.faseRepository = faseRepository;
            this.pedidoRepository = pedidoRepository;
            this.insumoRepository = insumoRepository;
            this.insumoUsadoRepository = insumoUsadoRepository;
        }


        //obtener la produccion en proceso por usuario
        public Produccion GetProduccionUsuario(User user)
        {
            return context.Producciones
                .Include(p => p.Pedido)
                .Include(q => q.EmpleadoProducción)
                .Include(l => l.Fase)
                .Where(c => c.Pedido.estado == "Proceso" && c.EmpleadoProducción.Ci == user.Ci)
                .FirstOrDefault();
        }

        //obtener produccion por id
        public Produccion GetProduccionById(int id)
        {
            return context.Producciones
                .Include(p => p.Pedido)
                .Include(q => q.EmpleadoProducción)
                .Include(s => s.InsumosUsados)
                .Include(l => l.Fase)
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }


        
        public async Task ActulizarInsumosUsadosenProduccion(InsumoUsado insumo, int id)
        {
            var produccion = this.GetProduccionById(id);
            if (produccion == null)
            {
                return;
            }                     

            produccion.InsumosUsados.Add(insumo);
            this.context.Producciones.Update(produccion);
            await this.context.SaveChangesAsync();
        }



    }
}
