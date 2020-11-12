using Online_Assessment_Project.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Assessment_Project.Repository
{
    interface IAnswerRepository
    {
        void InsertAnswer(Answer answer);
        List<Answer> GetAnswersByQuestionID(int questionID);
    }
    public class AnswerRepository : IAnswerRepository
    {
        AssessmentPortalDbContext db;
        public AnswerRepository()
        {
            db = new AssessmentPortalDbContext();
        }
        public void InsertAnswer(Answer answer)
        {
            db.Answers.Add(answer);
            db.SaveChanges();
        }

        public List<Answer> GetAnswersByQuestionID(int questionID)
        {
            return db.Answers.Where(Temp => Temp.QuestionId == questionID).ToList();
        }
    }
}
