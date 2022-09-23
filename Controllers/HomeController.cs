using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Job_Application_Tracker.Models;
using Job_Application_Tracker.Models.Entities;
using Job_Application_Tracker.Models.ViewModels.Home;
using Microsoft.EntityFrameworkCore;

namespace Job_Application_Tracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Route("CompanyList")]
        public async Task<JsonResult> GetCompanyList() 
        {
            var vm = new VM_Index_CompanyList();
            using (JATContext context = new JATContext())
            {
                vm.CompanyList = await context.Companies.OrderBy(c => c.CompanyName).ToListAsync().ConfigureAwait(false);
                vm.EnumNames = Enum.GetNames(typeof(AppStatus));
            }
            return Json(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
