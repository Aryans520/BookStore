using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private BookStoreContext _context;
    public HomeController(ILogger<HomeController> logger, BookStoreContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }
    public IActionResult Detail(int id)
    {
        var product = _context.Products
            .Include(p => p.Item)
            .SingleOrDefault(p => p.Id==id);
        if (product == null) 
        {
            return NotFound();
        
        }
        var categories = _context.Products
            .Where(P => P.Id == id)
            .SelectMany(c => c.CategoryToProducts)
            .Select(ca => ca.Category)
            .ToList();

        var vm = new DetailsViewModel()
        {
            Product = product,
            Categories = categories
        };

        return View(vm);
    }
    public IActionResult AddToCart(int itemId)
    {
        return null;
    }
    public IActionResult ContactUs()
    {
        return View();
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
