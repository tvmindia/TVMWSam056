using AutoMapper;
using SAMTool.BusinessServices.Contracts;
using SAMTool.DataAccessObject.DTO;
using SAMTool.UI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SAMTool.UI.Controllers
{
    public class HomeController : Controller
    {
        IHomeBusiness _homeBusiness;
        public HomeController(IHomeBusiness home)
        {
            _homeBusiness = home;
        }
        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            List<SysMenuViewModel> SysMenuViewModelList= Mapper.Map<List<SysMenu>, List<SysMenuViewModel>>(_homeBusiness.GetAllSysLinks());
            homeViewModel._LHSSysMenuViewModel = SysMenuViewModelList != null ? SysMenuViewModelList.Where(s => s.Type == "LHS").ToList():new List<SysMenuViewModel>();
            homeViewModel._RHSSysMenuViewModel= SysMenuViewModelList != null ? SysMenuViewModelList.Where(s => s.Type == "RHS").ToList(): new List<SysMenuViewModel>();
            return View(homeViewModel);
        }
    }
}