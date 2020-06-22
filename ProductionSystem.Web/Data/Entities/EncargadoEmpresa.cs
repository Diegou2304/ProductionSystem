using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class EncargadoEmpresa
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

        [Display(Name = "Carnet")]
        [Required]
        public int Ci { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string Direccion { get; set; }




        [Required]
        public string Telefono { get; set; }

       
        public Empresa Empresa { get; set; }
    
    }
}
