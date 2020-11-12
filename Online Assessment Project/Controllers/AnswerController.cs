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
        public ActionResult CreateAnswer(AnswerViewModel answerView)
        {
            if (ModelState.IsValid)
            {
                answerService.InsertAnswer(answerView); 
            }   
            return View();
        }
    }
}