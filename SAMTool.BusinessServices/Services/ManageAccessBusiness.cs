using SAMTool.BusinessServices.Contracts;
using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.BusinessServices.Services
{
    public class ManageAccessBusiness:IManageAccessBusiness
    {
        private IManageAccessRepository _manageAccessRepository;

        public ManageAccessBusiness(IManageAccessRepository manageAccessRepository)
        {
            _manageAccessRepository = manageAccessRepository;
        }
        
    }
}