﻿using AutoMapper;
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
    public class ManageAccessController : Controller
    {
        Const c = new Const();
        private IApplicationBusiness _applicationBusiness;
        private IManageAccessBusiness _manageAccessBusiness;
        private IRolesBusiness _rolesBusiness;
        private IAppObjectBusiness __appObjectBusiness;
        public ManageAccessController(IApplicationBusiness applicationBusiness, IManageAccessBusiness manageAccessBusiness,IRolesBusiness rolesBusiness,IAppObjectBusiness appObjectBusiness)
        {
            _applicationBusiness = applicationBusiness;
            _manageAccessBusiness = manageAccessBusiness;
            _rolesBusiness = rolesBusiness;
            __appObjectBusiness = appObjectBusiness;
        }
        // GET: ManageAccess
        public ActionResult Index()
        {
            ManageAccessViewModel _manageAccessViewModelObj = new ManageAccessViewModel();
            List<SelectListItem> selectListItem = new List<SelectListItem>();
            selectListItem = new List<SelectListItem>();
            string Appid = Request.QueryString["Appid"]!=null? Request.QueryString["Appid"].ToString():"";                      
            List<ApplicationViewModel> ApplicationList = Mapper.Map<List<Application>, List<ApplicationViewModel>>(_applicationBusiness.GetAllApplication());
            foreach (ApplicationViewModel Appl in ApplicationList)
            {
                selectListItem.Add(new SelectListItem
                {
                    Text = Appl.Name,
                    Value = Appl.ID.ToString(),
                    Selected = false
                });
            }
            _manageAccessViewModelObj.ApplicationList = selectListItem;
            selectListItem = new List<SelectListItem>();
            List<RolesViewModel> RoleList = null;
            if (Appid != "" && Appid != null)
            {
                _manageAccessViewModelObj.AppObjectObj = new AppObjectViewModel();
                _manageAccessViewModelObj.AppObjectObj.AppID = Guid.Parse(Appid);
                RoleList = Mapper.Map<List<Roles>, List<RolesViewModel>>(_rolesBusiness.GetAllAppRoles(Guid.Parse(Appid)));
                foreach (RolesViewModel Appl in RoleList)
                {
                    selectListItem.Add(new SelectListItem
                    {
                        Text = Appl.RoleName,
                        Value = Appl.ID.ToString(),
                        Selected = false
                    });
                }
                _manageAccessViewModelObj.RoleList = selectListItem;
                _manageAccessViewModelObj.RoleID = Guid.Parse(RoleList[0].ID.ToString());
            }
           else
            {
                RoleList = Mapper.Map<List<Roles>, List<RolesViewModel>>(_rolesBusiness.GetAllAppRoles(Guid.Empty));
                foreach (RolesViewModel Appl in RoleList)
                {
                    selectListItem.Add(new SelectListItem
                    {
                        Text = Appl.RoleName,
                        Value = Appl.ID.ToString(),
                        Selected = false
                    });
                }
                _manageAccessViewModelObj.RoleList = selectListItem;
            }
            return View(_manageAccessViewModelObj);
        }
        public ActionResult SubobjectIndex(string id)
        {
            ViewBag.objectID = id;
            string Appid = Request.QueryString["appId"].ToString();
            ViewBag.AppID = Appid;
            ManageSubObjectAccessViewModel _manageSubObjectAccessViewModelObj = new ManageSubObjectAccessViewModel();
            List<SelectListItem> selectListItem = new List<SelectListItem>();
            selectListItem = new List<SelectListItem>();
            List<AppObjectViewModel> List = Mapper.Map<List<AppObject>, List<AppObjectViewModel>>(__appObjectBusiness.GetAllAppObjects(Guid.Parse(Appid)));
            foreach (AppObjectViewModel Appl in List)
            {
                if(Appl.ID==Guid.Parse(id))
                {
                    selectListItem.Add(new SelectListItem
                    {

                        Text = Appl.ObjectName,
                        Value = Appl.ID.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    selectListItem.Add(new SelectListItem
                    {

                        Text = Appl.ObjectName,
                        Value = Appl.ID.ToString(),
                        Selected = false
                    });
                }
                
            }
            _manageSubObjectAccessViewModelObj.ObjectList = selectListItem;
            selectListItem = new List<SelectListItem>();
            List<RolesViewModel> RoleList = Mapper.Map<List<Roles>, List<RolesViewModel>>(_rolesBusiness.GetAllAppRoles(Guid.Parse(Appid)));
            foreach (RolesViewModel Appl in RoleList)
            {
                selectListItem.Add(new SelectListItem
                {
                    Text = Appl.RoleName,
                    Value = Appl.ID.ToString(),
                    Selected = false
                });
            }
            _manageSubObjectAccessViewModelObj.RoleList = selectListItem;
            _manageSubObjectAccessViewModelObj.AppObjectObj = new AppObjectViewModel();
            _manageSubObjectAccessViewModelObj.AppObjectObj.ID= Guid.Parse(ViewBag.objectID != null? ViewBag.objectID : Guid.Empty);
            return View(_manageSubObjectAccessViewModelObj);
        }
        [HttpGet]
        public string GetAllAppRoles(string AppID)
        {
            List<SelectListItem> selectListItem = new List<SelectListItem>();
            selectListItem = new List<SelectListItem>();
            List<RolesViewModel> RoleList = Mapper.Map<List<Roles>, List<RolesViewModel>>(_rolesBusiness.GetAllAppRoles(Guid.Parse(AppID)));
            foreach (RolesViewModel Appl in RoleList)
            {
                selectListItem.Add(new SelectListItem
                {
                    Text = Appl.RoleName,
                    Value = Appl.ID.ToString(),
                    Selected = false
                });
            }
            return JsonConvert.SerializeObject(new { Result = "OK", Records = selectListItem });
        }
        [HttpGet]
        public string GetAllObjectAccess(string AppID,string RoleID)
        {
            List<ManageAccessViewModel> ItemList = Mapper.Map<List<ManageAccess>, List<ManageAccessViewModel>>(_manageAccessBusiness.GetAllObjectAccess((AppID!=""?Guid.Parse(AppID):Guid.Empty),(RoleID!=""?Guid.Parse(RoleID):Guid.Empty)));
            return JsonConvert.SerializeObject(new { Result = "OK", Records = ItemList });

        }
        [HttpPost]
        public string AddAccessChanges(ManageAccessViewModel manageAccessViewModelObj)
            {
          
            try
            {
               // if (ModelState.IsValid)
              //  {
                    manageAccessViewModelObj.commonObj = new CommonViewModel();
                    manageAccessViewModelObj.commonObj.CreatedBy = "Thomson";
                    manageAccessViewModelObj.commonObj.CreatedDate = DateTime.Now;
                    foreach (ManageAccessViewModel ManageAccessObj in manageAccessViewModelObj.ManageAccessList)
                    {
                        ManageAccessObj.commonObj = new CommonViewModel();
                        ManageAccessObj.commonObj = manageAccessViewModelObj.commonObj;
                    }
                    ManageAccessViewModel r = Mapper.Map<ManageAccess, ManageAccessViewModel>(_manageAccessBusiness.AddAccessChanges(Mapper.Map<List<ManageAccessViewModel>, List<ManageAccess>>(manageAccessViewModelObj.ManageAccessList)));
                    return JsonConvert.SerializeObject(new { Result = "OK", Message = c.InsertSuccess, Records = r });
               // }

            }
            catch (Exception ex)
            {

                ConstMessage cm = c.GetMessage(ex.Message);
                return JsonConvert.SerializeObject(new { Result = "ERROR", Message = cm.Message });
            }
       
            }
        [HttpGet]
        public string GetAllSubObjectAccess(string ObjectID, string RoleID)
        {
            List<ManageSubObjectAccessViewModel> ItemList = Mapper.Map<List<ManageSubObjectAccess>, List<ManageSubObjectAccessViewModel>>(_manageAccessBusiness.GetAllSubObjectAccess((ObjectID != "" ? Guid.Parse(ObjectID) : Guid.Empty), (RoleID != "" ? Guid.Parse(RoleID) : Guid.Empty)));
            return JsonConvert.SerializeObject(new { Result = "OK", Records = ItemList });

        }

        [HttpPost]
        public string AddSubObjectAccessChanges(ManageSubObjectAccessViewModel manageSubObjectAccessViewModelObj)
        {
         
            try
            {
                //if (ModelState.IsValid)
               // {
                    manageSubObjectAccessViewModelObj.commonObj = new CommonViewModel();
                    manageSubObjectAccessViewModelObj.commonObj.CreatedBy = "Thomson";
                    manageSubObjectAccessViewModelObj.commonObj.CreatedDate = DateTime.Now;
                    foreach (ManageSubObjectAccessViewModel ManageSubObjectAccessObj in manageSubObjectAccessViewModelObj.ManageSubObjectAccessList)
                    {
                        ManageSubObjectAccessObj.commonObj = new CommonViewModel();
                        ManageSubObjectAccessObj.commonObj = manageSubObjectAccessViewModelObj.commonObj;
                    }
                    ManageSubObjectAccessViewModel r = Mapper.Map<ManageSubObjectAccess, ManageSubObjectAccessViewModel>(_manageAccessBusiness.AddSubObjectAccessChanges(Mapper.Map<List<ManageSubObjectAccessViewModel>, List<ManageSubObjectAccess>>(manageSubObjectAccessViewModelObj.ManageSubObjectAccessList)));
                    return JsonConvert.SerializeObject(new { Result = "OK", Message = c.InsertSuccess, Records = r });
                //}

            }
            catch (Exception ex)
            {

                ConstMessage cm = c.GetMessage(ex.Message);
                return JsonConvert.SerializeObject(new { Result = "ERROR", Message = cm.Message });
            }
          
        }
        #region ButtonStyling
        [HttpGet]
        public ActionResult ChangeButtonStyle(string ActionType)
        {
            ToolboxViewModel ToolboxViewModelObj = new ToolboxViewModel();
            switch (ActionType)
            {
                case "Default":

                    ToolboxViewModelObj.backbtn.Visible = true;
                    ToolboxViewModelObj.backbtn.Text = "Back";
                    ToolboxViewModelObj.backbtn.Title = "Back";
                    ToolboxViewModelObj.backbtn.Event = "GobackMangeAccess()";

                    ToolboxViewModelObj.savebtn.Visible = true;
                    ToolboxViewModelObj.savebtn.Disable = true;
                    ToolboxViewModelObj.savebtn.Text = "Save";
                    ToolboxViewModelObj.savebtn.DisableReason = "No changes yet";

                    ToolboxViewModelObj.resetbtn.Visible = true;
                    ToolboxViewModelObj.resetbtn.Disable = true;
                    ToolboxViewModelObj.resetbtn.Text = "Reset";
                    ToolboxViewModelObj.resetbtn.DisableReason = "No changes yet";
                    break;
                case "Checked":

                    ToolboxViewModelObj.backbtn.Visible = true;
                    ToolboxViewModelObj.backbtn.Text = "Back";
                    ToolboxViewModelObj.backbtn.Title = "Back";
                    ToolboxViewModelObj.backbtn.Event = "GobackMangeAccess()";

                    ToolboxViewModelObj.savebtn.Visible = true;
                    ToolboxViewModelObj.savebtn.Title = "Update";
                    ToolboxViewModelObj.savebtn.Text = "Save";
                    ToolboxViewModelObj.savebtn.Event = "SaveChanges();";

                    ToolboxViewModelObj.resetbtn.Visible = true;
                    ToolboxViewModelObj.resetbtn.Title = "Reset Changes";
                    ToolboxViewModelObj.resetbtn.Text = "Reset";
                    ToolboxViewModelObj.resetbtn.Event = "Reset();";
                    break;
                default:
                    return Content("Nochange");
            }
            return PartialView("ToolboxView", ToolboxViewModelObj);
        }

        #endregion
    }
}