using Bakery_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bakery_System.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewBag.BakeryItems = new SelectList(_context.BakeryItems, "ID", "Name");
            ViewBag.Customers = new SelectList(_context.Customers, "ID", "Name");

            var order = new Order
            {
                OrderDate = DateTime.Now,
                OrderItems = new List<OrderItem> { new OrderItem() }
            };

            return View(order);
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {


                var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                order.CustomerId = 1;
                order.Status = "Pending";
                order.TotalPrice = 0;
                foreach (var item in order.OrderItems)
                {
                    var bakeryItem = _context.BakeryItems.FirstOrDefault(b => b.ID == item.BakeryItemId);
                    if (bakeryItem != null)
                    {
                        order.TotalPrice += bakeryItem.Price * item.Quantity;
                    }
                }

                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.BakeryItems = new SelectList(_context.BakeryItems, "ID", "Name");
            ViewBag.Customers = new SelectList(_context.Customers, "ID", "Name");
            return View(order);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}