using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

//TODO: Update this namespace to match your project's name
namespace Final_Project_Group18.Models
{
    public class AppUser : IdentityUser
    {
        //automatically inherits: UserID, Email, Phone Num, Pass, Email from IdentityUser class
        
        [Display(Name = "First Name:")]
        [Required(ErrorMessage = "First name is required.")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "Last name is required.")]
        public String LastName { get; set; }
        public String StudentMiddleInitial { get; set; }
        public DateTime? StudentBirthday { get; set; }
        public String StudentSSN { get; set; }
        public String StudentStreet { get; set; }
        public String StudentCity { get; set; }
        public String StudentState { get; set; }
        public Int32 StudentZip { get; set; }
        public Int32 StudentGraduationDate { get; set; }
        public Decimal StudentGPA { get; set; }
        public PositionType StudentPositionType { get; set; }
        public Company Company { get; set; }
        public Major StudentMajor { get; set; }
        public List<Application> StudentApplications { get; set; }

    }
}