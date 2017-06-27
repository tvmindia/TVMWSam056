using SAMTool.DataAccessObject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMTool.RepositoryServices.Contracts
{
    public interface IApplicationRepository
    {
        List<Application> GetAllApplication();

        object InsertApplication(Application appObj);
        object UpdateApplication(Application appObj);
        object DeleteApplication(Application appObj);
    }
}
