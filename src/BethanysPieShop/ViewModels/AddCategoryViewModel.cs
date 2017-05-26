using System.ComponentModel.DataAnnotations;

namespace BethanysPieShop.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required,MinLength(1) ,MaxLength(19)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        
    }
}