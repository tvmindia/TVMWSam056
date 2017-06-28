using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.UI.Models
{
    public class PrivillegesViewModel
    {
        public Guid ID { get; set; }
        public Guid RoleID { get; set; }
        public Guid AppID { get; set; }
        public string ModuleName { get; set; }
        public string AccessDescription { get; set; }
        public CommonViewModel commonDetails { get; set; }
    }
}