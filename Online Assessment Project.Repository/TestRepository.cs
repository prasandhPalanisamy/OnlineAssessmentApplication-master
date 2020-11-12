using Online_Assessment_Project.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace Online_Assessment_Project.Repository
{
    interface ITestRepository
    {
        IEnumerable<Test> DisplayAllDetails();
        int CreateNewTest(Test test);
        Test GetTestByTestId(int testId);
    }
    public class TestRepository : ITestRepository
    {
        AssessmentPortalDbContext db;
        public TestRepository()
        {
            db = new AssessmentPortalDbContext();
        }
        public int CreateNewTest(Test test) //To create new test
        {
            test.CreatedTime = DateTime.Now.ToString();
            db.Tests.Add(test);
            db.SaveChanges();
            int id = test.TestId;
            
            return id;
        }
        public Test GetTestByTestId(int testId)
        {
            return db.Tests.Find(testId);
        }
    

    
        public IEnumerable<Test> DisplayAllDetails()
        {
            
                IEnumerable<Test> allTests =db.Tests.OrderByDescending(test => test.TestDate).ToList();
                return allTests;
            
        }
    }
}
