using MizzaAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MizzaAPI.Utils
{
    public static class DBExtension
    {
        public static List<DBParameter> GetDBParameters<T>(this T obj)
        {
            var dbParams = new List<DBParameter>();
            foreach (var prop in obj.GetType().GetProperties())
            {
                dbParams.Add(new DBParameter { Key = prop.Name, Value = prop.GetValue(obj, null) });
            }
            return dbParams;
        }

        public static void AddDBParameters(this MySqlCommand cmd, List<DBParameter> dbParams)
        {
            if (dbParams != null)
            {
                foreach (var param in dbParams)
                    cmd.Parameters.AddWithValue($"@{param.Key}", param.Value);
            }
        }
    }
}