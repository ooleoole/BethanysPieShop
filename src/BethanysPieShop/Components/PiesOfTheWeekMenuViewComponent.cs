using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Components
{
    public class PiesOfTheWeekMenuViewComponent : ViewComponent
    {
        private readonly IPieRepository _pieRepository;

        public PiesOfTheWeekMenuViewComponent(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IViewComponentResult Invoke()
        {
            var pies = _pieRepository.PiesOfTheWeek;
            return View("PiesOfTheWeekMenu",pies);
        }
    }
}