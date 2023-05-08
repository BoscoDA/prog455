using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Chain_of_Responsibility
{
    public class ErrorLogger : Logger
    {

        public ErrorLogger()
        {
            connectionSingleton = DatabaseConnectionSingleton.Instance();
            _sqlConnString = connectionSingleton.PrepareDBConnection();
        }

        /// <summary>
        /// Logs requests that are of the Error level
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public override void Log(string level, string message, Exception ex)
        {
            string query = $"Insert into dbo.Log (LogLevel,LogMessage,Exception)" +
                $"VALUES( 'Error','{message}','{ex}')";

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
