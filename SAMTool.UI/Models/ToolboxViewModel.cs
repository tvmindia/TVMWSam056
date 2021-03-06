﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAMTool.UI.Models
{
    public class ToolboxViewModel
    {
        public ToolBoxStructure backbtn;
        public ToolBoxStructure addbtn;
        public ToolBoxStructure savebtn;
        public ToolBoxStructure deletebtn;
        public ToolBoxStructure resetbtn;        
        public ToolBoxStructure returnBtn;
        public ToolBoxStructure calculateBtn;
        public ToolBoxStructure PrintBtn;
    }

    public struct ToolBoxStructure
    {
        public string Event { get; set; }
        public string Title { get; set; }//tooltip
        public string Text { get; set; }
        public string DisableReason { get; set; }
        public bool Visible { get; set; }
        public bool Disable { get; set; }
    }

    public class ToolBox
    {
        public string Dom { get; set; }
        public string Action { get; set; }
        public string ViewModel { get; set; }
    }

}