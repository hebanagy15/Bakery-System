﻿using Microsoft.AspNetCore.Mvc;

namespace Bakery_System.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
