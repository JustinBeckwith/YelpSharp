using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcSample.Models
{

    public class SimpleSearchModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Search Term (ex. coffee)")]
        public string Term { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Location (ex. Seattle)")]
        public string Location { get; set; }
    }

}
