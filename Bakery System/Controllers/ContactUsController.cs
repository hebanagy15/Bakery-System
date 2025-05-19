using Bakery_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Bakery_System.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactUsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactUs/Index
        public IActionResult Index()
        {
            return View();
        }

        // POST: ContactUs/Index
        [HttpPost]
        public async Task<IActionResult> Index(string firstName, string lastName, string email, string phoneNumber, string message)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message))
            {
                ViewBag.Error = "All fields are required.";
                return View();
            }

            // Validate email
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ViewBag.Error = "Please enter a valid email address.";
                return View();
            }

            // Validate phone number (optional, but we can add a simple check)
            if (!string.IsNullOrEmpty(phoneNumber) && !Regex.IsMatch(phoneNumber, @"^\+?\d{10,15}$"))
            {
                ViewBag.Error = "Please enter a valid phone number.";
                return View();
            }

            // Create a new ContactUs object
            var contactUs = new ContactUs
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Message = message,
                CreatedAt = DateTime.Now
            };

            // Add the contact request to the database
            _context.ContactUs.Add(contactUs);
            await _context.SaveChangesAsync();

            // Display success message
            ViewBag.Success = "Your message has been sent successfully!";
            return View();
        }
    }
}
 