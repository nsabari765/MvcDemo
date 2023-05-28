using DemoMvc.Data;
using DemoMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMvc.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DataContext _dataContext;

        public DepartmentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> View()
        {
            var departments = await _dataContext.Departments.ToListAsync();
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
            await _dataContext.AddAsync(department);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("View");
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var department = await _dataContext.Departments.FirstOrDefaultAsync(x => x.Id == id);

            if (department != null)
            {
                return await Task.Run(() => View("Update", department));
            }

            return RedirectToAction("View");
        }

        [HttpPost]
        public async Task<ActionResult> Update(Department updateDepartment)
        {
            var department = await _dataContext.Departments.FindAsync(updateDepartment.Id);
            if (department != null)
            {
                department.Name = updateDepartment.Name;

                await _dataContext.SaveChangesAsync();

                return RedirectToAction("View");
            }

            return RedirectToAction("View");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var department = _dataContext.Departments.Find(id);

            if (department != null)
            {
                _dataContext.Departments.Remove(department);

                await _dataContext.SaveChangesAsync();

                return RedirectToAction("View");
            }

            return RedirectToAction("View");
        }
    }
}