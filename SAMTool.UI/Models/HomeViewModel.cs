﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.UI.Models
{
    public class HomeViewModel
    {
       public List<SysMenuViewModel> _LHSSysMenuViewModel { get; set; }
       public List<SysMenuViewModel> _RHSSysMenuViewModel { get; set; }

    }
    public class SysMenuViewModel
    {
        public Guid ID { get; set; }
        public string LinkName { get; set; }
        public string LinkDescription { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Type { get; set; }
        public int Order { get; set; }
    }
    
}