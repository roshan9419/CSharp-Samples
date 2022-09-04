using PlacementManagement.Attributes;
using PlacementManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PlacementManagement.API.Utils
{
    public static class DBExtension
    {
        public static DBParameter[] GetDBParameters<T>(this T obj)
        {
            var dbParams = new List<DBParameter>();
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (!IgnoreProperty(prop))
                    dbParams.Add(new DBParameter { Key = prop.Name, Value = prop.GetValue(obj, null) });
            }
            return dbParams.ToArray();
        }

        public static bool IgnoreProperty(PropertyInfo prop)
        {
            foreach (var attr in prop.GetCustomAttributes(true))
                if (attr is IgnorePropertyConversion) 
                    return true;
            return false;
        }
    }
}