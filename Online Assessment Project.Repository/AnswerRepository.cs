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
        void EditAnswer(Answer editAnswer);
        void DeleteAnswer(int answerId);
        Answer GetAnswersByQuestionID(int questionId);
        IEnumerable<Answer> DisplayAnswers(int questionId);
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
        public void EditAnswer(Answer editAnswer)
        {
            Answer answer = db.Answers.Find(editAnswer.AnswerId);
            if(answer != null)
            {
                answer.AnswerId = editAnswer.AnswerId;
                answer.AnswerLable = editAnswer.AnswerLable;
                answer.Description = editAnswer.Description;
                answer.Mark = editAnswer.Mark;
                answer.IsCorrect = editAnswer.IsCorrect;
                db.SaveChanges();
            }
        }
        public void DeleteAnswer(int answerId)
        {
            db.Answers.Remove(GetAnswersByQuestionID(answerId));
            db.SaveChanges();
        }
        public Answer GetAnswersByQuestionID(int answerId)
        {
            return db.Answers.Find(answerId);
        }
        public IEnumerable<Answer> DisplayAnswers(int questionId)
        {
            IEnumerable<Answer> allAnswers = db.Answers.Where(answer => answer.QuestionId == questionId).ToList();
            return allAnswers;
        }
    }
}
