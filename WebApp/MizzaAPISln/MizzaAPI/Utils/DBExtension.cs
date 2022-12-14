using Mizza.DataModels.Attributes;
using MizzaAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MizzaAPI.Utils
{
    public static class DBExtension
    {
        public static DBParameter[] GetDBParameters<T>(this T obj)
        {
            var dbParams = new List<DBParameter>();
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (ToAddOrIgnore(prop))
                    dbParams.Add(new DBParameter { Key = prop.Name, Value = prop.GetValue(obj, null) });
            }
            return dbParams.ToArray();
        }

        public static void AddDBParameters(this MySqlCommand cmd, DBParameter[] dbParams)
        {
            if (dbParams != null)
            {
                foreach (var param in dbParams)
                    cmd.Parameters.AddWithValue($"@{param.Key}", param.Value);
            }
        }

        private static bool ToAddOrIgnore(PropertyInfo prop)
        {
            foreach (var attr in prop.GetCustomAttributes(true))
                if (attr is IgnoreProperty) return false;
            return true;
        }
    }
}