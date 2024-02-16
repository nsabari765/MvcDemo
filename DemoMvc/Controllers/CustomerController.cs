using DemoMvc.Data;
using DemoMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMvc.Controllers
{
    
    public class CustomerController : Controller
    {
        private readonly DataContext _dataContext;

        public CustomerController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> View()
        {
            var customers = await _dataContext.Customer.ToListAsync();
            return View(customers);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Add()
        {
            return View(new Customer());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Add(Customer customer)
        {
            await _dataContext.AddAsync(customer);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("View");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var customer = await _dataContext.Customer.FirstOrDefaultAsync(x => x.Id == id);

            if (customer != null)
            {
                return await Task.Run(() => View("Update", customer));
            }

            return RedirectToAction("View");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Update(Customer updateCustomer)
        {
            var customer = await _dataContext.Customer.FindAsync(updateCustomer.Id);
            if (customer != null)
            {
                customer.Name = updateCustomer.Name;
                customer.PhoneNumber = updateCustomer.PhoneNumber;

                await _dataContext.SaveChangesAsync();

                return RedirectToAction("View");
            }

            return RedirectToAction("View");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = _dataContext.Customer.Find(id);

            if (customer != null)
            {
                _dataContext.Customer.Remove(customer);

                await _dataContext.SaveChangesAsync();

                return RedirectToAction("View");
            }

            return RedirectToAction("View");
        }
    }
}