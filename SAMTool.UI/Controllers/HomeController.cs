using SAMTool.BusinessServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAMTool.UI.Controllers
{
    public class HomeController : Controller
    {
        IHome _home;
        public HomeController(IHome home)
        {
            _home = home;
        }
        // GET: Home
        public ActionResult Index()
        {
            @ViewBag.name=_home.show();
            return View();
        }
    }
}