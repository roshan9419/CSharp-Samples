using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace PlacementManagement.API.Utils
{
    public static class ModelParser
    {
        public static List<T> ConvertToObjects<T>(this DataTable data) where T : new()
        {
            List<T> resultList = new List<T>();

            foreach (DataRow dtRow in data.Rows)
            {
                T item = new T();
                SetItemFromRow(item, dtRow);
                resultList.Add(item);
            }

            return resultList;
        }

        private static void SetItemFromRow<T>(T item, DataRow dtRow) where T : new()
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