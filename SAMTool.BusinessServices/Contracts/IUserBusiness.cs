using SAMTool.DataAccessObject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMTool.BusinessServices.Contracts
{
     public interface IUserBusiness
    {
        List<User> GetAllUsers();
        object InsertUser(User userObj);
        object UpdateUser(User userObj);
       User GetUserDetailsByID(string id);
        object DeleteUser(User userObj);
        User CheckUserCredentials(User user);
        string GetSecurityCode(string UserName,string ProjectObject);
    }
}
