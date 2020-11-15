using Online_Assessment_Project.ViewModel;
using Online_Assessment_Project.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Assessment_Project.Controllers
{
    public class AnswerController : Controller
    {
        AnswerService answerService;
        public AnswerController()
        {
            answerService = new AnswerService();
        }
        // GET: Answer
        public ActionResult CreateAnswer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAnswer(AnswerViewModel answerView, string command)
        {
            answerView.QuestionId = (int)TempData.Peek("QuestionId");
            if (ModelState.IsValid)
            {
                answerService.InsertAnswer(answerView);
                if (command == "Add")
                {
                   return RedirectToAction("CreateAnswer", "Answer");
                }
                else if(command == "Submit")
                {
                    return RedirectToAction("CreateQuestions", "Question");
                }
            }
            
                return View();
        }
    }
}