using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class ProductoPago: IEntity
    { 

        public int Id { get; set; }

        public Decimal Monto { get; set; }

        public int UnidadesPagadas { get; set; }

        public Pago Pago { get; set; }

        public ProductoReal ProductoReal { get; set; }
    }
}
