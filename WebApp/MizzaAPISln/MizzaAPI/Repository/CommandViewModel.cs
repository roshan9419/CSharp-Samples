using MizzaAPI.Models;
using MizzaAPI.Utils;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace MizzaAPI.Repository
{

    public class CommandViewModel
    {
        private MySqlConnection _conn;
        public CommandViewModel(string connectionName)
        {
            string connString = ConfigurationManager.ConnectionStrings[connectionName].ToString();
            _conn = new MySqlConnection(connString);
        }

        internal DataTable GetRecords(string procedureName, DBParameter[] dbParams = null, CommandType commandType = CommandType.StoredProcedure)
        {
            MySqlCommand cmd = new MySqlCommand(procedureName, _conn);
            cmd.CommandType = commandType;
            cmd.AddDBParameters(dbParams);

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            _conn.Open();
            dataAdapter.Fill(dataTable);
            _conn.Close();

            return dataTable;
        }

        internal bool CreateRecord(string procedureName, DBParameter[] dbParams = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return UpdateRecord(procedureName, dbParams, commandType);
        }

        internal bool DeleteRecord(string procedureName, DBParameter[] dbParams = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return UpdateRecord(procedureName, dbParams, commandType);
        }

        internal bool UpdateRecord(string procedureName, DBParameter[] dbParams = null, CommandType commandType = CommandType.StoredProcedure)
        {
            MySqlCommand cmd = new MySqlCommand(procedureName, _conn);
            cmd.CommandType = commandType;
            cmd.AddDBParameters(dbParams);

            _conn.Open();
            int records = cmd.ExecuteNonQuery();
            _conn.Close();

            return records >= 1;
        }
    }
}