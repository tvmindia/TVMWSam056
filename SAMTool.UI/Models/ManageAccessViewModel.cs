using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAMTool.UI.Models
{
    public class ManageAccessViewModel
    {
        public Guid ID { get; set; }
        public Guid ObjectID { get; set; }
        public Guid RoleID { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Delete { get; set; }
        public bool Special { get; set; }
        public CommonViewModel commonObj { get; set; }
        public AppObjectViewModel AppObjectObj { get; set; }
        public List<ManageAccessViewModel> ManageAccessList { get; set; }
        public List<SelectListItem> ApplicationList { get; set; }
        public List<SelectListItem> RoleList { get; set; }
    }
}