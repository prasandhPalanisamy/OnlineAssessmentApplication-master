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
        public IEnumerable<AnswerViewModel> DisplayAnswers(int questionId)
        {
            IEnumerable<Answer> answers = answerRepository.DisplayAnswers(questionId);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Answer, AnswerViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            IEnumerable<AnswerViewModel> allAnswers = mapper.Map<IEnumerable<Answer>, IEnumerable<AnswerViewModel>>(answers);
            return allAnswers;
        }
        public void EditAnswer(AnswerViewModel editedData)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<AnswerViewModel, Answer>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Answer editAnswer = mapper.Map<AnswerViewModel, Answer>(editedData);
            answerRepository.EditAnswer(editAnswer);
        }
        public void DeleteAnswer(int questionId)
        {
            answerRepository.DeleteAnswer(questionId);
        }

        public AnswerViewModel GetAnswersByQuestionID(int questionID)
        {            
            Answer answer =  answerRepository.GetAnswersByQuestionID(questionID);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Answer, AnswerViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            AnswerViewModel OriginalData = mapper.Map<Answer, AnswerViewModel>(answer);
            return OriginalData;
        }
    }

}
