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
        void InsertQuestion(Questions question);
        //void EditQuestion(Questions question);
        //void DeleteQuestion(int questionID);
        //List<Questions> GetQuestions();
        List<Questions> GetQuestionsByTestID(int testID);
        IEnumerable<Questions> DisplayAllQuestions(int testId);
    }
    public class QuestionRepository : IQuestionRepository
    {
        AssessmentPortalDbContext db;
        public QuestionRepository()
        {
            db = new AssessmentPortalDbContext();
        }
        public void InsertQuestion(Questions question)
        {
            question.CreateTime = DateTime.Now.ToString();
            db.Questions.Add(question);
            db.SaveChanges();
        }
        //public void EditQuestion(Questions question)
        //{
        //    Questions changeQuestion = db.Questions.Where(temp => temp.QuestionID == question.QuestionID).FirstOrDefault();
        //    if (changeQuestion != null)
        //    {
        //        changeQuestion.Question = question.Question;
        //        db.SaveChanges();
        //    }
        //}
        //public void DeleteQuestion(int questionID)
        //{
        //    Questions changeQuestion = db.Questions.Where(temp => temp.QuestionID == questionID).FirstOrDefault();
        //    if (changeQuestion != null)
        //    {
        //        db.Questions.Remove(changeQuestion);
        //        db.SaveChanges();
        //    }
        //}
        //public List<Questions> GetQuestions()
        //{
        //    List<Questions> changeQuestion = db.Questions.OrderByDescending(temp => temp.Question).ToList();
        //    return changeQuestion;
        //}
        public List<Questions> GetQuestionsByTestID(int testId)
        {
            return db.Questions.Where(Temp => Temp.TestId == testId).ToList();
        }

        public IEnumerable<Questions> DisplayAllQuestions(int testId)
        {

            IEnumerable<Questions> allQuestions = db.Questions.Where(temp => temp.TestId == testId).ToList();
            return allQuestions;

        }
    }

}



