//TODO: Change this using statement to match your project (LastName_FirstName_HW3)
using Final_Project_Group18.DAL;
using Microsoft.AspNetCore.Mvc;


//TODO: Update this namespace to match your project's name
namespace Final_Project_Group18.Controllers
{
    public class SeedController : Controller
    {
        private AppDbContext _db;

        public SeedController(AppDbContext context)
        {
            _db = context;
        }
    }
}