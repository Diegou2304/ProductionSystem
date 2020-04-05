using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ProductionSystem.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboEnvases();
        IEnumerable<SelectListItem> GetComboEtiqueta();
    }
}