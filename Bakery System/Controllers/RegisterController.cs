using Bakery_System.Models; // Replace with your actual namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bakery_System.Controllers // Replace with your actual namespace
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context; // Replace with your actual DbContext

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Register
        public IActionResult Index()
        {
            return View(); 
        }

        // POST: /Register
        [HttpPost]
        public async Task<IActionResult> Register(Customer customer)
        {
            // Check if the email is already registered
            if (await _context.Customers.AnyAsync(c => c.Email == customer.Email))
            {
                ModelState.AddModelError("Email", "This email address is already registered.");
                return View("Index");
            }

            if (ModelState.IsValid)
            {
                customer.Password = HashPassword(customer.Password);
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "SignIn"); // Redirect to the Index action in SignInController
            }

            return View("Index");
        }
        private string HashPassword(string password)
        {
            // Replace this with your actual secure password hashing implementation
            return password; // Placeholder - INSECURE
        }
    }
}