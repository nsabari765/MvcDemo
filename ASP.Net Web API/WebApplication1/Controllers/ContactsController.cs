using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly DataContactAPI dbcontact;

        public ContactsController(DataContactAPI dbcontact)
        {
            this.dbcontact = dbcontact;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbcontact.Contact.ToListAsync());
        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetContact([FromRoute] int id)
        {
            var contact = await dbcontact.Contact.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            var contacts = new Contact
            {
                Id = contact.Id,
                phone = contact.phone,
                FullName = contact.FullName,
                Address = contact.Address,
                Email = contact.Email
            };

            await dbcontact.Contact.AddAsync(contacts);
            await dbcontact.SaveChangesAsync();
            return Ok(contacts);
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateContact([FromRoute] int id, Contact UpdateContacts)
        {
            var contact = await dbcontact.Contact.FindAsync(id);
            if (contact != null)
            {
                contact.FullName = UpdateContacts.FullName;
                contact.Email = UpdateContacts.Email;
                contact.phone = UpdateContacts.phone;
                contact.Address = UpdateContacts.Address;

                await dbcontact.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var delete = await dbcontact.Contact.FindAsync(id);
            if (delete != null)
            {
                dbcontact.Remove(delete);
                await dbcontact.SaveChangesAsync();
                return Ok(delete);
            }
            return NotFound();
        }
    }
}