﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.DataAccessObject.DTO
{
    public class UA
    {
        public string UserName { get; set; }
        public DateTime DateTime { get; set; }
        public Guid AppID { get; set; }
    }

    public class Common
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestr { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime GetCurrentDateTime()
        {
            string tz = System.Web.Configuration.WebConfigurationManager.AppSettings["TimeZone"];
            DateTime DateNow = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);
            return (TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateNow, tz));
        }
    }
    public class ConstMessage
    {
        public string Message;
        public string Code;
        public string type;
        public ConstMessage(string msg, string cd, string typ)
        {
            Message = (cd == "" ? "" : cd + "-") + msg;
            Code = cd;
            type = typ;

        }
    }
    public class Const
    {
        #region Messages

        private List<ConstMessage> ConstMessage = new List<ConstMessage>();

        public Const()
        {
            ConstMessage.Add(new ConstMessage("Items from this invoice already used,Form8 Cannot be deleted", "DF8D1", "ERROR"));
            ConstMessage.Add(new ConstMessage("Minimum one item required for invoice", "DF8D2", "ERROR"));
            ConstMessage.Add(new ConstMessage("Items from this invoice already used,Form8 Cannot be deleted", "DF8BD1", "ERROR"));
            ConstMessage.Add(new ConstMessage("Minimum one item required for invoice", "DF8BD2", "ERROR"));
            ConstMessage.Add(new ConstMessage("This item already used,cannot be deleted", "DIMD1", "ERROR"));
            ConstMessage.Add(new ConstMessage("This Items code already Exists,Cannot Save!", "DIMD2", "ERROR"));
            ConstMessage.Add(new ConstMessage("Invoice No already exist!", "IF8B1", "ERROR"));
            ConstMessage.Add(new ConstMessage("Invoice No already exist!", "IF81", "ERROR"));
            ConstMessage.Add(new ConstMessage("Items from this invoice already used,Form8 Cannot be deleted!", "DF8B1", "ERROR"));
            ConstMessage.Add(new ConstMessage("Transfer item stock from Technician before deleting!", "DE1", "ERROR"));
            ConstMessage.Add(new ConstMessage("Minimum one item required for bill", "DLPD2", "ERROR"));
            ConstMessage.Add(new ConstMessage("Login Name or Email Exists", "LE01", "ERROR"));
            ConstMessage.Add(new ConstMessage("TCR Number already exists", "TCRNE", "ERROR"));
            ConstMessage.Add(new ConstMessage("Invoice Number already exist!", "INVE01", "ERROR"));
            ConstMessage.Add(new ConstMessage("Reference Number already exist!", "REFN01", "ERROR"));
            ConstMessage.Add(new ConstMessage("Bill Number already exist!", "BLN01", "ERROR"));
            ConstMessage.Add(new ConstMessage("ICR Number already exist!", "ICRNE", "ERROR"));
            ConstMessage.Add(new ConstMessage("CreditNote No already exist!", "CNNE01", "ERROR"));
            ConstMessage.Add(new ConstMessage("Item already exist!", "IE01", "ERROR"));
            ConstMessage.Add(new ConstMessage("opening already exist!", "OPE01", "ERROR"));
            ConstMessage.Add(new ConstMessage("Book No already exists!", "BKN01", "ERROR"));
            ConstMessage.Add(new ConstMessage("Deletion Not Successfull!-Already In Use", "DNS01", "ERROR"));
            ConstMessage.Add(new ConstMessage("Items from this Bill already used, Cannot be deleted", "ITBD01", "ERROR"));
            
            //
        }

        public string LoginAndEmailExist
        {
            get { return "Login or Email Exist! "; }
        }
        public string LoginFailed
        {
            get { return "Login Failed! "; }
        }
        public string LoginFailedNoRoles
        {
            get { return "Login Failed! You are not authorized to access this app"; }
        }
        public string InsertFailure
        {
            get { return "Insertion Not Successfull! "; }
        }

        public string InsertSuccess
        {
            get { return "Values Saved Successfully ! "; }
        }

        public string UpdateFailure
        {
            get { return "Updation Not Successfull! "; }
        }

        public string UpdateSuccess
        {
            get { return "Updation Successfull! "; }
        }

        public string DeleteFailure
        {
            get { return "Deletion Not Successfull! "; }
        }
        public string DeleteSuccess
        {
            get { return "Deletion Successfull! "; }
        }
        public string FKviolation
        {
            get { return "Deletion Not Successfull!-Already In Use"; }
        }
        public string Duplicate
        {
            get { return "Allready Exist.."; }
        }
        public string JobDuplicate
        {
            get { return "Job Allready Exist.."; }
        }
        public string NoItems
        {
            get { return "No items"; }
        }
        public string SeriesStartDuplication
        {
            get { return "Series Start Already Exists"; }
        }
        public string SeriesEndDuplication
        {
            get { return "Series End Already Exists"; }
        }
        public string SeriesStartAndEndDuplication
        {
            get { return "Series start and End Already Exists"; }
        }
        public string PasswordError
        {
            get { return "Password is wrong"; }
        }
        public ConstMessage GetMessage(string MsgCode)
        {
            ConstMessage result = new ConstMessage(MsgCode, "", "ERROR");

            try
            {
                foreach (ConstMessage c in ConstMessage)
                {
                    if (c.Code == MsgCode)
                    {
                        result = c;
                        break;
                    }

                }

            }
            catch (Exception)
            {


            }
            return result;



        }


        #endregion Messages

        #region Strings
        public string AppUser
        {
            get { return "App User"; }
        }
        #endregion
    }
}