using Mizza.DataModels.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

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
    }
}