using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mizza.DataRepo
{
    public static class MizzaExtension
    {
        public static List<T> ConvertToObjects<T>(this T data, DataTable dataTable) where T: new()
        {
            List<T> resultList = new List<T>();

            foreach (DataRow dtRow in dataTable.Rows)
            {
                T item = new T();
                SetItemFromRow(item, dtRow);
                resultList.Add(item);
            }

            return resultList;
        }

        private static void SetItemFromRow<T>(T item, DataRow dtRow) where T: new()
        {
            foreach (DataColumn dtCol in dtRow.Table.Columns)
            {
                PropertyInfo prop = item.GetType().GetProperty(dtCol.ColumnName);
                if (prop != null && dtRow[dtCol] != DBNull.Value)
                {
                    prop.SetValue(item, dtRow[dtCol], null);
                }
            }
        }

        public static SqlCommand AddSqlParameters<T>(this T obj, SqlCommand cmd, bool allowNull = true)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.GetValue(obj, null) == null && !allowNull)
                    continue;
                cmd.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(obj, null));
            }

            return cmd;
        }

        public static MySqlCommand AddSqlParameters<T>(this T obj, MySqlCommand cmd, bool allowNull = true)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.GetValue(obj, null) == null && !allowNull)
                    continue;
                cmd.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(obj, null));
            }

            return cmd;
        }
    }
}