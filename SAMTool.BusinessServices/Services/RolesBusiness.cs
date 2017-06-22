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
    }
}