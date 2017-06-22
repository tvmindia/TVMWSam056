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

        #region GetAllRolesByApplication
        [HttpGet] 
        public string GetAllRoles(string AppId)
        {
            try
            {

                List<RolesViewModel> rolesVMLisit = Mapper.Map<List<Roles>, List<RolesViewModel>>(_rolesBusiness.GetAllRoles());
                return JsonConvert.SerializeObject(new { Result = "OK", Records = rolesVMLisit });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion GetAllRolesByApplication
    }
}