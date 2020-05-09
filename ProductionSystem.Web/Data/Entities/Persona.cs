

namespace ProductionSystem.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Persona:IEntity 
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string ApellidoPaterno { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string ApellidoMaterno { get; set; }

        [Required]
        [Display(Name = "CI")]
        public string  CI{ get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string Direccion { get; set; }

    }
}
