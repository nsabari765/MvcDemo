﻿using DemoMvc.Data;
using DemoMvc.Models;
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
            var customers = await _dataContext.Customers.ToListAsync();
            return View(customers);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Customer());
        }

        [HttpPost]
        public async Task<ActionResult> Add(Customer customer)
        {
            await _dataContext.AddAsync(customer);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("View");
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var customer = await _dataContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customer != null)
            {
                return await Task.Run(() => View("Update", customer));
            }

            return RedirectToAction("View");
        }

        [HttpPost]
        public async Task<ActionResult> Update(Customer updateCustomer)
        {
            var customer = await _dataContext.Customers.FindAsync(updateCustomer.Id);
            if (customer != null)
            {
                customer.Name = updateCustomer.Name;
                customer.PhoneNumber = updateCustomer.PhoneNumber;

                await _dataContext.SaveChangesAsync();

                return RedirectToAction("View");
            }

            return RedirectToAction("View");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = _dataContext.Customers.Find(id);

            if (customer != null)
            {
                _dataContext.Customers.Remove(customer);

                await _dataContext.SaveChangesAsync();

                return RedirectToAction("View");
            }

            return RedirectToAction("View");
        }
    }
}