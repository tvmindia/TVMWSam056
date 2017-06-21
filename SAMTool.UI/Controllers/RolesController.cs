using SAMTool.BusinessServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAMTool.UI.Controllers
{
    public class RolesController : Controller
    {

        private IRolesBusiness _rolesBusiness;

        public RolesController(IRolesBusiness rolesBusiness)
        {
            _rolesBusiness = rolesBusiness;
        }


        // GET: Roles
        public ActionResult Roles()
        {
            return View();
        }
    }
}