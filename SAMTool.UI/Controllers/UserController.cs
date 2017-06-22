using AutoMapper;
using Newtonsoft.Json;
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
        public  ActionResult Index()
        {

            UserViewModel userobj = new UserViewModel();
            userobj.RoleList = Mapper.Map<List<Roles>, List<RolesViewModel>>(_rolesBusiness.GetAllRoles());
            return View(userobj); 
        }


        #region GetAllUsers
        [HttpGet]
        public string GetAllUsers()
        {
            try
            {

                List<UserViewModel> userList = Mapper.Map<List<User>, List<UserViewModel>>(_userBusiness.GetAllUsers());
                return JsonConvert.SerializeObject(new { Result = "OK", Records = userList });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion GetAllUsers
    }
}