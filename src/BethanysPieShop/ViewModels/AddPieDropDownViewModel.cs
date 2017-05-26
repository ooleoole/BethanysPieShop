using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class AddPieDropDownViewModel
    {

        [Required, MinLength(1, ErrorMessage = "the name has to contain atleast 1 char"), MaxLength(19, ErrorMessage = "the name cannot pe longer then 19")]
        public string PieName { get; set; }
        [Required, Display(Name = "Category")]
        public int CategoryId { get; set; }
        public bool IsAdded { get; set; }
        public List<Category> Categories { get; set; }
    }
}
