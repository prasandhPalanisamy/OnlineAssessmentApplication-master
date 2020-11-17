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
        public ActionResult CreateQuestions()
        {            
            return View();
        }
        [HttpPost]
        [ActionName("CreateQuestions")]
        public ActionResult SaveQuestions(QuestionsViewModel newQuestion, string Command)
        {
            newQuestion.TestId = (int)TempData.Peek("MyData");
            int questionId = 0;
            if (ModelState.IsValid)
            {
                questionId = questionService.InsertQuestion(newQuestion);
                TempData["QuestionId"] = questionId;
                if (Command == "Create Options")
                {
                    return RedirectToAction("CreateAnswer", "Answer");
                }
                else if (Command == "Submit")
                {
                    return RedirectToAction("DisplayQuestions",new { testId = newQuestion.TestId });
                }
            }
            return View();
        }
        public ActionResult DisplayQuestions(int testId)
        {            
            IEnumerable<QuestionsViewModel> questions = questionService.DisplayAllDetails(testId);
            return View(questions);
        }

        public ActionResult EditQuestion(int questionId)
        {
            QuestionsViewModel questions = questionService.GetQuestionsByTestId(questionId);
            return View(questions);
        }
        [HttpPost]
        public ActionResult EditQuestion(QuestionsViewModel editedData)
        {
            editedData.TestId = (int)TempData.Peek("MyData");
            if (ModelState.IsValid)
            {
                questionService.EditQuestion(editedData);
                return RedirectToAction("DisplayQuestions");
            }
            return View();
        }
        public ActionResult DeleteQuestion(int question)
        {
            questionService.DeleteQuestion(question);
            return RedirectToAction("DisplayQuestions");
        }

    }
}