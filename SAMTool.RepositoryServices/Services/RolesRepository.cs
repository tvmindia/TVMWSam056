﻿using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAMTool.DataAccessObject.DTO;

namespace SAMTool.RepositoryServices.Services
{
    public class RolesRepository: IRolesRepository
    {
        private IDatabaseFactory _databaseFactory;
        public RolesRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public List<Roles> GetAllRoles()
        {
            throw new NotImplementedException();
        }
    }
}