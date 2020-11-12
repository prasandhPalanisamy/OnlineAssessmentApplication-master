using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Assessment_Project.DomainModel
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Questions Questions { get; set; }
        public char AnswerLable { get; set; }
        public string Description { get; set; }
        public decimal Mark { get; set; }
        public byte IsCorrect { get; set; }
    }


}
