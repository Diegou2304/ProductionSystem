

namespace ProductionSystem.Web.Data.Entities
{

    using System.ComponentModel.DataAnnotations;


    public class Categoria : IEntity
    {
        
        public int Id { get; set; }
                
        [Display(Name ="Nombre")]
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string Nombre { get; set; }
  
    }
}
