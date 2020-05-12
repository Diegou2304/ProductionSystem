using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ProductionSystem.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboEnvases();
        IEnumerable<SelectListItem> GetComboEtiqueta();

        IEnumerable<SelectListItem> GetComboPresentaciones();
        IEnumerable<SelectListItem> GetComboCategorias();

        IEnumerable<SelectListItem> GetComboSabores();
        IEnumerable<SelectListItem> GetComboTipoProducto();


        IEnumerable<SelectListItem> GetComboProductos();

        IEnumerable<SelectListItem> GetComboInsumo();

        IEnumerable<SelectListItem> GetComboProductosReales();

    }
}