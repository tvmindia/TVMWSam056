using SAMTool.BusinessServices.Contracts;
using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAMTool.DataAccessObject.DTO;

namespace SAMTool.BusinessServices.Services
{
    public class PrivilegesBusiness:IPrivilegesBusiness
    {
        private IPrivilegesRepository _privillegesRepository;

        public PrivilegesBusiness(IPrivilegesRepository privillegesRepository)
        {
            _privillegesRepository = privillegesRepository;
        }

        public object DeletePrivileges(Privileges PrivilegesObj)
        {
            object result = null;
            try
            {
                result = _privillegesRepository.DeletePrivileges(PrivilegesObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<Privileges> GetAllPrivileges()
        {
            List<Privileges> List = null;
            try
            {
                List = _privillegesRepository.GetAllPrivileges();               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return List;
        }

        public Privileges GetPrivilegesDetailsByID(string id)
        {
            List<Privileges> List = null;

            try
            {
                List = _privillegesRepository.GetAllPrivileges();
                List = List.Where(j => j.ID == Guid.Parse(id)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return List[0];
        }

        public object InsertPrivileges(Privileges PrivilegesObj)
        {
            object result = null;
            try
            { 
                result = _privillegesRepository.InsertPrivileges(PrivilegesObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public object UpdatePrivileges(Privileges PrivilegesObj)
        {
            object result = null;
            try
            {
                result = _privillegesRepository.UpdatePrivileges(PrivilegesObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}