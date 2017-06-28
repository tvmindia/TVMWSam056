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
using System.Web.Security;

namespace SAMTool.UI.Controllers
{
    public class AccountController : Controller
    {
        IUserBusiness _userBusiness;
        public AccountController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

       
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        #region Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginvm)
        {
            UserViewModel uservm = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    loginvm.IsFailure = true;
                    return View("Index", loginvm);
                }
                uservm = Mapper.Map<User, UserViewModel>(_userBusiness.CheckUserCredentials(Mapper.Map<LoginViewModel, User>(loginvm)));
                    if (uservm != null)
                    {
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, uservm.UserName, DateTime.Now, DateTime.Now.AddHours(24), true, "");
                        string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket));
                        //session setting
                        UA ua = new UA();
                        ua.UserName = uservm.UserName;
                        Session.Add("TvmValid", ua);
                        return RedirectToLocal();
                    }
                    else
                    {
                        loginvm.IsFailure = true;
                        return View("Index", loginvm);
                    }
              


            }
            catch (Exception ex)
            {
                throw ex;
               
            }
        }
        #endregion UserInsertUpdate

        #region Logout
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
                Session.Remove("TvmValid");


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToLogin();
        }

        #endregion Logout
        private ActionResult RedirectToLocal()
        {
            return RedirectToAction("Index", "Home");
        }
        private ActionResult RedirectToLogin()
        {
            return RedirectToAction("Index", "Account");
        }


        [HttpGet]
        public ActionResult NotAuthorized()
        {
            return View();
        }
    }
}