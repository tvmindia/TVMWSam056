using SAMTool.BusinessServices.Contracts;
using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.BusinessServices.Services
{
    public class UserBusiness : IUserBusiness
    {
        private IUserRepository _userRepository;
      
        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

    }
}