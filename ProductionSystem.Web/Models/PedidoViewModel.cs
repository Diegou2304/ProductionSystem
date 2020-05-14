using Microsoft.AspNetCore.Mvc.Rendering;
using ProductionSystem.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Models
{
    public class PedidoViewModel : Pedido
    {


        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "ProductoReal Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un Producto Real")]

        public int ProductoRealId { get; set; }


        public IEnumerable<SelectListItem> ProductosReales;
    }
}
