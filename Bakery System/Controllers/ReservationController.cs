using Bakery_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization; 
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

        // GET: Reservation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DateTime date, string time, int guests)
        {
            if (ModelState.IsValid)
            {
                // Parse the time string into a DateTime object
                if (DateTime.TryParseExact(time, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedTime))
                {
                    var reservation = new Reservation
                    {
                        ReservationDate = date.Date + parsedTime.TimeOfDay,
                        TableId = 1,
                        CustomerId = 1,
                        CreationDate = DateTime.Now,
                        DurationInHours = guests <= 2 ? 1 : (guests <= 4 ? 2 : 3),
                        Time = time,
                        Guests = guests

                    };

                    _context.Add(reservation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // If parsing fails, add an error to ModelState
                    ModelState.AddModelError("Time", "ERROR ");
                }
            }

            return View();
        }
    }
}