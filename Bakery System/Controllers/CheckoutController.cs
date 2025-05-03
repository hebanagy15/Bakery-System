using Microsoft.AspNetCore.Mvc;
using Bakery_System.Models;
using Bakery_System.ViewModels;
using System.Linq;

namespace Bakery_System.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new CheckoutViewModel
            {
                SelectedProducts = _context.BakeryItems
                    .Where(b => b.QuantityInStock > 0)
                    .Select(b => new ProductSelection
                    {
                        BakeryItemId = b.ID,
                        BakeryItemName = b.Name,
                        Price = b.Price,
                        Quantity = 0
                    }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(CheckoutViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var order = new Order
            {
                Status = "Pending",
                TotalPrice = viewModel.SelectedProducts
                    .Where(p => p.Quantity > 0)
                    .Sum(p => p.Price * p.Quantity),
                PaymentMethod = viewModel.PaymentMethod,
                CustomerId = 1,
                OrderItems = viewModel.SelectedProducts
                    .Where(p => p.Quantity > 0)
                    .Select(p => new OrderItem
                    {
                        BakeryItemId = p.BakeryItemId,
                        Quantity = p.Quantity
                    }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
