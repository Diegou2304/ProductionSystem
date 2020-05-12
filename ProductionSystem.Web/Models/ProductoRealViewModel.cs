using Microsoft.AspNetCore.Mvc.Rendering;
using ProductionSystem.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Models
{
    public class ProductoRealViewModel: ProductoReal
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Producto Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un Producto")]
        public int ProductoId { get; set; }

        public IEnumerable<SelectListItem> Productos;

    }
}
