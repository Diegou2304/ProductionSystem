

namespace ProductionSystem.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ProductionSystem.Web.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmpleadoProduccionViewModel : EmpleadoProduccion
    {

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fase Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Fase")]
        public int FaseId { get; set; }


        public IEnumerable<SelectListItem> Fases;

    }
}
