

namespace ProductionSystem.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

    public class Produccion : IEntity
    {

        public int Id { get; set; }

        //Esto Deberia de ponerse automatico
        [Display(Name = "Fecha de Produccion")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaProduccion { get; set; }

        public ICollection<InsumoUsado> InsumosUsados { get; set; }

        public Pedido Pedido { get; set; }

        public Fase Fase { get; set; }

        public Resultado Resultado { get; set; }

        public Deshecho Deshecho {get; set;}

        public EmpleadoProduccion EmpleadoProducción { get; set; }
                  

    }
}
