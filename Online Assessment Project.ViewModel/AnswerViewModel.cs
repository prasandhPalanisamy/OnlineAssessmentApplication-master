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
    public class AnswerViewModel
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Questions Questions { get; set; }
        [Required (ErrorMessage ="Answer Label is Required")]
        public char AnswerLable { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Mark is Required")]
        public decimal Mark { get; set; }
        [Required(ErrorMessage = "IsCorrect is Required")]
        public byte IsCorrect { get; set; }
    }
}
