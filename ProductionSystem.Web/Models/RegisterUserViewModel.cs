

namespace ProductionSystem.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ProductionSystem.Web.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class RegisterUserViewModel
    {

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Cargo Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un cargo")]
        public int CargoId { get; set; }

        public IEnumerable<SelectListItem> Cargos;


        [Display(Name = "Nombre")]
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [MaxLength(50)]
        [Required]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [MaxLength(50)]
        [Required]
        public string ApellidoMaterno { get; set; }

        [Display(Name = "Carnet")]
        [Required]
        public int Ci { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password")]
        public string Confirm { get; set; }

    }
}
