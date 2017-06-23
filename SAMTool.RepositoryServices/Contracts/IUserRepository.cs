﻿using SAMTool.DataAccessObject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMTool.RepositoryServices.Contracts
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        object InsertUser(User userObj);
        object UpdateUser(User userObj);
    }
}
