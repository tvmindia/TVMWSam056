using SAMTool.BusinessServices.Contracts;
using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAMTool.DataAccessObject.DTO;

namespace SAMTool.BusinessServices.Services
{
    public class RolesBusiness: IRolesBusiness
    {       
        private IRolesRepository _rolesRepository;

        public RolesBusiness(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public object DeleteRoles(Roles RolesObj)
        {
            object result = null;
            try
            {
                result = _rolesRepository.DeleteRoles(RolesObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<Roles> GetAllRoles()
        {
            List<Roles> RoleList = null;
            try
            {
                RoleList = _rolesRepository.GetAllRoles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RoleList; 
        }

        public Roles GetRolesDetailsByID(string id)
        {
            List<Roles> RolesList = null;

            try
            {
                RolesList = _rolesRepository.GetAllRoles();
                RolesList = RolesList.Where(j => j.ID == Guid.Parse(id)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RolesList[0];
        }

        public object InsertRoles(Roles RolesObj)
        {
            object result = null;
            try
            {
                result = _rolesRepository.InsertRoles(RolesObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public object UpdateRoles(Roles RolesObj)
        {
            object result = null;
            try
            {
                result = _rolesRepository.UpdateRoles(RolesObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}