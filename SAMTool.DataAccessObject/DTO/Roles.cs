using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.DataAccessObject.DTO
{
    public class Roles
    {
        public Guid? ID { get; set; }

        public Guid? AppID { get; set; }

        public User user { get; set; }
        public string ApplicationName { get; set; }

        public string RoleName { get; set; }
 
        public string RoleDescription { get; set; }

        public Common commonDetails { get; set; }
    }
}