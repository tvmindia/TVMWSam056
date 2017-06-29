using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.DataAccessObject.DTO
{
    public class ManageAccess
    {
        public Guid ID { get; set; }
        public Guid ObjectID { get; set; }
        public Guid RoleID { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Delete { get; set; }
        public bool Special { get; set; }
    }
}