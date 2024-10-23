using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BalMutfak.Models;
using System.Net;
using System.Net.Mail;
using BalMutfak.ViewModels;

namespace BalMutfak.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var viewModel = new HomeViewModel
        {
            Products = _context.Products.ToList(), // Ürünleri çekiyoruz
            Customers = _context.Customers.ToList(), // Müşterileri çekiyoruz
        };
        return View(viewModel);
    }

    public IActionResult Catalog()
    {
        var products = _context.Products.ToList(); // Ürünleri veri tabanından çekiyoruz
        return View("_Catalog", products);
    }

    public IActionResult UserComments()
    {
        var customers = _context.Customers.ToList();
        return View("_UserComments", customers);
    }

    public IActionResult SearchResult(string searchTerm)
    {
        var products = _context.Products
            .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
            .ToList();

        ViewBag.SearchTerm = searchTerm;

        return View(products);
    }


}
