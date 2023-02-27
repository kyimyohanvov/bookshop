using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShop.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            IEnumerable<Models.Category> objCategoryList = _db.Categories;

            ViewData["categories"] = objCategoryList;

            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Models.Category obj)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();

                TempData["message"] = "Create Category Success";
                return RedirectToAction("Index");
            }

            IEnumerable<Models.Category> objCategoryList = _db.Categories;

            ViewData["categories"] = objCategoryList;
            

            return View("Index",obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _db.Categories.Find(id);

            if(category == null)
            {
                return NotFound();
            }

            IEnumerable<Models.Category> objCategoryList = _db.Categories;

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
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["message"] = "Edit Category Success";
                return RedirectToAction("Index");
            }

            IEnumerable<Models.Category> objCategoryList = _db.Categories;

            ViewData["categories"] = objCategoryList;

            return View("Index", obj);

        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var category = _db.Categories.Find(id);

            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                TempData["message"] = "Delete Category Success";
            }

            return RedirectToAction("Index");
        }
    }
}

