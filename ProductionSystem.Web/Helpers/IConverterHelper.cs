using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Models;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Helpers
{
    public interface IConverterHelper
    {
         Task<Presentacion> ToPresentacionAsync(AddPresentacionViewModel model);
         AddPresentacionViewModel ToPresentacionViewModelAsync(Presentacion model);
         Task<Producto> ToProductoAsync(ProductoViewModel model);
         ProductoViewModel ToProductoViewModel(Producto model);
       
        Task<ProductoReal> ToProductoRealAsync(ProductoRealViewModel model);

        Task<Receta> ToRecetaAsync(RecetaViewModel mdoel);


        RecetaViewModel ToRecetaViewModel(Receta mdoel);

        Task<Pedido> ToPedidoAsync(PedidoViewModel model);
        PedidoViewModel ToPedidoViewModel(Pedido model);

        Task<EmpleadoProduccion> ToEmpleadoProduccionAsync(EmpleadoProduccionViewModel model);
        EmpleadoProduccionViewModel ToEmpleadoProduccionViewModel(EmpleadoProduccion model);

        Task<User> ToUserAsync(RegisterUserViewModel model);

        Task<Produccion> ToProduccionAsync(ProduccionViewModel model);

        InsumoUsado ToInsumoUsado(InsumoUsadoViewModel model);


        Task<Sucursal> ToSucursal(SucursalViewModel model);

        Task<Pago> ToPagoAsync(PagoViewModel model);

        Task<ProductoPago> ToProductoPagoAsync(PagoViewModel model);

    }
}