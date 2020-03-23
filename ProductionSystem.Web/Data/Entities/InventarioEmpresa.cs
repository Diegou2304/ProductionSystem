using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class InventarioEmpresa
    {
        public int Id { get; set; }


        public int Stock { get; set; }

        public Empresa Empresa { get; set; }

        public ProductoReal ProductoReal {get; set;}
    }
}
