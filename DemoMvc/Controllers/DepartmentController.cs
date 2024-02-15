using DemoMvc.Models;
using DemoMvc.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvc.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> View()
        {
            var departments = await _departmentRepository.GetAllDepartment();
            return View(departments);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Department());
        }

        [HttpPost]
        public async Task<ActionResult> Add(Department department)
        {
            await _departmentRepository.Department(department);

            return RedirectToAction("View");
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var department = await _departmentRepository.Get(id);

            if (department != null)
            {
                return await Task.Run(() => View("Update", department));
            }

            return RedirectToAction("View");
        }

        [HttpPost]
        public async Task<ActionResult> Update(Department updateDepartment)
        {
            await _departmentRepository.UpdateDepartment(updateDepartment);
            return RedirectToAction("View");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentRepository.Delete(id);
            return RedirectToAction("View");
        }
    }
}