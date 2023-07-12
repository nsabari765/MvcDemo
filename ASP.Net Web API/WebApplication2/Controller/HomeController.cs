using Microsoft.AspNetCore.Mvc;

namespace WebApplication2
{
    public class HomeController : Controller
    {
        public IActionResult Get()
        {
            return View();
        }
    }
}