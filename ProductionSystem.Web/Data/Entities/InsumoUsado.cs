using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class InsumoUsado : IEntity
    {

        public int Id { get; set; }

        public decimal CantidadUsada { get; set; }

        public Insumo Insumo { get; set; }

        public Produccion Produccion { get; set; }

    }
}
