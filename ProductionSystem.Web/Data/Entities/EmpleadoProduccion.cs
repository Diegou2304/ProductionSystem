

namespace ProductionSystem.Web.Data.Entities
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmpleadoProduccion : Persona
    {

        [Required]
        [MaxLength(50, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string Cargo { get; set; }

        [Required]
        public int Telefono { get; set; }

        public ICollection<Produccion> Producciones {get; set;}
    }
}
