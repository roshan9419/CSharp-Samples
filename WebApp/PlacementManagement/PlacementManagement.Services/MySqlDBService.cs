using MySqlConnector;
using PlacementManagement.Services.Models;
using System.Data;

namespace PlacementManagement.Services
{
    public class MySqlDBService : IDBService
    {
        private readonly MySqlConnection _conn;

        public MySqlDBService(string connectionString)
        {
            _conn = new MySqlConnection(connectionString);
        }
        public DataTable Get(string procedureName, DBParameter[] dbParams, CommandType commandType)
        {
            MySqlCommand cmd = new MySqlCommand(procedureName, _conn);
            cmd.CommandType = commandType;
            AddDBParameters(cmd, dbParams);

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            _conn.Open();
            dataAdapter.Fill(dataTable);
            _conn.Close();

            return dataTable;
        }

        public object Create(string procedureName, DBParameter[] dbParams, CommandType commandType)
        {
            MySqlCommand cmd = new MySqlCommand(procedureName, _conn);
            cmd.CommandType = commandType;
            AddDBParameters(cmd, dbParams);

            _conn.Open();
            object records = cmd.ExecuteScalar();
            _conn.Close();

            return records;
        }

        public bool Delete(string procedureName, DBParameter[] dbParams, CommandType commandType)
        {
            return Update(procedureName, dbParams, commandType);
        }

        public bool Update(string procedureName, DBParameter[] dbParams, CommandType commandType)
        {
            MySqlCommand cmd = new MySqlCommand(procedureName, _conn);
            cmd.CommandType = commandType;
            AddDBParameters(cmd, dbParams);

            _conn.Open();
            int records = cmd.ExecuteNonQuery();
            _conn.Close();

            return records >= 1;
        }

        private static void AddDBParameters(MySqlCommand cmd, DBParameter[] dbParams)
        {
            if (dbParams != null)
            {
                foreach (var param in dbParams)
                    cmd.Parameters.AddWithValue($"@{param.Key}", param.Value);
            }
        }
    }
}