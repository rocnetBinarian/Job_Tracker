using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Application_Tracker.Models.ViewModels.Company
{
    public class VM_Edit_ContactList
    {
        public int CompanyId { get; set; }
        public List<Entities.Contact> Contacts { get; set; }
    }
}
