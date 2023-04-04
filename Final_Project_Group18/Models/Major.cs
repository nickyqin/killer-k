using System.ComponentModel.DataAnnotations;

//TODO: Update this namespace to match your project
namespace Final_Project_Group18.Models
{ 
    public class Major
    {
        // only access interview if status accepted
        public Int32 MajorID { get; set; }

        [Display(Name = "Major")]
        public String MajorName { get; set; }

        //TODO: how do you add a linking table between the major and position?
    }
}