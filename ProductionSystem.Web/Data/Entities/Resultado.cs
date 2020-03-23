using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class Resultado
    {

        [ForeignKey("Produccion")]
        public int Id { get; set; }

        public int Cantidad { get; set; }

        public string Observaciones { get; set; }

        public Produccion Produccion { get; set;}

    }
}
