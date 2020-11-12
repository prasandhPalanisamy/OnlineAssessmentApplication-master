using Online_Assessment_Project.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Assessment_Project.ViewModel
{
    public class CreateViewModel
    {
       
        public int UserId { get; set; }
        [MaxLength(20)]
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Grade { get; set; }
        [Required]
        [RegularExpression(@"^[6789]\d{9}$")]
        public long PhoneNumber { get; set; }
        
       
        public int RoleId { get; set; }
        public RoleViewModel Role { get; set; }

    }
}
