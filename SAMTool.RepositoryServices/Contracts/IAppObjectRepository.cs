using SAMTool.DataAccessObject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.RepositoryServices.Contracts
{
    public interface IAppObjectRepository
    {
        List<AppObject> GetAllAppObjects(Guid id);
    }
}