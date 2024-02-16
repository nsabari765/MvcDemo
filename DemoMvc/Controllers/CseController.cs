using DemoMvc.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvc.Controllers
{
    public class CseController : Controller
    {
        private readonly DataContext _context;

        public CseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult List()
        {
            var employee = _context.Employee.AsQueryable().Where(x => x.DepartmentId == 4).ToList();
            return View("/Views/ListOfCse.cshtml", employee);
        }
    }
}