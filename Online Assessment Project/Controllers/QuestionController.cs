using Online_Assessment_Project.DomainModel;
using Online_Assessment_Project.ServiceLayer;
using Online_Assessment_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Assessment_Project.Controllers
{
    public class QuestionController : Controller
    {
        QuestionServices questionService;
        public QuestionController()
        {
            questionService = new QuestionServices();
        }
        // GET: Question
        public ActionResult CreateQuestions(int testId)
        {
            return View(testId);
        }
        [HttpPost]
        [ActionName("CreateQuestions")]
        public ActionResult SaveQuestions(QuestionsViewModel newQuestion)
        {
            newQuestion.TestId = Convert.ToInt32(Session["TestId"]);
            if (ModelState.IsValid)
            {
                questionService.InsertQuestion(newQuestion);
            }
            return RedirectToAction("CreateAnswer", "Answer");
        }
        public ActionResult DisplayQuestions(int testId)
        {            
            IEnumerable<QuestionsViewModel> questions = questionService.DisplayAllDetails(testId);
            return View(questions);
        }
    }
}