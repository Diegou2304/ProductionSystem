using Microsoft.AspNetCore.Mvc.Rendering;
using ProductionSystem.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Models
{
    public class PagoViewModel : Pago
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Empresa Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Empresa")]
        public int EmpresaId { get; set; }

        public IEnumerable<SelectListItem> Empresas;


        public int MontoPago { get; set; }

        public int UnidadesPagadas { get; set; }

        public int IdUltimoPago { get; set; }
        public int IdProductoFinal { get; set; }

     

        public IEnumerable<SelectListItem> ProductosFinales;



    }
}
