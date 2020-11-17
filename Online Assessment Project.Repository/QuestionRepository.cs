using Online_Assessment_Project.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Assessment_Project.Repository
{
    public interface IQuestionRepository
    {
        int InsertQuestion(Questions question);
        void EditQuestion(Questions editQuestion);
        void DeleteQuestion(int testId);
        Questions GetQuestionsByTestId(int testId);
        IEnumerable<Questions> DisplayAllQuestions(int testId);

    }
    public class QuestionRepository : IQuestionRepository
    {
        AssessmentPortalDbContext db;
        public QuestionRepository()
        {
            db = new AssessmentPortalDbContext();
        }
        public int InsertQuestion(Questions question)
        {
            question.CreateTime = DateTime.Now.ToString();
            db.Questions.Add(question);
            db.SaveChanges();
            return question.QuestionId;            
        }      

        public void EditQuestion(Questions editQuestion)
        {

            Questions question = db.Questions.Find(editQuestion.TestId);
            if (question != null)
            {
                question.TestId = editQuestion.TestId;
                question.QuestionId = editQuestion.QuestionId;
                question.Question = editQuestion.Question;
                question.CreateTime = editQuestion.CreateTime;
                question.ModifiedTime = editQuestion.ModifiedTime;                
                db.SaveChanges();
            }
        }
        public void DeleteQuestion(int testId)
        {
            db.Questions.Remove(GetQuestionsByTestId(testId));
            db.SaveChanges();
        }
        public Questions GetQuestionsByTestId(int testId)
        {
            return db.Questions.Find(testId);
        }
               
        public IEnumerable<Questions> DisplayAllQuestions(int testId)
        {

            IEnumerable<Questions> allQuestions = db.Questions.Where(temp => temp.TestId == testId).ToList();
            return allQuestions;

        }
    }

}



