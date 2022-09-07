using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlacementManagement.API.Utils
{
    public static class Utils
    {
        public static bool IsNullOrEmpty(this object property)
        {
            return property == null || (property.GetType().IsArray && ((dynamic)property).Length == 0);
        }
    }
}