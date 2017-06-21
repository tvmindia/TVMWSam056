using SAMTool.BusinessServices.Contracts;
using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.BusinessServices.Services
{
    public class RolesBusiness: IRolesBusiness
    {       
        private IRolesRepository _rolesRepository;

        public RolesBusiness(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

    }
}