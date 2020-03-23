using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class Pago
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public Decimal MontoTotal { get; set; }
        
        public DateTime Fecha { get; set; }

        public Empresa Empresa { get; set; }

        public ICollection<ProductoPago> ProductoPago { get; set; }
    }
}
