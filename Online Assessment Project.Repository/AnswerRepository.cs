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
            Answer answer = db.Answers.Find(GetAnswersByQuestionID(editAnswer.QuestionId));
            if(editAnswer != null)
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
        public Answer GetAnswersByQuestionID(int questionId)
        {
            return db.Answers.Find(questionId);
        }
        public IEnumerable<Answer> DisplayAnswers(int questionId)
        {
            IEnumerable<Answer> allAnswers = db.Answers.OrderBy(answer => answer.AnswerId).ToList();
            return allAnswers;
        }
    }
}
