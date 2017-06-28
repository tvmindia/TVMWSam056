using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.DataAccessObject.DTO
{
    public class Privileges
    { 
        public Guid ID { get; set; }
        public Guid RoleID { get; set; }
        public Guid AppID { get; set; }

        public string ApplicationName { get; set; }
        public string RoleName { get; set; }
        public string ModuleName { get; set; }
        public string AccessDescription { get; set; } 
        public Common commonDetails { get; set; } 
    }
}