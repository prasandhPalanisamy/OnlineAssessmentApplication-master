using Online_Assessment_Project.DomainModel;
using Online_Assessment_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Assessment_Project.ServiceLayer
{
    public interface IRoleServices
    {
        List<Role> Display();
    }
        public class RoleServices:IRoleServices
    {
        IRoleRepository RoleRepository;
        public RoleServices()
        {
            RoleRepository = new RoleRepository();
        }
        public List<Role> Display()
        {
            return (RoleRepository.Display());
        }
    }
}
