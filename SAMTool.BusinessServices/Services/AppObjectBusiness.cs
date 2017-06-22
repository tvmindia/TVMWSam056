using SAMTool.BusinessServices.Contracts;
using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.BusinessServices.Services
{
    public class AppObjectBusiness:IAppObjectBusiness
    {
        private IAppObjectRepository _appObjectRepository;

        public AppObjectBusiness(IAppObjectRepository appObjectRepository)
        {
            _appObjectRepository = appObjectRepository;
        }
    }
}