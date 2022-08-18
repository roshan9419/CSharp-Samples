using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mizza.DataModels
{
    internal class CommandViewModel
    {
        private SqlConnection _conn;

        public CommandViewModel(string connectionName)
        {
            string connString = ConfigurationManager.ConnectionStrings[connectionName].ToString();
            _conn = new SqlConnection(connString);
        }

        internal DataTable GetRecordsUsingStoredProcedure<T>(string procedureName, T filter = null) where T : class
        {
            SqlCommand cmd = new SqlCommand(procedureName, _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            filter?.AddSqlParameters(cmd, false);
            
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            _conn.Open();
            dataAdapter.Fill(dataTable);
            _conn.Close();

            return dataTable;
        }

        internal bool CreateOrUpdateUsingStoredProcedure<T>(string procedureName, T obj)
        {
            SqlCommand cmd = new SqlCommand(procedureName, _conn);
            cmd.CommandType = CommandType.StoredProcedure;

            obj.AddSqlParameters(cmd);

            _conn.Open();
            int records = cmd.ExecuteNonQuery();
            _conn.Close();

            return records >= 1;
        }
    }
}