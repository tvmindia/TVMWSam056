using AutoMapper;
using SAMTool.BusinessServices.Contracts;
using SAMTool.DataAccessObject.DTO;
using SAMTool.UI.Models;
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
        private IRolesBusiness _rolesBusiness;


        public UserController(IUserBusiness userBusiness,IRolesBusiness rolesBusiness)
        {
            _userBusiness = userBusiness;
            _rolesBusiness = rolesBusiness;
        }

        // GET: User
        public ActionResult User()
        {

            UserViewModel userobj = new UserViewModel();
            userobj.RoleList = Mapper.Map<List<Roles>, List<RolesViewModel>>(_rolesBusiness.GetAllRoles());
            return View(userobj); 
        }
    }
}