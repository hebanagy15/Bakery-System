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
            ViewData["Tables"] = _context.Tables.ToList();
            ViewData["Customers"] = _context.Customers.ToList();
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationDate, DurationInHours, TableId, CustomerId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.CreationDate = DateTime.Now;
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); 
            }

            ViewData["Tables"] = _context.Tables.ToList();
            ViewData["Customers"] = _context.Customers.ToList();
            return View(reservation);
        }
    }
}
