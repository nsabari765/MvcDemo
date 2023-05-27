using DemoMvc.Data;
using DemoMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataContext dataContext;

        public EmployeeController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> View(Employee employee)
        {
            var employees = await dataContext.Employees.ToListAsync();
            return View(employees); 
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeModel addEmployeeRequest)
        {
            var employee = new Employee();

            if (ModelState.IsValid)
            {
                
                employee.Id = Guid.NewGuid();
                employee.Name = addEmployeeRequest.Name;
                employee.Salary = addEmployeeRequest.Salary;
                employee.Email = addEmployeeRequest.Email;
                employee.DateOfBirth = addEmployeeRequest.DateOfBirth;
                employee.Department = addEmployeeRequest.Department;
                employee.PhoneNumber = addEmployeeRequest.PhoneNumber;
                employee.City = addEmployeeRequest.City;

                await dataContext.Employees.AddAsync(employee);
                await dataContext.SaveChangesAsync();
                return RedirectToAction("Add");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
           var employee = await dataContext.Employees.FirstOrDefaultAsync(em => em.Id == id);

            if (employee != null)
            {
                var employees = new UpdateEmployeeDetails()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    Email = employee.Email,
                    DateOfBirth= employee.DateOfBirth,
                    Department= employee.Department,
                    PhoneNumber=employee.PhoneNumber,
                    City = employee.City

                };

                return await Task.Run(() => View("Update",employees));
            }
           
           return RedirectToAction("View");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateEmployeeDetails up)
        {
            var employee = await dataContext.Employees.FindAsync(up.Id);

            if (employee != null)
            {
                employee.Name = up.Name;
                employee.Email = up.Email;
                employee.Salary = up.Salary;
                employee.DateOfBirth = up.DateOfBirth;
                employee.Department = up.Department;
                employee.PhoneNumber = up.PhoneNumber;
                employee.City = up.City;

                await dataContext.SaveChangesAsync();

                return RedirectToAction("View");
            }

            return RedirectToAction("View");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeDetails del)
        {
            var employee = dataContext.Employees.Find(del.Id);

            if (employee != null)
            {
                dataContext.Employees.Remove(employee);

               await  dataContext.SaveChangesAsync();

                return RedirectToAction("View");
            }

            return RedirectToAction("View");
        }
    }
}
