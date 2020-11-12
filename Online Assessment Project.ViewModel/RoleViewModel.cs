using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Assessment_Project.ViewModel
{
   public class RoleViewModel
    {
        public int RoleId { get; set; }
        [MaxLength(20)]
        [Required(ErrorMessage = "RoleName required")]
        public string RoleName { get; set; }
    }
}
