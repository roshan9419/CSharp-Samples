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

        public static IEnumerable<SelectListItem> GetIndianStates()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem { Text="Andhra Pradesh", Value="Andhra Pradesh" },
                new SelectListItem { Text="Arunachal Pradesh", Value="Arunachal Pradesh" },
                new SelectListItem { Text="Assam", Value="Assam" },
                new SelectListItem { Text="Bihar", Value="Bihar" },
                new SelectListItem { Text="Chhattisgarh", Value="Chhattisgarh" },
                new SelectListItem { Text="Goa", Value="Goa" },
                new SelectListItem { Text="Gujarat", Value="Gujarat" },
                new SelectListItem { Text="Haryana", Value="Haryana" },
                new SelectListItem { Text="Himachal Pradesh", Value="Himachal Pradesh" },
                new SelectListItem { Text="Jharkhand", Value="Jharkhand" },
                new SelectListItem { Text="Karnataka", Value="Karnataka" },
                new SelectListItem { Text="Kerala", Value="Kerala" },
                new SelectListItem { Text="Madhya Pradesh", Value="Madhya Pradesh" },
                new SelectListItem { Text="Maharashtra", Value="Maharashtra" },
                new SelectListItem { Text="Manipur", Value="Manipur" },
                new SelectListItem { Text="Meghalaya", Value="Meghalaya" },
                new SelectListItem { Text="Mizoram", Value="Mizoram" },
                new SelectListItem { Text="Nagaland", Value="Nagaland" },
                new SelectListItem { Text="Odisha", Value="Odisha" },
                new SelectListItem { Text="Punjab", Value="Punjab" },
                new SelectListItem { Text="Rajasthan", Value="Rajasthan" },
                new SelectListItem { Text="Sikkim", Value="Sikkim" },
                new SelectListItem { Text="Tamil Nadu", Value="Tamil Nadu" },
                new SelectListItem { Text="Telangana", Value="Telangana" },
                new SelectListItem { Text="Tripura", Value="Tripura" },
                new SelectListItem { Text="Uttarakhand", Value="Uttarakhand" },
                new SelectListItem { Text="Uttar Pradesh", Value="Uttar Pradesh" },
                new SelectListItem { Text="West Bengal", Value="West Bengal" }
            };
        }
    }
}