using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Job_Application_Tracker.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Job_Application_Tracker.Controllers
{
    [Route("[Controller]")]
    public class ContactController : Controller
    {

        [Route("Add/{cid}")]
        [HttpGet]
        public async Task<IActionResult> AddContactForm(int cid)
        {
            var vm = new Contact()
            {
                CompanyId = cid
            };
            return PartialView("~/Views/Contact/Partials/Add.cshtml", vm);
        }

        [Route("Edit/{cid}")]
        [HttpGet]
        public async Task<IActionResult> EditContactForm(int cid)
        {
            using (JATContext context = new JATContext())
            {
                var vm = await context.Contacts.FirstOrDefaultAsync(x => x.Id == cid).ConfigureAwait(false);
                if (vm == null)
                {
                    return NotFound();
                } else
                {
                    return PartialView("~/Views/Contact/Partials/Edit.cshtml", vm);
                }
            }
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add(Contact contact)
        {
            try
            {
                // TODO: error checking on the company id
                using (JATContext context = new JATContext())
                {
                    context.Contacts.Add(contact);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                    return RedirectToAction("Edit", "Company", new { cid = contact.CompanyId });
                }
            } catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [Route("Edit")]
        [HttpPost]
        public async Task<IActionResult> Edit(Contact contact)
        {
            using (JATContext context = new JATContext())
            {
                context.Contacts.Update(contact);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction("Edit", "Company", new { cid = contact.CompanyId });
            }
        }

        [Route("Delete")]
        [HttpPost]
        public async Task<IActionResult> Delete(Contact contact)
        {
            using (JATContext context = new JATContext())
            {
                context.Contacts.Remove(contact);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction("Edit", "Company", new { cid = contact.CompanyId });

            }
        }
    }
}
