using AutoMapper;
using Online_Assessment_Project.DomainModel;
using Online_Assessment_Project.Filters;
using Online_Assessment_Project.ServiceLayer;
using Online_Assessment_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace Online_Assessment_Project.Controllers
{
    public class TestController : Controller
    {
        ITestServices testServices;
        
        public TestController()
        {
            testServices = new TestServices();
        }
        // GET: Test
        public ActionResult CreateTest()
        {

            return View();
        }
        [HttpPost]
        [ActionName("CreateTest")]
        public ActionResult SaveTest(CreateTestViewModel newTest)
        {
            newTest.UserId = Convert.ToInt32(Session["CurrentUserID"]);
            int testId = 0;
            if (ModelState.IsValid)
            {
                testId = testServices.CreateNewTest(newTest);
                
            }
            Session["TestId"] = testId;
            return RedirectToAction("CreateQuestions", "Question", new {id = testId });
        }
        public ActionResult DisplayAvailableTest()
        {
            IEnumerable<TestViewModel> test = testServices.DisplayAllDetails();
            return View(test);
        }
        public ActionResult Display()
        {
            return View();
        }
    }
}