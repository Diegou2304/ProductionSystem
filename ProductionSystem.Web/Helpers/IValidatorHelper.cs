using ProductionSystem.Web.Models;

namespace ProductionSystem.Web.Helpers
{
    public interface IValidatorHelper
    {
        bool IsEtiquetaUsed(int? id);
        bool IsPedidoPendiente(int? id);

        bool IsEnoughProduct(int? id, int cantidad);
        bool ProductStorageExists(PagoViewModel model);
    }
}