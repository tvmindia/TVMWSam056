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
    public class AppObjectController : Controller
    {
        Const c = new Const();
        IApplicationBusiness _applicationBusiness;
        IAppObjectBusiness _appObjectBusiness;
        public AppObjectController(IApplicationBusiness applicationBusiness,IAppObjectBusiness appObjectBusiness)
        {
            _applicationBusiness = applicationBusiness;
            _appObjectBusiness = appObjectBusiness;
        }
        // GET: AppObject
        public ActionResult Index()
        {
            if (Request.QueryString["appId"] != null)
            {
                string Appid = Request.QueryString["appId"].ToString();
                ViewBag.AppID = Appid;
            } 

            AppObjectViewModel _appObjectViewModelObj = new AppObjectViewModel();
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
            _appObjectViewModelObj.ApplicationList = selectListItem;
            return View(_appObjectViewModelObj);
        }

        public ActionResult Subobjects(string id)
        {
            ViewBag.objectID = id;
            string Appid = Request.QueryString["appId"].ToString();
            ViewBag.AppID = Appid;

            AppSubobjectViewmodel _appObjectViewModelObj = new AppSubobjectViewmodel();
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
            _appObjectViewModelObj.ApplicationList = selectListItem;

            selectListItem = new List<SelectListItem>();
            List<AppObjectViewModel> List = Mapper.Map<List<AppObject>, List<AppObjectViewModel>>(_appObjectBusiness.GetAllAppObjects(Guid.Parse(Appid)));
            foreach (AppObjectViewModel Appl in List)
            {
                selectListItem.Add(new SelectListItem
                {
                    Text = Appl.ObjectName,
                    Value = Appl.ID.ToString(),
                    Selected = false
                });
            }
            _appObjectViewModelObj.ObjectList = selectListItem;

            return View(_appObjectViewModelObj);
        }


        [HttpGet]
        public string GetAllAppObjects(string id)
        {
            List<AppObjectViewModel> ItemList = Mapper.Map<List<AppObject>, List<AppObjectViewModel>>(_appObjectBusiness.GetAllAppObjects(Guid.Parse(id)));
            return JsonConvert.SerializeObject(new { Result = "OK", Records = ItemList });

        }
        [HttpPost]
        public string DeleteObject(AppObjectViewModel AppObjectObj)
        {
            string result = "";

            try
            {
               
                    AppObjectViewModel r = Mapper.Map<AppObject, AppObjectViewModel>(_appObjectBusiness.DeleteObject(Mapper.Map<AppObjectViewModel, AppObject>(AppObjectObj)));
                    return JsonConvert.SerializeObject(new { Result = "OK", Message = c.DeleteSuccess, Records = r });
           

            }
            catch (Exception ex)
            {

                ConstMessage cm = c.GetMessage(ex.Message);
                return JsonConvert.SerializeObject(new { Result = "ERROR", Message = cm.Message });
            }
            return result;
        }
        [HttpPost]
        public string InserUpdateObject(AppObjectViewModel AppObjectObj)
        {
            string result = "";

            try
            {
                if (ModelState.IsValid)
                {

                    AppObjectObj.commonDetails = new CommonViewModel();
                    AppObjectObj.commonDetails.CreatedBy = "Thomson";
                    AppObjectObj.commonDetails.CreatedDate = DateTime.Now;
                    AppObjectObj.commonDetails.UpdatedBy = "Thomson";
                    AppObjectObj.commonDetails.UpdatedDate = DateTime.Now;
                    AppObjectViewModel r = Mapper.Map<AppObject, AppObjectViewModel>(_appObjectBusiness.InsertUpdate(Mapper.Map<AppObjectViewModel, AppObject>(AppObjectObj)));
                    return JsonConvert.SerializeObject(new { Result = "OK", Message =c.InsertSuccess, Records = r });
                }

            }
            catch (Exception ex)
            {

                ConstMessage cm = c.GetMessage(ex.Message);
                return JsonConvert.SerializeObject(new { Result = "ERROR", Message = cm.Message });
            }
            return result;
        }

        //-----------------Sub-Object Methods-------------------
        [HttpPost]
        public string InserUpdateSubobject(AppSubobjectViewmodel AppObjectObj)
        {
            string result = ""; 
            try
            {
                if (ModelState.IsValid)
                {
                    AppObjectObj.commonDetails = new CommonViewModel();
                    AppObjectObj.commonDetails.CreatedBy = "Thomson";
                    AppObjectObj.commonDetails.CreatedDate = DateTime.Now;
                    AppObjectObj.commonDetails.UpdatedBy = "Thomson";
                    AppObjectObj.commonDetails.UpdatedDate = DateTime.Now;
                    AppSubobjectViewmodel res = Mapper.Map<AppSubobject, AppSubobjectViewmodel>(_appObjectBusiness.InsertUpdateSubObject(Mapper.Map<AppSubobjectViewmodel, AppSubobject>(AppObjectObj)));
                    return JsonConvert.SerializeObject(new { Result = "OK", Message = c.InsertSuccess, Records = res });
                }

            }
            catch (Exception ex)
            {

                ConstMessage cm = c.GetMessage(ex.Message);
                return JsonConvert.SerializeObject(new { Result = "ERROR", Message = cm.Message });
            }
            return result;
        }
        [HttpGet]
        public string GetAllAppSubObjects(string ID)
        {
            List<AppSubobjectViewmodel> ItemList = Mapper.Map<List<AppSubobject>, List<AppSubobjectViewmodel>>(_appObjectBusiness.GetAllAppSubObjects(ID));
            return JsonConvert.SerializeObject(new { Result = "OK", Records = ItemList });

        }
        [HttpPost]
        public string DeleteSubObject(AppSubobjectViewmodel AppObjectObj)
        {
            string result = "";

            try
            {
               
                    AppSubobjectViewmodel r = Mapper.Map<AppSubobject, AppSubobjectViewmodel>(_appObjectBusiness.DeleteSubObject(Mapper.Map<AppSubobjectViewmodel, AppSubobject>(AppObjectObj)));
                    return JsonConvert.SerializeObject(new { Result = "OK", Message = c.DeleteSuccess, Records = r });
             
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
                case "List":
                    ToolboxViewModelObj.addbtn.Visible = true;
                    ToolboxViewModelObj.addbtn.Disable = true;
                    ToolboxViewModelObj.addbtn.DisableReason = "No Application selected";
                    ToolboxViewModelObj.addbtn.Text = "Add";
                    ToolboxViewModelObj.addbtn.Title = "Add New";
                    ToolboxViewModelObj.addbtn.Event = "AddNewObject()";

                    ToolboxViewModelObj.backbtn.Visible = true;
                    ToolboxViewModelObj.backbtn.Text = "Back";
                    ToolboxViewModelObj.backbtn.Title = "Back to list";
                    ToolboxViewModelObj.backbtn.Event = "goHome()";

                    //ToolboxViewModelObj.savebtn.Visible = true;
                    //ToolboxViewModelObj.savebtn.Disable = true;
                    //ToolboxViewModelObj.savebtn.Title = "Save Object";
                    //ToolboxViewModelObj.savebtn.Text = "Save";
                    //ToolboxViewModelObj.savebtn.DisableReason = "No Application selected";
                    //ToolboxViewModelObj.savebtn.Event = "";

                    //ToolboxViewModelObj.resetbtn.Visible = true;
                    //ToolboxViewModelObj.resetbtn.Disable = true;
                    //ToolboxViewModelObj.resetbtn.Title = "Reset Object";
                    //ToolboxViewModelObj.resetbtn.Text = "Reset";
                    //ToolboxViewModelObj.resetbtn.DisableReason = "No Application selected";
                    //ToolboxViewModelObj.resetbtn.Event = "";
                    break;
                case "select":
                    ToolboxViewModelObj.addbtn.Visible = true;
                    ToolboxViewModelObj.addbtn.Text = "Add";
                    ToolboxViewModelObj.addbtn.Title = "Add New";
                    ToolboxViewModelObj.addbtn.Event = "AddNewObject()";

                    ToolboxViewModelObj.backbtn.Visible = true;
                    ToolboxViewModelObj.backbtn.Text = "Back";
                    ToolboxViewModelObj.backbtn.Title = "Back to list";
                    ToolboxViewModelObj.backbtn.Event = "goHome()";

                    //ToolboxViewModelObj.savebtn.Visible = true;
                    //ToolboxViewModelObj.savebtn.Disable = true;
                    //ToolboxViewModelObj.savebtn.Title = "Save Object";
                    //ToolboxViewModelObj.savebtn.Text = "Save";
                    //ToolboxViewModelObj.savebtn.DisableReason = "No Application selected";
                    //ToolboxViewModelObj.savebtn.Event = "";

                    //ToolboxViewModelObj.resetbtn.Visible = true;
                    //ToolboxViewModelObj.resetbtn.Disable = true;
                    //ToolboxViewModelObj.resetbtn.Title = "Reset Object";
                    //ToolboxViewModelObj.resetbtn.Text = "Reset";
                    //ToolboxViewModelObj.resetbtn.DisableReason = "No Application selected";
                    //ToolboxViewModelObj.resetbtn.Event = "";

                    break;
                case "Edit":
                    ToolboxViewModelObj.addbtn.Visible = true;
                    ToolboxViewModelObj.addbtn.Text = "Add";
                    ToolboxViewModelObj.addbtn.Title = "Add New";
                    ToolboxViewModelObj.addbtn.Event = "AddNewObject()";

                    ToolboxViewModelObj.backbtn.Visible = true;
                    ToolboxViewModelObj.backbtn.Text = "Back";
                    ToolboxViewModelObj.backbtn.Title = "Back to list";
                    ToolboxViewModelObj.backbtn.Event = "goback()";

                    ToolboxViewModelObj.savebtn.Visible = true;
                    ToolboxViewModelObj.savebtn.Title = "Save Object";
                    ToolboxViewModelObj.savebtn.Text = "Save";
                    ToolboxViewModelObj.savebtn.Event = "$('#btnSave').trigger('click');";

                    ToolboxViewModelObj.resetbtn.Visible = true;
                    ToolboxViewModelObj.resetbtn.Title = "Reset Object";
                    ToolboxViewModelObj.resetbtn.Text = "Reset";
                    ToolboxViewModelObj.resetbtn.Event = "Reset()";

                    break;
                case "AddSub":
                    ToolboxViewModelObj.backbtn.Visible = true;
                    ToolboxViewModelObj.backbtn.Text = "Back";
                    ToolboxViewModelObj.backbtn.Title = "Back to list";
                    ToolboxViewModelObj.backbtn.Event = "GoBack()";

                    ToolboxViewModelObj.savebtn.Visible = true;
                    ToolboxViewModelObj.savebtn.Title = "Save Object";
                    ToolboxViewModelObj.savebtn.Text = "Save";
                    ToolboxViewModelObj.savebtn.Event = "$('#btnSave').trigger('click');";

                    ToolboxViewModelObj.resetbtn.Visible = true;
                    ToolboxViewModelObj.resetbtn.Title = "Reset Object";
                    ToolboxViewModelObj.resetbtn.Text = "Reset";
                    ToolboxViewModelObj.resetbtn.Event = "Reset()";
                    break;
                case "tab1":

                    break;
                case "tab2":

                    break;
                default:
                    return Content("Nochange");
            }
            return PartialView("ToolboxView", ToolboxViewModelObj);
        }

        #endregion
    }
}