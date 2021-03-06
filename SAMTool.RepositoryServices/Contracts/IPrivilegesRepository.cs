﻿using SAMTool.DataAccessObject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMTool.RepositoryServices.Contracts
{
    public interface IPrivilegesRepository
    {
        List<Privileges> GetAllPrivileges();
        object InsertPrivileges(Privileges userObj);
        object UpdatePrivileges(Privileges userObj); 
        object DeletePrivileges(Privileges userObj);
    }
}
