﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.UI.Models
{
    public class CommonViewModel
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestr { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedDatestr { get; set; }
    }
}