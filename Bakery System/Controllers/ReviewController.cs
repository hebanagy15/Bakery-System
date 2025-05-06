using Bakery_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Bakery_System.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Review/Contact
        public IActionResult Contact()
        {
         
            ViewBag.BakeryItems = _context.BakeryItems.ToList();
            return View();
        }

        // POST: Review/Contact
        [HttpPost]
        public async Task<IActionResult> Contact(string email, string message, int rating, int bakeryItemId)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message))
            {
                ViewBag.Error = "Email and Message are required.";
                ViewBag.BakeryItems = _context.BakeryItems.ToList();
                return View();
            }

            
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ViewBag.Error = "Please enter a valid email address.";
                ViewBag.BakeryItems = _context.BakeryItems.ToList();
                return View();
            }

            if (rating < 1 || rating > 5)
            {
                ViewBag.Error = "Rating must be between 1 and 5.";
                ViewBag.BakeryItems = _context.BakeryItems.ToList();
                return View();
            }

           
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
            if (customer == null)
            {
                ViewBag.Error = "Email is not registered.";
                ViewBag.BakeryItems = _context.BakeryItems.ToList();
                return View();
            }

           
            var review = new Review
            {
                CustomerId = customer.ID,
                BakeryItemId = bakeryItemId,
                Comment = message,
                Rating = rating
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            ViewBag.Success = "Thanks for your feedback!";
            ViewBag.BakeryItems = _context.BakeryItems.ToList();
            return View();
        }
    }
}
