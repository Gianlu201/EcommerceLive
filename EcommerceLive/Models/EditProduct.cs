using System.ComponentModel.DataAnnotations;

namespace EcommerceLive.Models
{
    public class EditProduct
    {
        public Guid? Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Il nome è obligatorio")]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "La descrizione è obligatoria")]
        public string? Description { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "La categoria è obligatoria")]
        public string? Category { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Il prezzo è obligatorio")]
        public decimal? Price { get; set; }
    }
}
