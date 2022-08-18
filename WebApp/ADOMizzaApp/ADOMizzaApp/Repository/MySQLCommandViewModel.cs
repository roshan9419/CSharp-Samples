using Mizza.DataRepo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ADOMizzaApp.Repository
{
    internal class MySQLCommandViewModel
    {
        private MySqlConnection _conn;

        public MySQLCommandViewModel(string connectionName)
        {
            string connString = ConfigurationManager.ConnectionStrings[connectionName].ToString();
            _conn = new MySqlConnection(connString);
        }

        internal DataTable GetRecordsUsingStoredProcedure(string procedureName, string id = null)
        {
            MySqlCommand cmd = new MySqlCommand(procedureName, _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            _conn.Open();
            dataAdapter.Fill(dataTable);
            _conn.Close();

            return dataTable;
        }

        internal DataTable GetRecordsUsingStoredProcedure<T>(string procedureName, T filter = null) where T : class
        {
            MySqlCommand cmd = new MySqlCommand(procedureName, _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            filter?.AddSqlParameters(cmd, true);

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            _conn.Open();
            dataAdapter.Fill(dataTable);
            _conn.Close();

            return dataTable;
        }

        internal bool CreateOrUpdateUsingStoredProcedure<T>(string procedureName, T obj) where T : class
        {
            MySqlCommand cmd = new MySqlCommand(procedureName, _conn);
            cmd.CommandType = CommandType.StoredProcedure;

            obj.AddSqlParameters(cmd);

            _conn.Open();
            int records = cmd.ExecuteNonQuery();
            _conn.Close();

            return records >= 1;
        }

        internal bool DeleteUsingStoredProcedure<T>(string procedureName, T obj) where T : class
        {
            MySqlCommand cmd = new MySqlCommand(procedureName, _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            obj.AddSqlParameters(cmd, true);

            _conn.Open();
            int records = cmd.ExecuteNonQuery();
            _conn.Close();

            return records >= 1;
        }
    }
}