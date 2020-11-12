using Online_Assessment_Project.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Assessment_Project.ViewModel
{
    public class CreateTestViewModel
    {
        public int UserId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("UserId")]
        public User User { get; set; }
        public int TestId { get; set; }
        [Required]
        [Display(Name = "Name of the Test")]
        public string TestName { get; set; }
        public string Status { get; set; }
        [Required]
        public string TestDate { get; set; }
        [Required]
        public string Subject { get; set; }
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }
        [Display(Name = "End Time")]
        public string EndTime { get; set; }

        [Required]
        public Grade Grade { get; set; }
    }
    public enum Grade
    {
        I=1, II, III, IV, V, VI, VII, VIII, IX, X
    }

}

