using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Application_Tracker.Models.ViewModels.Home
{
    public class VM_Index_CompanyList
    {
        public List<Entities.Company> CompanyList { get; set; }
        public string[] EnumNames { get; set; }
    }
}
