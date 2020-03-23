using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class EncargadoEmpresa
    {
        [ForeignKey("Empresa")]
        public int Id { get; set; }

        public string Telefono { get; set; }

       

        public Persona Persona { get; set; }

        public Empresa Empresa { get; set; }
    
    }
}
