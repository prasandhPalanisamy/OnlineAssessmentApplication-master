using Online_Assessment_Project.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Assessment_Project.ViewModel
{
    public class QuestionsViewModel
    {
        public int QuestionID { get; set; }
        [Required(ErrorMessage = "Question name is required")]
        public string Question { get; set; }
        public int TestId { get; set; }
        

    }


}
