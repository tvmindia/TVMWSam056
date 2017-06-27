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

        public object DeleteApplication(Application appObj)
        {
            object result = null;
            try
            {
                result = _applicationRepository.DeleteApplication(appObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<Application> GetAllApplication()
        {
            return _applicationRepository.GetAllApplication();
        }

        public object InsertApplication(Application appObj)
        {
            object result = null;
            try
            { 
                result = _applicationRepository.InsertApplication(appObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public object UpdateApplication(Application appObj)
        {
            object result = null;
            try
            {
                result = _applicationRepository.UpdateApplication(appObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }
    }
}