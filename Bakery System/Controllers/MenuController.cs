using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bakery_System.Controllers
{
   

    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Menu/
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        // GET: /Menu/Products/{categoryId}
        public async Task<IActionResult> BakeryItems(int categoryId)
        {
            var products = await _context.BakeryItems
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();

            var category = await _context.Categories.FindAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            ViewBag.CategoryName = category.Name;
            return View(products);
        }
    }
}
