using ProductionSystem.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Repositories.Interfaz
{
    public interface IPedidoRepository: IGenericRepository<Pedido>
    
    {
        IQueryable GetPedidos();
        Pedido GetPedidos(int? id);
        Pedido GetDetailsPedido(int? id);
        IQueryable GetPedidosPendientesUsuario(User user);


        Task CambiarEstadoAProceso(Pedido pedido);
        Task CambiarEstadoAFinalizado(Pedido pedido);

        Task CambiarAFaseSiguiente(Pedido pedido);

    }
}
