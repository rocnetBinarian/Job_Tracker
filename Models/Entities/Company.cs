using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Application_Tracker.Models.Entities
{
    public class Company
    {
        public int Id { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Opted to Not Apply")]
        public bool DoNotApply { get; set; }

        [Display(Name = "Date Applied")]
        public DateTime DateApplied { get; set; }

        [Display(Name = "Why Work Here?")]
        public string WhyWorkHere { get; set; }

        [Display(Name = "401k Matching %")]
        public byte? k401Match { get; set; } = null;

        [Display(Name = "Appx. Health Ins. Coverage %")]
        public byte? HealthInsPercent { get; set; } = null;

        [Display(Name = "Appx. Dental Ins. Coverage %")]
        public byte? DentalInsPercent { get; set; } = null;

        [Display(Name = "Appx. Vision Ins. Coverage %")]
        public byte? VisionInsPercent { get; set; } = null;

        public string Notes { get; set; }

        [Display(Name = "Salary Offered (Yearly)")]
        public string SalaryOffered { get; set; }

        public string Website { get; set; }

        [Display(Name = "Application Status")]
        public AppStatus? ApplicationStatus { get; set; }

        [Display(Name = "Company Culture")]
        public string Culture { get; set; }

        [Display(Name = "Inter/Intra-Level Communication", Prompt = "What is communication like at the company?  Managers vs. leadership; Developers vs. management; etc.")]
        public string IntraLvlCommunication { get; set; }

        [Display(Name = "Views on FOSS", Prompt = "What is the company's views on FOSS technologies?  Will I be able to FOSS some of my work under my own name/repo?")]
        public string ViewsOnFOSS { get; set; }

        [Display(Name = "Confirm Full Remote is OK")]
        public bool? FullRemoteOk { get; set; }

        [Display(Name = "Confirm Non-US is OK")]
        public bool? OutsideUSOK { get; set; }

        [Display(Name = "Appx. Company Size")]
        public int? CompanySize { get; set; }

        [Display(Name = "Appx. Department Size")]
        public int? DepartmentSize { get; set; }

        [Display(Name = "Appx. Team Size")]
        public int? TeamSize { get; set; }

        [Display(Name = "Security vs. Convenience", Prompt = "What is the company's position on security vs. convenience?  For example, if it was discovered that someone was sharing passwords, what would happen?  What if leadership wants a new feature to be less secure, because the security measures are 'too annoying'?")]
        public string SecurityVsConvenience { get; set; }

        [Display(Name = "Job Posting")]
        public string JobPosting {get; set;}

        public ICollection<Contact> Contacts { get; set; }
    }

    public enum AppStatus
    {
        APPLIED = 0,
        REJECTED,
        INTERVIEW_PENDING,
        INTERVIEW_COMPLETED,
        ACCEPTED
    }
}
