using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Application_Tracker.Models.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Display(Name="Additional Info")]
        public string AdditionalInfo { get; set; }

        public Company Company { get; set; }
    }
}
