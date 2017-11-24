using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.DataAccessObject.DTO
{
    public class User
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string RoleList { get; set; }
        public string RoleCSV { get; set; }
        public string RoleIDCSV { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public Guid? AppID { get; set; }
        public Common commonDetails { get; set; }


    }
    public class Permission
    {
        public string Name { get; set; }
        public string AccessCode { get; set; }
        public List<SubPermission> SubPermissionList { get; set; }
    }
    public class SubPermission
    {
        public string Name { get; set; }
        public string AccessCode { get; set; }
    }
}