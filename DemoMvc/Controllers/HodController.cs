using DemoMvc.Models;
using DemoMvc.Repository.HodRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvc.Controllers
{
    [Authorize]
    public class HodController : Controller
    {
        private readonly HodRepository _hodRepository;

        public HodController(HodRepository hodRepository)
        {
            _hodRepository = hodRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            var response = _hodRepository.GetAllHod();
            return View("/Views/Hods/View.cshtml", response);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("~/Views/Hods/Add.cshtml");
        }

        [HttpPost]
        public IActionResult SaveUpdate(HodName hodName)
        {
            _hodRepository.Save(hodName);
            return View("~/Views/Hods/Add.cshtml");
        }
    }
}