using Mizza.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mizza.DataModels
{
    internal class MizzaRepository : CommandViewModel
    {
        public MizzaRepository(string connectionName) : base(connectionName) { }

        //#region Separate methods for each controller for fetching all items
        //internal List<MizzaSize> GetAllMizzaSizes(string procedureName)
        //{
        //    List<MizzaSize> mizzaSizes = new List<MizzaSize>();

        //    DataTable dataTable = GetRecordsUsingStoredProcedure(procedureName);
        //    foreach (DataRow dataRow in dataTable.Rows)
        //    {
        //        mizzaSizes.Add(
        //            new MizzaSize
        //            {
        //                MizzaSizeID = Convert.ToString(dataRow["MizzaSizeID"]),
        //                MizzaSizeName = Convert.ToString(dataRow["MizzaSizeName"])
        //            }
        //        );
        //    }

        //    return mizzaSizes;
        //}

        //internal List<MizzaSKUStock> GetAllMizzaSkuStocks(string procedureName)
        //{
        //    List<MizzaSKUStock> mizzaSkusStocks = new List<MizzaSKUStock>();

        //    DataTable dataTable = GetRecordsUsingStoredProcedure(procedureName);
        //    foreach (DataRow dataRow in dataTable.Rows)
        //    {
        //        mizzaSkusStocks.Add(
        //            new MizzaSKUStock
        //            {
        //                SKUID = Convert.ToString(dataRow["SKUID"]),
        //                StockCount = Convert.ToString(dataRow["StockCount"])
        //            });
        //    }

        //    return mizzaSkusStocks;
        //}

        //internal List<MizzaSKU> GetAllMizzaSkus(string procedureName)
        //{
        //    List<MizzaSKU> mizzaSkus = new List<MizzaSKU>();

        //    DataTable dataTable = GetRecordsUsingStoredProcedure(procedureName);
        //    foreach (DataRow dataRow in dataTable.Rows)
        //    {
        //        mizzaSkus.Add(
        //            new MizzaSKU
        //            {
        //                MizzaSKUID = Convert.ToString(dataRow["MizzaSKUID"]),
        //                MizzaSKUName = Convert.ToString(dataRow["MizzaSKUName"]),
        //                MizzaStyleID = Convert.ToString(dataRow["MizzaStyleID"]),
        //                MizzaSizeID = Convert.ToString(dataRow["MizzaSizeID"])
        //            });
        //    }

        //    return mizzaSkus;
        //}

        //internal List<MizzaSkuBasePrice> GetAllMizzaSkuBasePrices(string procedureName)
        //{
        //    List<MizzaSkuBasePrice> mizzaSkuBasePrices = new List<MizzaSkuBasePrice>();

        //    DataTable dataTable = GetRecordsUsingStoredProcedure(procedureName);
        //    foreach (DataRow dataRow in dataTable.Rows)
        //    {
        //        mizzaSkuBasePrices.Add(
        //            new MizzaSkuBasePrice
        //            {
        //                SKUID = Convert.ToString(dataRow["SKUID"]),
        //                Price = Convert.ToInt32(dataRow["Price"])
        //            });
        //    }

        //    return mizzaSkuBasePrices;
        //}

        //internal List<MizzaStyle> GetAllMizzaStyles(string procedureName)
        //{
        //    List<MizzaStyle> mizzaStyles = new List<MizzaStyle>();

        //    DataTable dataTable = GetRecordsUsingStoredProcedure(procedureName);
        //    foreach (DataRow dataRow in dataTable.Rows)
        //    {
        //        mizzaStyles.Add(
        //            new MizzaStyle
        //            {
        //                MizzaStyleID = Convert.ToString(dataRow["MizzaStyleID"]),
        //                MizzaStyleName = Convert.ToString(dataRow["MizzaStyleName"])
        //            });
        //    }

        //    return mizzaStyles;
        //}

        //internal List<MizzaToppingStyle> GetAllMizzaToppingStyles(string procedureName)
        //{
        //    List<MizzaToppingStyle> mizzaToppStyles = new List<MizzaToppingStyle>();

        //    DataTable dataTable = GetRecordsUsingStoredProcedure(procedureName);
        //    foreach (DataRow dataRow in dataTable.Rows)
        //    {
        //        mizzaToppStyles.Add(
        //            new MizzaToppingStyle
        //            {
        //                ToppingStyleID = Convert.ToString(dataRow["ToppingStyleID"]),
        //                ToppingName = Convert.ToString(dataRow["ToppingName"])
        //            });
        //    }

        //    return mizzaToppStyles;
        //}
        //#endregion

        //internal DataTable AllMizza(string procedureName)
        //{
        //    DataTable resultDt = GetRecordsUsingStoredProcedure(procedureName);
        //    return resultDt;
        //}
    }
}