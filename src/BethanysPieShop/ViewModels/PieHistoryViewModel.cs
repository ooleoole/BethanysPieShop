using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class PieHistoryViewModel
    {

        public int PieId { get; set; }
        public string Name { get; set; }
        public string PieHistory { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }

        public PieHistoryViewModel(Pie pie)
        {
            PieId = pie.PieId;
            Name = pie.Name;
            ImageUrl = pie.ImageUrl;
            ImageThumbnailUrl = pie.ImageThumbnailUrl;
            PieHistory = "Here is teh pie history";
        }
        
    }
}
