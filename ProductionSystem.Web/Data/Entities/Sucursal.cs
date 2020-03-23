using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class Sucursal
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Dirección { get; set; }


        public string Encargado { get; set; }


        

        public Empresa Empresa { get; set; }



    }
}
