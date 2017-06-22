using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAMTool.UI.Models
{
    public class AppObjectViewModel
    {
        public Guid ID { get; set; }
        public Guid AppID { get; set; }
        public string ObjectName { get; set; }
        public CommonViewModel commonViewDetails { get; set; }
        public List<SelectListItem> ApplicationList { get; set; }
    }
}