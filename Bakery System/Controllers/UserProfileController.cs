using Microsoft.AspNetCore.Mvc;

namespace Bakery_System.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
