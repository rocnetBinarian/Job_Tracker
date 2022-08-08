using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Job_Application_Tracker.Models.ViewModels.Company;
using Job_Application_Tracker.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Job_Application_Tracker.Controllers
{
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View(new VM_Create());
        }

        [HttpPost]
        public async Task<IActionResult> Create(VM_Create createData)
        {
            using (JATContext context = new JATContext())
            {
                Company c = new Company()
                {
                    CompanyName = createData.CompanyName,
                    DoNotApply = !createData.Applied,
                    DateApplied = DateTime.Now
                };
                if (createData.Applied)
                {
                    c.ApplicationStatus = AppStatus.APPLIED;
                }
                context.Add(c);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction("Edit", new { cid = c.Id });
            }
        }

        private async Task<VM_ViewOrEdit> BuildViewOrEditVM(int cid)
        {
            using (JATContext context = new JATContext())
            {
                var contacts = await context.Contacts
                    .Where(x => x.CompanyId == cid)
                    .OrderBy(x => x.Name)
                    .ToListAsync().ConfigureAwait(false);
                var company = await context.Companies.FirstOrDefaultAsync(x => x.Id == cid).ConfigureAwait(false);

                if (company == null)
                {
                    return null;
                }
                else
                {
                    VM_ViewOrEdit vm = new VM_ViewOrEdit()
                    {
                        Company = company,
                        ContactListVM = new VM_Edit_ContactList()
                        {
                            CompanyId = cid,
                            Contacts = contacts
                        }
                    };
                    return vm;
                }
            }
        }

        [HttpGet]
        [Route("Edit/{cid}")]
        public async Task<IActionResult> Edit(int cid)
        {
            VM_ViewOrEdit vm = await BuildViewOrEditVM(cid).ConfigureAwait(false);
            if (vm == null)
            {
                return NotFound();
            } else
            {
                return View(vm);
            }
        }

        [HttpPost]
        [Route("Edit/Info")]
        public async Task<IActionResult> UpdateInfo(Company company)
        {
            using (JATContext context = new JATContext())
            {
                var comp = await context.Companies.FirstOrDefaultAsync(x => x.Id == company.Id).ConfigureAwait(false);
                comp.SalaryOffered = company.SalaryOffered;
                if (company.DoNotApply == true && comp.DoNotApply == false)
                    comp.DateApplied = DateTime.Today;

                if (company.DoNotApply)
                {
                    comp.ApplicationStatus = null;
                } else
                {
                    comp.ApplicationStatus = company.ApplicationStatus;
                }

                comp.DoNotApply = company.DoNotApply;
                comp.Website = company.Website;
                await context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction("View", new { cid = company.Id });
            }
        }

        [HttpPost]
        [Route("Edit/QA")]
        public async Task<IActionResult> UpdateQAInfo(Company company)
        {
            using (JATContext context = new JATContext())
            {
                var comp = await context.Companies.FirstOrDefaultAsync(x => x.Id == company.Id).ConfigureAwait(false);
                comp.FullRemoteOk = company.FullRemoteOk;
                comp.OutsideUSOK = company.OutsideUSOK;
                comp.WhyWorkHere = company.WhyWorkHere;
                comp.Culture = company.Culture;
                comp.IntraLvlCommunication = company.IntraLvlCommunication;
                comp.ViewsOnFOSS = company.ViewsOnFOSS;
                comp.SecurityVsConvenience = company.SecurityVsConvenience;
                comp.CompanySize = company.CompanySize;
                comp.DepartmentSize = company.DepartmentSize;
                comp.TeamSize = company.TeamSize;
                comp.k401Match = company.k401Match;
                comp.HealthInsPercent = company.HealthInsPercent;
                comp.DentalInsPercent = company.DentalInsPercent;
                comp.VisionInsPercent = company.VisionInsPercent;
                comp.Notes = company.Notes;
                await context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction("View", new { cid = company.Id });
            }
        }

        [HttpGet]
        [Route("View/{cid}")]
        public async Task<IActionResult> View(int cid)
        {
            VM_ViewOrEdit vm = await BuildViewOrEditVM(cid).ConfigureAwait(false);
            if (vm == null)
            {
                return NotFound();
            }
            else
            {
                return View(vm);
            }
        }
    }
}
