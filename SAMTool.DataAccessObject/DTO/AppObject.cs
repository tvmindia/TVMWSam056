using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.DataAccessObject.DTO
{
    public class AppObject
    {
        public Guid ID { get; set; }
        public Guid AppID { get; set; }
        public string ObjectName { get; set; }
        public Common commonDetails { get; set; } 
    }
}