using System.ComponentModel.DataAnnotations;

namespace BethanysPieShop.ViewModels
{
    public class AddPieViewModel
    {
        [Required, MinLength(1, ErrorMessage = "the name has to contain atleast 1 char"), MaxLength(19, ErrorMessage = "the name cannot pe longer then 19")]
        public string PieName { get; set; }
        [Required]
        public string Category { get; set; }
        public bool IsAdded { get; set; }

    }
}
