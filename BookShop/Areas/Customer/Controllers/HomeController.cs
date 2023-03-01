using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookShop.Models;
using BookShop.Repositories.IRepository;

namespace BookShop.Controllers;

[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _db;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _db = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Book> bookList = _db.Book.GetAll(includeProperties: "Category");
        return View(bookList);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

