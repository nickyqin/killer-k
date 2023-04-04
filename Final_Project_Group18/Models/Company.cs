using System.ComponentModel.DataAnnotations;

//TODO: Update this namespace to match your project
namespace Final_Project_Group18.Models
{ 
    // string value for the recruiter
    public class Company
    {

        public Int32 CompanyID { get; set; }
        
        [Display(Name = "Description:")]
        public String Description { get; set; }

        [Display(Name = "Industry:")]
        public Industry Industry1{ get; set; }
        [Display(Name = "Industry:")]
        public Industry Industry2 { get; set; }
        [Display(Name = "Industry:")]
        public Industry Industry3 { get; set; }
        [Display(Name = "Email:")]
        public String Email { get; set; }
        [Display(Name = "Company Name:")]
        public String CompanyName { get; set; }
    }
}