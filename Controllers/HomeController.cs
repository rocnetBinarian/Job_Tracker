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
            var vm = new VM_Index();
            using (JATContext context = new JATContext())
            {
                vm.CompanyList = await context.Companies.OrderBy(c => c.CompanyName).ToListAsync().ConfigureAwait(false);
            }
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
