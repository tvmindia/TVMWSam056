using SAMTool.DataAccessObject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.BusinessServices.Contracts
{
    public interface IManageAccessBusiness
    {
        List<ManageAccess> GetAllObjectAccess(Guid AppID, Guid RoleID);
        ManageAccess AddAccessChanges(List<ManageAccess> ManageAccessList);
    }
}