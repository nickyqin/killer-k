using System.ComponentModel.DataAnnotations;

//TODO: Update this namespace to match your project
namespace Final_Project_Group18.Models
{ 
    public class Interview
    {
        public Int32 InterviewID { get; set; }
        // interviewer is the recruiter
        [Display(Name = "Interviewer:")]
        public AppUser Interviewer { get; set; }
        public AppUser Student { get; set; }

        [Display(Name = "Description:")]
        public String Description { get; set; }
        [Display(Name = "Interview Date:")]
        public DateTime? InterviewDate { get; set; }

        [Display(Name = "Time:")]
        public String InterviewTime { get; set; }
        [Display(Name = "Position:")]
        public Position InterviewPosition { get; set; }
        [Display(Name = "Company:")]
        public Company InterviewCompany { get; set; }
        [Display(Name = "Room:")]
        public Int32 InterviewRoom { get; set; }
    }
}