using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Application_Tracker.Models.ViewModels.Company
{
    public class VM_Create
    {
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Chose to apply?")]
        public bool Applied { get; set; } = true;

    }
}
