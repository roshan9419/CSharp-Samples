using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOComponent
{
    public class ADOCommand
    {
        string _connectionString;

        public ADOCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string ExecuteCommand(string command)
        {
            //command = "select count(*) from mizzasize";
            try
            {
                int result;
                using(SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        conn.Open();
                        string sr = GetConnectionInformation(conn);
                        result = (int)cmd.ExecuteScalar();
                    }
                }
                return result.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        protected virtual string GetConnectionInformation(SqlConnection cnn)
        {
            StringBuilder sb = new StringBuilder(1024);

            sb.AppendLine("Connection String: " + cnn.ConnectionString);
            sb.AppendLine("State: " + cnn.State.ToString());
            sb.AppendLine("Connection Timeout: " + cnn.ConnectionTimeout.ToString());
            sb.AppendLine("Database: " + cnn.Database);
            sb.AppendLine("Data Source: " + cnn.DataSource);
            sb.AppendLine("Server Version: " + cnn.ServerVersion);
            sb.AppendLine("Workstation ID: " + cnn.WorkstationId);

            return sb.ToString();
        }
    }
}
