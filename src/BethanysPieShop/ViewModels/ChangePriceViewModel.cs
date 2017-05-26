using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class ChangePiePriceViewModel
    {
        public int PieId { get; set; }
        [Required,DataType(DataType.Currency), Display(Name = "Change price"), Range(1,999)]
        public int Price { get; set; }
        public List<Pie> Pies { get; set; }
    }
}
