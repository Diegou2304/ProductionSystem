using ProductionSystem.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Models
{
    public class EncargadoViewModel 
    {
        public int EmpresaId { get; set; }

        public string NombreEmpresa { get; set; }

        public EncargadoEmpresa EncargadoEmpresa { get; set; }


    }
}
