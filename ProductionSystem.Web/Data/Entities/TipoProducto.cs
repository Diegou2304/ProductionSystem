using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductionSystem.Web.Data.Entities
{
    public class TipoProducto
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
