using SAMTool.BusinessServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAMTool.UI.Controllers
{
    public class UserController : Controller
    {

        private IUserBusiness _userBusiness;
        
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        // GET: User
        public ActionResult User()
        {
            return View();
        }
    }
}