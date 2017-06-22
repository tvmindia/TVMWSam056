using SAMTool.BusinessServices.Contracts;
using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAMTool.DataAccessObject.DTO;

namespace SAMTool.BusinessServices.Services
{
    public class UserBusiness : IUserBusiness
    {
        private IUserRepository _userRepository;
      
        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            List<User> UserList = null;
            try
            {
                UserList = _userRepository.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserList;
        }
    }
}