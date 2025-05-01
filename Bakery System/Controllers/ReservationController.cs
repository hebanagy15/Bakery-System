using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bakery_System.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery_System.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

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

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View(reservation);
        }

        public IActionResult ReservationSuccess()
        {
            return View();
        }
    }
}
