using System.ComponentModel.DataAnnotations;

//TODO: Update this namespace to match your project
namespace Final_Project_Group18.Models
{
    public enum PositionType
    {
        [Display(Name = "Full Time")] FT,
        [Display(Name = "Intern")] I,
    }

    public class Position
    {
        public Int32 PositionID { get; set; }
        [Display(Name = "Position Title:")]
        public String PositionTitle { get; set; }

        [Display(Name = "Description:")]
        public String Description { get; set; }

        [Display(Name = "Position Type")]
        public PositionType Type { get; set; }

        [Display(Name = "Company:")]
        public Company PositionCompany { get; set; }

        [Display(Name = "Location:")]
        public String PositionLocation { get; set; }

        [Display(Name = "Deadline To Apply:")]
        public DateTime? PositionDeadline { get; set; }

        [Display(Name = "Applicable Majors:")]
        public List<Major> PositionMajors { get; set; }
    }
}