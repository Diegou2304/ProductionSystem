using ProductionSystem.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Models
{
    public class PagoDetails
    {


        public Pago empresa { get; set; }

        public Pago pago { get; set; }

        public Pago productopago { get; set; }

        public Pago productoreal { get; set; }


    }
}
