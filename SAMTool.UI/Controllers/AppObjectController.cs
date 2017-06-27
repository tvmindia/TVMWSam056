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
                if (ModelState.IsValid)
                {
                    AppObjectViewModel r = Mapper.Map<AppObject, AppObjectViewModel>(_appObjectBusiness.DeleteObject(Mapper.Map<AppObjectViewModel, AppObject>(AppObjectObj)));
                    return JsonConvert.SerializeObject(new { Result = "OK", Message = c.DeleteSuccess, Records = r });
                }

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
                    ToolboxViewModelObj.backbtn.Event = "$('#ListTab').trigger('click');";

                    ToolboxViewModelObj.savebtn.Visible = true;
                    ToolboxViewModelObj.savebtn.Disable = true;
                    ToolboxViewModelObj.savebtn.Title = "Save Object";
                    ToolboxViewModelObj.savebtn.Text = "Save";
                    ToolboxViewModelObj.savebtn.DisableReason = "No Application selected";
                    ToolboxViewModelObj.savebtn.Event = "";

                    ToolboxViewModelObj.resetbtn.Visible = true;
                    ToolboxViewModelObj.resetbtn.Disable = true;
                    ToolboxViewModelObj.resetbtn.Title = "Reset Object";
                    ToolboxViewModelObj.resetbtn.Text = "Reset";
                    ToolboxViewModelObj.resetbtn.DisableReason = "No Application selected";
                    ToolboxViewModelObj.resetbtn.Event = "";
                    break;
                case "select":
                    ToolboxViewModelObj.addbtn.Visible = true;
                    ToolboxViewModelObj.addbtn.Text = "Add";
                    ToolboxViewModelObj.addbtn.Title = "Add New";
                    ToolboxViewModelObj.addbtn.Event = "AddNewObject()";

                    ToolboxViewModelObj.backbtn.Visible = true;
                    ToolboxViewModelObj.backbtn.Text = "Back";
                    ToolboxViewModelObj.backbtn.Title = "Back to list";
                    ToolboxViewModelObj.backbtn.Event = "$('#ListTab').trigger('click');";

                    ToolboxViewModelObj.savebtn.Visible = true;
                    ToolboxViewModelObj.savebtn.Disable = true;
                    ToolboxViewModelObj.savebtn.Title = "Save Object";
                    ToolboxViewModelObj.savebtn.Text = "Save";
                    ToolboxViewModelObj.savebtn.DisableReason = "No Application selected";
                    ToolboxViewModelObj.savebtn.Event = "";

                    ToolboxViewModelObj.resetbtn.Visible = true;
                    ToolboxViewModelObj.resetbtn.Disable = true;
                    ToolboxViewModelObj.resetbtn.Title = "Reset Object";
                    ToolboxViewModelObj.resetbtn.Text = "Reset";
                    ToolboxViewModelObj.resetbtn.DisableReason = "No Application selected";
                    ToolboxViewModelObj.resetbtn.Event = "";

                    break;
                case "Edit":
                    ToolboxViewModelObj.addbtn.Visible = true;
                    ToolboxViewModelObj.addbtn.Text = "Add";
                    ToolboxViewModelObj.addbtn.Title = "Add New";
                    ToolboxViewModelObj.addbtn.Event = "AddNewObject()";

                    ToolboxViewModelObj.backbtn.Visible = true;
                    ToolboxViewModelObj.backbtn.Text = "Back";
                    ToolboxViewModelObj.backbtn.Title = "Back to list";
                    ToolboxViewModelObj.backbtn.Event = "";

                    ToolboxViewModelObj.savebtn.Visible = true;
                    ToolboxViewModelObj.savebtn.Title = "Save Object";
                    ToolboxViewModelObj.savebtn.Text = "Save";
                    ToolboxViewModelObj.savebtn.Event = "$('#btnSave').trigger('click');";

                    ToolboxViewModelObj.resetbtn.Visible = true;
                    ToolboxViewModelObj.resetbtn.Disable = true;
                    ToolboxViewModelObj.resetbtn.Title = "Reset Object";
                    ToolboxViewModelObj.resetbtn.Text = "Reset";
                    ToolboxViewModelObj.resetbtn.DisableReason = "No Application selected";
                    ToolboxViewModelObj.resetbtn.Event = "";

                    break;
                case "AddSub":

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