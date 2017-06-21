using SAMTool.BusinessServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.BusinessServices.Services
{
    public class Home:IHome
    {
        public string show()
        {
            return "Albert Thomson";
        }

       
    }
}