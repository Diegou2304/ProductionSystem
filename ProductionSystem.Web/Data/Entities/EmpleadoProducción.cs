using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    public class EmpleadoProducción
    {
        public int Id { get; set; }

        public string Telefono { get; set; }

        public int IdEmpleado { get; set; }

        public Persona Persona { get; set; }

        public ICollection<Produccion> Producciones {get; set;}
    }
}
