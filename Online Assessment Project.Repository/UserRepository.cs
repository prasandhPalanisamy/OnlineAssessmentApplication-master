using Online_Assessment_Project.DomainModel;
using Online_Assessment_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Online_Assessment_Project.Repository
{
    public interface IUserRepository
    {
        List<User> ValidateUser(UserViewModel viewModel);
        void Create(User user);
        List<User> Display();
        void Delete(int Id);
        User Edit(int Id);
        void Update(User user);
    }
    public class UserRepository : IUserRepository
    {
        AssessmentPortalDbContext db;
        User User;
        


        public UserRepository()
        {
            db = new AssessmentPortalDbContext();
            User = new User();
        }
        public List<User> ValidateUser(UserViewModel viewModel)
        {
            return db.User.Where(temp => temp.EmailID == viewModel.EmailID && temp.Password == viewModel.Password).ToList();
        }
        public void Create(User user)
        {

            try
            {
                user.CreatedDate = DateTime.Now.ToShortDateString();
                db.User.Add(user);
                db.SaveChanges();
                
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public List<User> Display()
        {

            List<User> data = db.User.ToList();
            return (data);

        }
        public void Delete(int Id)
        {
            
                User user = db.User.Find(Id);
                db.User.Remove(user);
                db.SaveChanges();
           
        }
        public void Update(User user)
        {
            
            user.ModifiedDate = DateTime.Now.ToShortDateString();
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            
        }
        public User Edit(int Id)
        {
            
                User user = db.User.Find(Id);
                return user;
           

        }


    }
}
