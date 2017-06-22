using SAMTool.BusinessServices.Contracts;
using SAMTool.DataAccessObject.DTO;
using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.BusinessServices.Services
{
    public class ApplicationBusiness: IApplicationBusiness
    {
        private IApplicationRepository _applicationRepository;

        public ApplicationBusiness(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
        public List<Application> GetAllApplication()
        {
            return _applicationRepository.GetAllApplication();
        }

    }
}