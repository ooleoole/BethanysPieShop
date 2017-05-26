using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace BethanysPieShop.Controllers
{

    public class AdminController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AdminController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult AddPie()
        {
            return View("AddPie");
        }

        [HttpPost]
        public IActionResult AddPie(AddPieViewModel model)
        {
            var category = _categoryRepository.Categories.FirstOrDefault(c => string.Equals(
                c.CategoryName, model.Category,
                StringComparison.CurrentCultureIgnoreCase));

            if (category == null)
                ModelState.AddModelError("", "Invalid Category");
            if (ModelState.IsValid)
            {
                var pie = MappAddPieViewModelToPie(model, category);
                _pieRepository.AddPie(pie);
                ViewBag.IsAdded = true;
                ViewBag.AddedPieName = model.PieName;
                ModelState.Clear();
                return View();
            }
            ViewBag.IsAdded = false;
            return View(model);
        }
        [HttpGet]
        public IActionResult AddPieDropDown()
        {
            var categories = _categoryRepository.Categories.ToList();
            var model = new AddPieDropDownViewModel { Categories = categories };
            return View("AddPieDropDown", model);
        }
        [HttpPost]
        public IActionResult AddPieDropDown(AddPieDropDownViewModel model)
        {
            var categories = _categoryRepository.Categories.ToList();
            model.Categories = categories;
            if (ModelState.IsValid)
            {
                var pie = MappAddPieViewModelToPie(model);
                _pieRepository.AddPie(pie);
                ViewBag.IsAdded = true;
                ViewBag.AddedPieName = model.PieName;
                ModelState.Clear();
                model.PieName = string.Empty;
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePrice()
        {
            var pies = _pieRepository.Pies.ToList();
            var model = new ChangePiePriceViewModel
            {
                Pies = pies,
            };
            return View("ChangePiePrice", model);
        }

        [HttpPost]
        public IActionResult ChangePrice(ChangePiePriceViewModel model)
        {
            var pies = _pieRepository.Pies.ToList();
            model.Pies = pies;
            if (ModelState.IsValid)
            {
                var pieToUpdate = _pieRepository.GetPieById(model.PieId);
                pieToUpdate.Price = model.Price;
                _pieRepository.Update(pieToUpdate);
                ModelState.Clear();
                ViewBag.IsAdded = true;
                ViewBag.PieName = pieToUpdate.Name;
                model.Price = 0;
                return View("ChangePiePrice", model);
            }

            return View("ChangePiePrice", model);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View("AddCategory");
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel model)
        {
            if (model.CategoryName != null)
                model.CategoryName = model.CategoryName.Replace(" ", "");


            if (_categoryRepository.Categories.Any(c => string.Equals(c.CategoryName,
                model.CategoryName,
                StringComparison.CurrentCultureIgnoreCase)))
                ModelState.AddModelError("", $"Category {model.CategoryName} already exists in database");

            if (ModelState.IsValid)
            {
                var cat = MappAddCategoryViewModelToCategory(model);
                _categoryRepository.Add(cat);
                ViewBag.IsAdded = true;
                ViewBag.AddedCategoryName = model.CategoryName;
                ModelState.Clear();
                return View("AddCategory");
            }
            return View("AddCategory");
        }


        private Category MappAddCategoryViewModelToCategory(AddCategoryViewModel model)
        {
            return new Category
            {
                CategoryName = model.CategoryName,
                Description = model.Description
            };
        }

        private Pie MappAddPieViewModelToPie(AddPieViewModel model, Category category)
        {
            return new Pie
            {
                CategoryId = category.CategoryId,
                Name = model.PieName,
            };
        }
        private Pie MappAddPieViewModelToPie(AddPieDropDownViewModel model)
        {
            return new Pie
            {
                CategoryId = model.CategoryId,
                Name = model.PieName,
            };
        }
    }


}
