using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.RepositoryServices.Services
{
    public class ManageAccessRepository: IManageAccessRepository
    {
        private IDatabaseFactory _databaseFactory;
        public ManageAccessRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }
    }
}