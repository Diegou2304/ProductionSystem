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

    }
}