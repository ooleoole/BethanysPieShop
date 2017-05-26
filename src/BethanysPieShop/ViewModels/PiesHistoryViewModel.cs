using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class PiesHistoryViewModel
    {
        public List<PieHistoryViewModel> PieHistoryViewModels { get; set; }

        public PiesHistoryViewModel(List<Pie> pies)
        {
            PieHistoryViewModels = new List<PieHistoryViewModel>();
            foreach (var pie in pies)
                PieHistoryViewModels.Add(new PieHistoryViewModel(pie));
        }
    }
}
