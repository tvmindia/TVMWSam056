using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.RepositoryServices.Services
{
    public class PrivillegesRepository: IPrivillegesRepository
    {
        private IDatabaseFactory _databaseFactory;
        public PrivillegesRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }




    }
}