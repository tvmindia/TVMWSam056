using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAMTool.UI.Models
{
    public class ApplicationViewModel
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Please Enter Application name")]
        [Display(Name = "Application Name")]
        public string Name { get; set; }
    }
}