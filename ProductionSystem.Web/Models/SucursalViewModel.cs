using Microsoft.AspNetCore.Mvc.Rendering;
using ProductionSystem.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Models
{
    public class SucursalViewModel : Sucursal
    {


        public int EmpresaId { get; set; }

        public string NombreEmpresa { get; set; }
        

    }
}
