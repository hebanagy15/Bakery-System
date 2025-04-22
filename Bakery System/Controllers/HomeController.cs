using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bakery_System.Models;
using Microsoft.EntityFrameworkCore;
using Bakery_System.ViewModels;

namespace Bakery_System.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }


    public async Task<IActionResult> Index()
     {
            var mostPopular = await _context.BakeryItems
                .OrderByDescending(p => p.SalesCount) 
                .Take(5)
                .ToListAsync();

            var offers = await _context.BakeryItems
                .Where(p => p.Discount > 0)
                .ToListAsync();

            var categories = await _context.Categories.ToListAsync();

        var viewModel = new HomeViewModel
        {
            MostPopular = mostPopular,
            Offers = offers,
            Categories = categories
        };

        return View(viewModel);
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
