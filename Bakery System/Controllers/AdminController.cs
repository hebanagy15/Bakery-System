using Bakery_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using Bakery_System.ViewModels;

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
            var categories = _context.Categories.ToList();

            var viewModel = new ProductCategoryViewModel
            {
                BakeryItems = bakeryItems,
                Categories = categories
            };

            return View(viewModel);

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

        public IActionResult EditBakeryItems(int id)
        {
            var product = _context.BakeryItems.Find(id);

            if(product == null)
            {
                return Content("Invalid Item Id");
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult EditBakeryItems(BakeryItem Item)
        {
            _context.BakeryItems.Update(Item);
            var res = _context.SaveChanges();

            if(res > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(Item);
        }

        [HttpPost]
        public IActionResult deleteBakeryItems(int id)      
        {
            var product = _context.BakeryItems.Find(id);

            if (product == null)
            {
                return Content("Item not found");
            }
            _context.BakeryItems.Remove(product);             // Hard Delete
            var res = _context.SaveChanges();

            if (res > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return Content("Deletion Failed");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
