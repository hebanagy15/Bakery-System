using Microsoft.AspNetCore.Mvc;
using Bakery_System.Models;
using Bakery_System.Models.ViewModels; // Add this namespace
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Bakery_System.Controllers
{
    public class SignInController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SignInController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var customer = _context.Customers.SingleOrDefault(c => c.Email == model.Email);

                if (customer == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    return View("Index", model); // Return the model to show errors
                }

                string hashedPassword = HashPassword(model.Password);
                if (customer.Password != hashedPassword)
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    return View("Index", model); // Return the model to show errors
                }

         
                return RedirectToAction("Index", "Menu");
            }

            // If ModelState is not valid, return the view with validation errors
            return View("Index", model);
        }

        private string HashPassword(string password)
        {
            // *** IMPORTANT SECURITY NOTICE ***
            // Replace with your actual secure hashing logic
            return password;
        }
    }
}