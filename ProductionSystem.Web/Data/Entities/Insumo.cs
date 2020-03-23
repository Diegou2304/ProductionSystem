using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class Insumo
    {


        public int Id { get; set; }

        public string Nombre { get; set; }

        public Decimal Stock { get; set; }

        public bool IsRawProduct { get; set;}

        public ICollection<Receta> Recetas { get; set; }

        public ICollection<Produccion> Producciones { get; set; }

        public ICollection<InsumoUsado> InsumosUsados { get; set; }


    }
}
