using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

//TODO: Update this namespace to match your project's name
namespace Final_Project_Group18.Models
{
    public class AppUser : IdentityUser
    {
        //automatically inherits: UserID, Email, Phone Num, Pass from IdentityUser class
        
        [Display(Name = "First Name:")]
        [Required(ErrorMessage = "First name is required.")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "Last name is required.")]
        public String LastName { get; set; }

        public Company Company { get; set; }
        // TODO: add all the students attributes on AppUser
    }
}