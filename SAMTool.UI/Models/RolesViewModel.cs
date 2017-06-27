﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAMTool.UI.Models
{
    public class RolesViewModel
    {
        public Guid? ID { get; set; }

        [Required(ErrorMessage = "Please Select Application Name")]
        public Guid? AppID { get; set; }

        public string ApplicationName { get; set; }
        

        [Required(ErrorMessage = "Please enter Role Name")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "Please enter Role Description")]
        [Display(Name = "Role Description")]
        public string RoleDescription { get; set; }

        public List<SelectListItem> ApplicationList { get; set; }

    }
}