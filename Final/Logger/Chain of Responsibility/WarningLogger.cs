using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Chain_of_Responsibility
{
    public class WarningLogger : Logger
    {

        public WarningLogger()
        {
            connectionSingleton = DatabaseConnectionSingleton.Instance();
            _sqlConnString = connectionSingleton.PrepareDBConnection();
        }

        /// <summary>
        /// Logs requests that are of the Warning level
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public override void Log(string level, string message, Exception? ex)
        {
            string query = $"Insert into dbo.Log (LogLevel,LogMessage)" +
                $"VALUES( 'Warning','{message}')";

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
