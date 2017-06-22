using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.RepositoryServices.Services
{
    public class AppObjectRepository:IAppObjectRepository
    {
        private IDatabaseFactory _databaseFactory;
        public AppObjectRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }
    }
}