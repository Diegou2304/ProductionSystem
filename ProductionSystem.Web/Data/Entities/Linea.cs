

namespace ProductionSystem.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Linea : IEntity
    {

        public int Id { get; set; }

        [Display(Name="Nombre")]
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "# Categorias")]
        public int NumeroCategorias { get { return this.Categorias == null ? 0 : this.Categorias.Count; } }
        public ICollection<Categoria> Categorias { get; set; }
    }
}
