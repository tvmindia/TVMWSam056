using SAMTool.BusinessServices.Contracts;
using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.BusinessServices.Services
{
    public class PrivillegesBusiness:IPrivillegesBusiness
    {
        private IPrivillegesRepository _PrivillegesRepository;

        public PrivillegesBusiness(IPrivillegesRepository PrivillegesRepository)
        {
            _PrivillegesRepository = PrivillegesRepository;
        }
    }
}