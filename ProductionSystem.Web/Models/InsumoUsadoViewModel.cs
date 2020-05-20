

namespace ProductionSystem.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ProductionSystem.Web.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class InsumoUsadoViewModel : InsumoUsado
    {

        public int ProduccionId { get; set; }

        public int InsumoId { get; set; }

        public IEnumerable<SelectListItem> Insumos;


    }
}
