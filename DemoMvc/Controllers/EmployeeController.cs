using DemoMvc.Data;
using DemoMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMvc.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly DataContext dataContext;

        public EmployeeController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> View()
        {
            var employees = await dataContext.Employee.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Employee());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee addEmployeeRequest)
        {
            if (ModelState.IsValid)
            {
                await dataContext.Employee.AddAsync(addEmployeeRequest);
                await dataContext.SaveChangesAsync();
                return RedirectToAction("Add");
            }

            return View(new Employee());
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var employee = await dataContext.Employee.FirstOrDefaultAsync(em => em.Id == id);

            if (employee != null)
            {
                return await Task.Run(() => View("Update", employee));
            }

            return RedirectToAction("View");
        }

        [HttpPost]
        public async Task<IActionResult> Update(Employee update)
        {
            var employee = await dataContext.Employee.FindAsync(update.Id);

            if (employee != null)
            {
                employee.Name = update.Name;
                employee.Email = update.Email;
                employee.Salary = update.Salary;
                employee.DateOfBirth = update.DateOfBirth;
                employee.DepartmentId = update.DepartmentId;
                employee.PhoneNumber = update.PhoneNumber;
                employee.City = update.City;

                await dataContext.SaveChangesAsync();

                return RedirectToAction("View");
            }

            return RedirectToAction("View");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee del)
        {
            var employee = dataContext.Employee.Find(del.Id);

            if (employee != null)
            {
                dataContext.Employee.Remove(employee);

                await dataContext.SaveChangesAsync();

                return RedirectToAction("View");
            }

            return RedirectToAction("View");
        }
    }
}