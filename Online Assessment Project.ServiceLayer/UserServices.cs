using AutoMapper;
using Online_Assessment_Project.DomainModel;
using Online_Assessment_Project.Repository;
using Online_Assessment_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_Assessment_Project.ServiceLayer
{
    public interface IUserServices
    {
        UserViewModel ValidateUser(UserViewModel user);
        void Create(User user);
        void Delete(int UserId);
        User Edit(int UserId);

        void Update(User user);
        List<User> Display();
    }
    public class UserServices : IUserServices
    {
        IUserRepository userRepository;
        public UserServices()
        {
            userRepository = new UserRepository();
        }
        public UserViewModel ValidateUser(UserViewModel user)
        {
            User fetchedData= userRepository.ValidateUser(user).FirstOrDefault();
            UserViewModel sensitiveData = null;
            if (fetchedData != null)
            {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            sensitiveData = mapper.Map<User, UserViewModel>(fetchedData);
            }
            return sensitiveData;
            

        }
        public void Create(User user)
        {
            user.CreatedDate = DateTime.Now.ToShortDateString();
            userRepository.Create(user);
        }
        public void Delete(int UserId)
        {
            userRepository.Delete(UserId);
        }
        public User Edit(int UserId)
        {
            return userRepository.Edit(UserId);
        }
        public void Update(User user)
        {
            string temp;
            user.ModifiedDate = DateTime.Now.ToShortDateString();
            temp = user.CreatedDate;
            user.CreatedDate = temp;
            userRepository.Update(user);
        }

        public List<User> Display()
        {
            return (userRepository.Display());
        }
    }
}
