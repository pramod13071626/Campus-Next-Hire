using System.ComponentModel.DataAnnotations;

namespace CampusCraft.Models
{
    public class ApplyViewModel
    {
        public int StudentID { get; set; }
        public int CompanyID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Course")]
        public string Course { get; set; }

        [Display(Name = "Year")]
        public string Year { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Resume")]
        public byte[] Resume { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
    }
}
