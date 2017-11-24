using SAMTool.DataAccessObject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMTool.RepositoryServices.Contracts
{
    public interface IUserRepository
    {
        List<User> GetAllUsers(Guid? AppID);
        object InsertUser(User userObj);
        object UpdateUser(User userObj);
        object DeleteUser(User userObj);
        string GetObjectAccess(string LoggedUser, string ObjectName, Guid AppID);
        List<SubPermission> GetSubObjectAccess(string LoggedUser, string ObjectName, Guid AppID);
    }
}
