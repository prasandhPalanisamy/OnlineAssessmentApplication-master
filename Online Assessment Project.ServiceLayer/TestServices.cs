using AutoMapper;
using Online_Assessment_Project.DomainModel;
using Online_Assessment_Project.Repository;
using Online_Assessment_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Assessment_Project.ServiceLayer
{
    public interface ITestServices
    {
        IEnumerable<TestViewModel> DisplayAllDetails();
        int CreateNewTest(CreateTestViewModel testViewModel);
    }

    public class TestServices : ITestServices
    {
        TestRepository testRepository = new TestRepository();
        public int CreateNewTest(CreateTestViewModel testViewModel)
        {
            int id;
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CreateTestViewModel, Test>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            var test = mapper.Map<CreateTestViewModel, Test>(testViewModel);
            id = testRepository.CreateNewTest(test);                
            return id;
        }
        public IEnumerable<TestViewModel> DisplayAllDetails()
        {
            IEnumerable<Test> test = testRepository.DisplayAllDetails();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Test, TestViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            IEnumerable<TestViewModel> allTest = mapper.Map<IEnumerable<Test>, IEnumerable<TestViewModel>>(test);
            return allTest;
        }
    }
}
