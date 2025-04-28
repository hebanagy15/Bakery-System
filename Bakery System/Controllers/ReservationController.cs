using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bakery_System.Models;

namespace Bakery_System.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Reservation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.CreationDate = DateTime.Now;

                reservation.TableId = 1;
                reservation.CustomerId = 1;

                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction("ReservationSuccess");
            }

            return View(reservation);
        }

        public IActionResult ReservationSuccess()
        {
            return View();
        }
    }
}