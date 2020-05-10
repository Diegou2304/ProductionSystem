

namespace ProductionSystem.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Producto:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50, ErrorMessage = " El campo no puede tener mas caracteres")]
        public string Nombre { get; set; }

        public Categoria Categoria { get; set; }

        public TipoProducto TipoProducto { get; set;}

        public Sabor Sabor { get; set; }
        
        public Presentacion Presentacion { get; set; }

        public ICollection<ProductoReal> ProductosReales { get; set; }

    }
}
