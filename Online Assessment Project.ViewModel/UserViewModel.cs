using System.ComponentModel.DataAnnotations;

namespace Online_Assessment_Project.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        
        public string EmailID { get; set; }
        
        public string Password { get; set; }
        public string Grade { get; set; }
        public long PhoneNumber { get; set; }
        public int RoleId { get; set; }

    }
}
