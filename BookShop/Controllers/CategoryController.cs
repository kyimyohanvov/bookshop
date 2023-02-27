using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShop.Controllers
{
    public class CategoryController : Controller
    {
        public readonly IUnitOfWork _db;

        public CategoryController(IUnitOfWork db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            IEnumerable<Models.Category> objCategoryList = _db.Category.GetAll();

            ViewData["categories"] = objCategoryList;

            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Models.Category obj)
        {
            if(ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.Save();

                TempData["message"] = "Create Category Success";
                return RedirectToAction("Index");
            }

            IEnumerable<Models.Category> objCategoryList = _db.Category.GetAll();

            ViewData["categories"] = objCategoryList;
            

            return View("Index",obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _db.Category.GetFirstOrDefault(cat => cat.Id == id);

            if(category == null)
            {
                return NotFound();
            }

            IEnumerable<Models.Category> objCategoryList = _db.Category.GetAll();

            ViewData["categories"] = objCategoryList;
            ViewData["action"] = "edit";

            return View("Index", category);

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.Save();
                TempData["message"] = "Edit Category Success";
                return RedirectToAction("Index");
            }

            IEnumerable<Models.Category> objCategoryList = _db.Category.GetAll();

            ViewData["categories"] = objCategoryList;

            return View("Index", obj);

        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var category = _db.Category.GetFirstOrDefault(cat => cat.Id == id);

            if (category != null)
            {
                _db.Category.Remove(category);
                _db.Save();
                TempData["message"] = "Delete Category Success";
            }

            return RedirectToAction("Index");
        }
    }
}

