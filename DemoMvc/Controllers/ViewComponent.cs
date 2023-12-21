using Microsoft.AspNetCore.Mvc;

namespace DemoMvc.Controllers
{
    public class DataTableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}