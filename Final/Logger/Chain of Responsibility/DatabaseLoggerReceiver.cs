using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Chain_of_Responsibility
{
    public class InfoLogger : Logger
    {

        public InfoLogger()
        {
            connectionSingleton = DatabaseConnectionSingleton.Instance();
            _sqlConnString = connectionSingleton.PrepareDBConnection();
        }

        public override void Log(string level, string message, Exception ex)
        {
            string query = $"Insert into dbo.Log (LogLevel,LogMessage)" +
                $"VALUES( 'Info','{message}')";

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();

                sqlCommand.ExecuteNonQuery();

                conn.Close();
            }
        }
    }
}
