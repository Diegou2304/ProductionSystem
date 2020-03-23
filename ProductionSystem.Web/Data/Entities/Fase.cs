using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class Fase
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Numero { get; set;}

        public string Descripcion { get; set; }

        public ICollection<Produccion> Producciones { get; set;}


    }
}
