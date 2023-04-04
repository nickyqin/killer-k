using System.ComponentModel.DataAnnotations;

//TODO: Update this namespace to match your project
namespace Final_Project_Group18.Models
{ 
    public class Industry
    {
        public Int32 IndustryID { get; set; }
        [Display(Name = "Industry Name:")]
        public String IndustryName { get; set; }
    }
}