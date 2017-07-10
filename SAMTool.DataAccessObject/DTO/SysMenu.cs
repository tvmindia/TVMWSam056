using System;

namespace SAMTool.DataAccessObject.DTO
{
    public class SysMenu
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