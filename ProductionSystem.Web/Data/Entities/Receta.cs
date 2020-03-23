using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class Receta
    {
        public int Id { get; set; }

        public decimal Porcentaje { get; set; }


        public Insumo Insumo { get; set; }

        public ProductoReal ProductoReal { get; set; }



    }
}
