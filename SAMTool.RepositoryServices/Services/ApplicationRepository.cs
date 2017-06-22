using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.RepositoryServices.Services
{
    public class ApplicationRepository: IApplicationRepository
    {
        private IDatabaseFactory _databaseFactory;
        public ApplicationRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }


    }
}