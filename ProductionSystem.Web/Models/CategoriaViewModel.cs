
namespace ProductionSystem.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CategoriaViewModel
    {
        public int PoseedorId { get; set; }

        public int CategoriaId { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }
    }
}
