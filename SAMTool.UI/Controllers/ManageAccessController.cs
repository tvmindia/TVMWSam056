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
            List<RolesViewModel> RoleList = Mapper.Map<List<Roles>, List<RolesViewModel>>(_rolesBusiness.GetAllAppRoles(null));
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
            return View(_manageSubObjectAccessViewModelObj);
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
            string result = "";
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
            return result;
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
            string result = "";
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
            return result;
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
                    ToolboxViewModelObj.backbtn.Title = "Back to Menu";
                    ToolboxViewModelObj.backbtn.Event = "";

                    ToolboxViewModelObj.savebtn.Visible = true;
                    ToolboxViewModelObj.savebtn.Disable = true;
                    ToolboxViewModelObj.savebtn.Title = "Save Object";
                    ToolboxViewModelObj.savebtn.Text = "Save";
                    ToolboxViewModelObj.savebtn.DisableReason = "Application not selected";
                    ToolboxViewModelObj.savebtn.Event = "";

                    ToolboxViewModelObj.resetbtn.Visible = true;
                    ToolboxViewModelObj.resetbtn.Disable = true;
                    ToolboxViewModelObj.resetbtn.Title = "Reset Object";
                    ToolboxViewModelObj.resetbtn.Text = "Reset";
                    ToolboxViewModelObj.resetbtn.DisableReason = "Application not selected";
                    ToolboxViewModelObj.resetbtn.Event = "";
                    break;
                case "Checked":

                    ToolboxViewModelObj.backbtn.Visible = true;
                    ToolboxViewModelObj.backbtn.Text = "Back";
                    ToolboxViewModelObj.backbtn.Title = "Back Menu";
                    ToolboxViewModelObj.backbtn.Event = "";

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