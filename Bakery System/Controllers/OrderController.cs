using Bakery_System.Models;
using Bakery_System.ViewModels;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Bakery_System.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
       

        public OrderController(ApplicationDbContext context )
        {
            _context = context;
         
        }

        

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            
                var product = _context.BakeryItems.FirstOrDefault(p => p.ID == productId);
                if (product == null)
                {
                    return NotFound();
                }


            ViewBag.ProductName = product.Name;
            ViewBag.Price = product.Price;
            ViewBag.Quantity = quantity;




            return View(); 
        }



        [HttpPost]
        public IActionResult Create(OrderViewModel model , decimal Price)
        {
            if (!ModelState.IsValid)
                return View(model);

            string fullName = $"{model.FirstName} {model.LastName}";

            
            var customer = _context.Customers.FirstOrDefault(c => c.FullName == fullName && c.Email == model.Email);

            if (customer == null)
            {
                ModelState.AddModelError("", "Customer not found.");
                return View("AddToCart", model);

            }

            var order = new Order
            {
                CustomerId = customer.ID,
                PaymentMethod = model.PaymentMethod,
                Status = model.Status,
                TotalPrice = Price,
                OrderDate = DateTime.Now,
                
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Index","Menu"); 
        }

       
    }
}