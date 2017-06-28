using SAMTool.DataAccessObject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMTool.BusinessServices.Contracts
{
    public interface IPrivilegesBusiness
    {
        
        List<Privileges> GetAllPrivileges();
        object InsertPrivileges(Privileges userObj);
        object UpdatePrivileges(Privileges userObj);
        Privileges GetPrivilegesDetailsByID(string id);
        object DeletePrivileges(Privileges userObj);

    }
}
