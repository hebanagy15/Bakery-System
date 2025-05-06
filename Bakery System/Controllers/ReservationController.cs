using Bakery_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bakery_System.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservation/Create
        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Tables = _context.Tables.ToList();
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            // Debugging - Optional
            Console.WriteLine("---- Incoming Reservation Data ----");
            Console.WriteLine($"CustomerId: {reservation.CustomerId}");
            Console.WriteLine($"TableId: {reservation.TableId}");
            Console.WriteLine($"ReservationDate: {reservation.ReservationDate}");
            Console.WriteLine($"Duration: {reservation.DurationInHours}");

            if (!ModelState.IsValid)
            {
                ViewBag.Customers = _context.Customers.ToList();
                ViewBag.Tables = _context.Tables.ToList();
                return View(reservation);
            }

            reservation.CreationDate = DateTime.Now;

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Reservation created successfully!";
            return RedirectToAction("Create");
        }
    }
}
