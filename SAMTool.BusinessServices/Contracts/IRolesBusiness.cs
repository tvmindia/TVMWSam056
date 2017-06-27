using SAMTool.DataAccessObject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMTool.BusinessServices.Contracts
{
    public interface IRolesBusiness
    { 
        List<Roles> GetAllRoles(); 
        object InsertRoles(Roles RolesObj);
        object UpdateRoles(Roles RolesObj);
        Roles GetRolesDetailsByID(string id);
        object DeleteRoles(Roles RolesObj);
    }
}
