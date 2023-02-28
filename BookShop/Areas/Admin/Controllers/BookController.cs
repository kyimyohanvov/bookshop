using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models;
using BookShop.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShop.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            IEnumerable<Models.Book> objBookList = _db.Book.GetAll();

            return View(objBookList);
        }

        public IActionResult Create()
        {
            Book book = new();
            IEnumerable<SelectListItem> CategoryList = _db.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
            );

            ViewBag.CategoryList = CategoryList;

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Book obj, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                if(file != null)
                {
                    string rootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(rootPath, @"images/books");
                    var extension = Path.GetExtension(file.FileName);
                    
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }

                    obj.ImageUrl = @"images/books/" + fileName + extension;
                }
                


                _db.Book.Add(obj);
                _db.Save();

                TempData["message"] = "Create Book Success";
                return RedirectToAction("Index");
            }

            IEnumerable<SelectListItem> CategoryList = _db.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
            );

            return View("Create",obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var book = _db.Book.GetFirstOrDefault(cat => cat.Id == id);

            if(book == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> CategoryList = _db.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
            );

            ViewBag.CategoryList = CategoryList;

            return View(book);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Book obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string rootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(rootPath, @"images/books");
                    var extension = Path.GetExtension(file.FileName);

                    if(obj.ImageUrl != null)
                    {
                        string oldPath = Path.Combine(rootPath, obj.ImageUrl);
                        if(System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }

                    obj.ImageUrl = @"images/books/" + fileName + extension;
                }
                _db.Book.Update(obj);
                _db.Save();
                TempData["message"] = "Edit Book Success";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Edit", obj.Id);

        }

        //Api for datatable
        //----------
        [HttpGet]
        public IActionResult GetAll()
        {
            var bookList = _db.Book.GetAll(includeProperties: "Category");
            return Json(new
            {
                data = bookList
            });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var book = _db.Book.GetFirstOrDefault(cat => cat.Id == id);

            string oldPath = Path.Combine(_webHostEnvironment.WebRootPath, book.ImageUrl);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }

            if (book != null)
            {
                _db.Book.Remove(book);
                _db.Save();
                TempData["message"] = "Delete Book Success";
            }

            return Json(new { success = true, message = "Success Book Delete" });
        }
    }
}

