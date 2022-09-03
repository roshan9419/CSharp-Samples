using PlacementManagement.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlacementManagement.Web.Utils
{
    public class SelectListItemHelper
    {
        public static IEnumerable<SelectListItem> GetConfirmationOptions()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem { Text = "Yes", Value = "1" },
                new SelectListItem { Text = "No", Value = "0" }
            };
        }
    }
}