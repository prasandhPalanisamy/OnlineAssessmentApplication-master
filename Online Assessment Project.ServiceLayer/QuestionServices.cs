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
    interface IQuestionServices
    {
        void InsertQuestion(QuestionsViewModel createQuestionsViewModel);
        //void EditQuestion(QuestionsViewModel editQuestionsViewModel);
        //void DeleteQuestion(int questionID);
        //List<QuestionsViewModel> GetQuestions();
        List<QuestionsViewModel> GetQuestionsByTestID(int testID);

    }
    public class QuestionServices : IQuestionServices
    {
        IQuestionRepository questionRepository;
        public QuestionServices()
        {
            questionRepository = new QuestionRepository();
        }
        public void InsertQuestion(QuestionsViewModel QuestionsViewModel)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<QuestionsViewModel, Questions>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Questions question = mapper.Map<QuestionsViewModel, Questions>(QuestionsViewModel);
            questionRepository.InsertQuestion(question);

        }
        //public void EditQuestion(QuestionsViewModel editQuestionsViewModel)
        //{
        //    var config = new MapperConfiguration(cfg => { cfg.CreateMap<QuestionsViewModel, Questions>(); cfg.IgnoreUnmapped(); });
        //    IMapper mapper = config.CreateMapper();
        //    Questions question = mapper.Map<QuestionsViewModel, Questions>(editQuestionsViewModel);
        //    questionRepository.EditQuestion(question);
        //}
        //public void DeleteQuestion(int questionID)
        //{
        //    questionRepository.DeleteQuestion(questionID);
        //}
        //public List<QuestionsViewModel> GetQuestions()
        //{
        //    List<Questions> questionList = questionRepository.GetQuestions();
        //    var config = new MapperConfiguration(cfg => { cfg.CreateMap<Questions, QuestionsViewModel>(); cfg.IgnoreUnmapped(); });
        //    IMapper mapper = config.CreateMapper();
        //    List<QuestionsViewModel> questionvm = mapper.Map<List<Questions>, List<QuestionsViewModel>>(questionList);
        //    return questionvm;
        //}
        public List<QuestionsViewModel> GetQuestionsByTestID(int testID)
        {
            List<Questions> questions = questionRepository.GetQuestionsByTestID(testID);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<List<Questions>,List<QuestionsViewModel>>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper(); 
             return mapper.Map<List<Questions>, List<QuestionsViewModel>>(questions);
           // return question;
        }
        public IEnumerable<QuestionsViewModel> DisplayAllDetails(int testId)
        {
            IEnumerable<Questions> questions = questionRepository.DisplayAllQuestions(testId);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Questions, QuestionsViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            IEnumerable<QuestionsViewModel> allQuestions = mapper.Map<IEnumerable<Questions>, IEnumerable<QuestionsViewModel>>(questions);
            return allQuestions;
        }
    }

} 

    
