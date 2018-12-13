using shop.Data.Interfaces;
using shop.Data.Models;
using shop.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Controllers
{
    public class ScategoryController : Controller
    {
        private readonly IScategoryRepository _scategoryRepository;
        ScategoryViewModel scategoryViewModel = new ScategoryViewModel();

        public ScategoryController(IScategoryRepository scategoryRepository)
        {
            _scategoryRepository = scategoryRepository;
        }

        public IActionResult Index()
        {
            scategoryViewModel.ScategoryList = new List<Scategory>();
            scategoryViewModel.ScategoryList = _scategoryRepository.GetAll().ToList();

            scategoryViewModel.Scategory = new Scategory();

            return View(scategoryViewModel);
        }

        public IActionResult Update(int ScategoryId)
        {

            var scategory = _scategoryRepository.GetById(ScategoryId);

            if (scategory == null) return NotFound();

            return PartialView("_Edit", scategory);
        }

        [HttpPost]
        public IActionResult Update(Scategory scategory)
        {
            _scategoryRepository.Update(scategory);
            scategoryViewModel.ScategoryList = new List<Scategory>();
            scategoryViewModel.ScategoryList = _scategoryRepository.GetAll().ToList();

            scategoryViewModel.Scategory = new Scategory();
            return PartialView("_List", scategoryViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Scategory scategory)
        {
            _scategoryRepository.Create(scategory);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int ScategoryId)
       {
            var scategory = _scategoryRepository.GetById(ScategoryId);

            _scategoryRepository.Delete(scategory);
            return PartialView("_List", scategoryViewModel);
        }
    }
}
