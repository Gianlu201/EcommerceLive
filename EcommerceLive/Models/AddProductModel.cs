using System.ComponentModel.DataAnnotations;

namespace EcommerceLive.Models
{
    public class AddProductModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Il nome è obligatorio")]
        [StringLength(20, ErrorMessage = "max 20 chars", MinimumLength = 2)]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "La descrizione è obligatoria")]
        [StringLength(2000, ErrorMessage = "max 2000 chars", MinimumLength = 10)]
        public string? Description { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "La categoria è obligatoria")]
        public string? Category { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Il prezzo è obligatorio")]
        [Range(0.01, 1000000, ErrorMessage = "Range from 0,01 and 1000000")]
        public decimal? Price { get; set; }
    }
}
