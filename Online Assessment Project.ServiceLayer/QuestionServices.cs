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
        int InsertQuestion(QuestionsViewModel createQuestionsViewModel);
        void EditQuestion(QuestionsViewModel editData);
        void DeleteQuestion(int questionID);
        QuestionsViewModel GetQuestionsByTestId(int questionID);
        IEnumerable<QuestionsViewModel> DisplayAllDetails(int testId);

    }
    public class QuestionServices : IQuestionServices
    {
        IQuestionRepository questionRepository;
        public QuestionServices()
        {
            questionRepository = new QuestionRepository();
        }
        public int InsertQuestion(QuestionsViewModel QuestionsViewModel)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<QuestionsViewModel, Questions>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Questions question = mapper.Map<QuestionsViewModel, Questions>(QuestionsViewModel);
            return questionRepository.InsertQuestion(question);
        }
        public void EditQuestion(QuestionsViewModel editData)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<QuestionsViewModel, Questions>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Questions editQuestion = mapper.Map<QuestionsViewModel, Questions>(editData);
            questionRepository.EditQuestion(editQuestion);
        }
        public void DeleteQuestion(int questionID)
        {
            questionRepository.DeleteQuestion(questionID);
        }
        public QuestionsViewModel GetQuestionsByTestId(int questionID)
        {
            Questions question = questionRepository.GetQuestionsByTestId(questionID);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Questions, QuestionsViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            QuestionsViewModel OriginalData = mapper.Map<Questions, QuestionsViewModel>(question);
            return OriginalData;
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

    
