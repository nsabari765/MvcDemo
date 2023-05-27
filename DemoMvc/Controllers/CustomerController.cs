using DemoMvc.Data;
using DemoMvc.Models;
using DemoMvc.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMvc.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DataContext dbCon;

        public CustomerController(DataContext DbCon)
        {
            dbCon = DbCon;
        }

        [HttpGet]
        public async Task<ActionResult> View(Employee emp)
        {
            var customers = await dbCon.Customers.ToListAsync();
            return View(customers);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var customer = await dbCon.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customer != null)
            {
                var Update = new UpdateCus()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    PhoneNumber = customer.PhoneNumber
                };

                return await Task.Run(() => View("Update", Update));
            }

            return RedirectToAction("View");
        }

        [HttpPost]
        public async Task<ActionResult> Update(UpdateCus up)
        {
            var cus = await dbCon.Customers.FindAsync(up.Id);
            if (cus != null)
            {
                cus.Name = up.Name;
                cus.PhoneNumber = up.PhoneNumber;

                await dbCon.SaveChangesAsync();

                return RedirectToAction("View");
            }

            return RedirectToAction("View");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddCus ac)
        {
            var customer = new Customer()
            {
                Name = ac.Name,
                PhoneNumber = ac.PhoneNumber,
            };

            await dbCon.AddAsync(customer);
            await dbCon.SaveChangesAsync();
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateCus del)
        {
            var cus = dbCon.Customers.Find(del.Id);

            if (cus != null)
            {
                dbCon.Customers.Remove(cus);

                await dbCon.SaveChangesAsync();

                return RedirectToAction("View");
            }
            return RedirectToAction("View");
        }
    }
}
