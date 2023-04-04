using System.ComponentModel.DataAnnotations;

namespace Final_Project_Group18.Models
{
    public enum StatusType
    {
        [Display(Name = "Pending")] Pending,
        [Display(Name = "Rejected")] Rejected,
        [Display(Name = "Accepted")] Accepted
    }
    public class Application
    {
        public Int32 ApplicationID { get; set; }

        public AppUser Student { get; set; }

        [Display(Name = "Status:")]
        public StatusType Status { get; set; }
        [Display(Name = "Position:")]
        public Position Position { get; set; }
        [Display(Name = "Company:")]
        public Company Company { get; set; }
    }
}