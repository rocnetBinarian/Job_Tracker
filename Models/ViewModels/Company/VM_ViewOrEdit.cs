using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Application_Tracker.Models.ViewModels.Company
{
    public class VM_ViewOrEdit
    {
        public Entities.Company Company { get; set; }
        public VM_Edit_ContactList ContactListVM { get; set; }
    }
}
