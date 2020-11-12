using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Assessment_Project.ViewModel
{
   public class TestViewModel
    {
        public int TestId { get; set; }
        [Required(ErrorMessage = "Test name is required.")]
        [RegularExpression(@"^(([a-zA-Z0-9]+[\s]{1}[a-zA-Z0-9]+)|([a-zA-Z0-9]+))$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string TestName { get; set; }
        //public string Status { get; set; }
        [Required(ErrorMessage = "Subject is required.")]
        [RegularExpression(@"^(([a-zA-Z]+[\s]{1}[a-zA-Z]+)|([a-zA-Z]+))$", ErrorMessage = "Only Alphabets allowed.")]
        public string Subject { get; set; }
        //public string ApprovedBy { get; set; }
        //[Required(ErrorMessage = "Arrival Date is Required")]
        //[DataType(DataType.Date)]
        //public string CreatedTime { get; set; }
        //public string ModifiedTime { get; set; }
        [Required(ErrorMessage = " Start time is Required")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = " End time is Required")]
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage = "Grade is required.")]
        [RegularExpression((@"[1-12]$"), ErrorMessage = "Grade should be from 1-12")]
        public int Grade { get; set; }
    }
}
