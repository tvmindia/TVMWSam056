using SAMTool.DataAccessObject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMTool.RepositoryServices.Contracts
{
    public interface IRolesRepository
    {
        List<Roles> GetAllAppRoles(Guid? id);
        object InsertRoles(Roles RolesObj);
        object UpdateRoles(Roles RolesObj); 
        object DeleteRoles(Roles RolesObj);
       
    }
}
