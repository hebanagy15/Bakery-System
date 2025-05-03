using Microsoft.AspNetCore.Mvc;

namespace Bakery_System.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
