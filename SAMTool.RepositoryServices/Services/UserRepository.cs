using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.RepositoryServices.Services
{
    public class UserRepository : IUserRepository
    { 
        private IDatabaseFactory _databaseFactory; 
        public UserRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }
    }
}