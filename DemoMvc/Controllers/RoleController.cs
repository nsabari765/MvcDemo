using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvc.Controllers
{
    public class RoleController: Controller
    {
        private readonly RoleManager<IdentityRole>? _roleManager;

        public RoleController(RoleManager<IdentityRole>? roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
             if(!_roleManager.RoleExistsAsync(role.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(role.Name)).GetAwaiter().GetResult();
            }

             return RedirectToAction("Index");
        }
    }
}
