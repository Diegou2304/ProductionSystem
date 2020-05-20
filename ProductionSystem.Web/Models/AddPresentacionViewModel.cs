using Microsoft.AspNetCore.Mvc.Rendering;
using ProductionSystem.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Models
{
    public class AddPresentacionViewModel : Presentacion
    {


        //Necesitamos el id de la etiqueta y el envase para hacer la correcta inserción


        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Etiqueta Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una etiqueta")]     
        public int EtiquetaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Etiqueta Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una etiqueta")]
        public int EnvaseId { get; set; }
       

        public int FormerEtiquetaId { get; set; }
        //Necesitamos los respectivos collections para llenar el combo box

        public IEnumerable<SelectListItem> Envases;

        public IEnumerable<SelectListItem> Etiquetas;

    }
}
