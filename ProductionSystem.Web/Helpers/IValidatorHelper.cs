namespace ProductionSystem.Web.Helpers
{
    public interface IValidatorHelper
    {
        bool IsEtiquetaUsed(int? id);
        bool IsPedidoPendiente(int? id);
    }
}