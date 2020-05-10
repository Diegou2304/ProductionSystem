using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class EncargadoEmpresa : Persona
    {
        [Required]
        public string Telefono { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }

        public Empresa Empresa { get; set; }
    
    }
}
