using Microsoft.AspNetCore.Mvc.Rendering;
using ProductionSystem.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Models
{
    public class ProductoViewModel : Producto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Categoria Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Categoria")]

        public int CategoriaId { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "TipoProducto Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un Tipo de Producto")]

        public int TipoProductoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Sabor Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un Sabor")]

        public int SaborId { get; set;}
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Presentacion Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Presntacion")]

        public int PresentacionId { get; set; }

        public IEnumerable<SelectListItem> Categorias;

        public IEnumerable<SelectListItem> TiposProductos;

        public IEnumerable<SelectListItem> Sabores;

        public IEnumerable<SelectListItem> Presentaciones;

    }
}
