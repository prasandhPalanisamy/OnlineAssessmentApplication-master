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
    public interface IAnswerService
    {
        void InsertAnswer(QuestionsViewModel createQuestionsViewModel);
        List<QuestionsViewModel> GetAnswersByQuestionID(int questionID);
    }
    public class AnswerService
    {
        AnswerRepository answerRepository;
        public AnswerService()
        {
            answerRepository = new AnswerRepository();
        }
        public void InsertAnswer(AnswerViewModel answerView)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<AnswerViewModel, Answer>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Answer answer = mapper.Map<AnswerViewModel, Answer>(answerView);
            answerRepository.InsertAnswer(answer);
        }
        public List<AnswerViewModel> GetAnswersByQuestionID(int questionID)
        {            
            List<Answer> ans =  answerRepository.GetAnswersByQuestionID(questionID);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<List<Answer>, List<AnswerViewModel>>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<AnswerViewModel> answer = mapper.Map<List<Answer>,List<AnswerViewModel>>(ans);
            return answer;
        }
    }

}
