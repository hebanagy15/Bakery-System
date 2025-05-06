using Bakery_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;

namespace Bakery_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        ApplicationDbContext _context;

        public AdminController(ILogger<AdminController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()               // Product page
        {
            var bakeryItems = _context.BakeryItems.ToList();

            return View(bakeryItems);
        }

        [HttpGet]
        public IActionResult AddItem()               // add product view
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(BakeryItem product)               // add product to DB
        {
            _context.BakeryItems.Add(product);             // save in dbcontext
            var res = _context.SaveChanges();

            if (res > 0)                            // No Of Affected rows
            {

                return RedirectToAction("Index");                           // Return to index again
            }

            return View(product);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
