using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingExample
{
    internal class DbLogger : ILogger
    {
        private string _sqlConnString;
        public DbLogger()
        {
            //typically would be own singleton class so you don't have to build it all the time
            PrepareConnection();

        }
        public void LogError(string message, Exception ex)
        {
            string query = $"Insert into dbo.Log (LogLevel,LogMessage,Exception)" + 
                $"VALUES( '{LoggerLevel.ErrorLevel.Error}','{message}','{ex}')";

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();

                sqlCommand.ExecuteNonQuery();

                conn.Close();
            }
        }

        public void LogInfo(string message)
        {
            string query = $"Insert into dbo.Log (LogLevel,LogMessage)" +
                $"VALUES( '{LoggerLevel.ErrorLevel.Information}','{message}')";

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();

                sqlCommand.ExecuteNonQuery();

                conn.Close();
            }
        }

        public void LogWarning(string message)
        {
            string query = $"Insert into dbo.Log (LogLevel,LogMessage)" +
                $"VALUES( '{LoggerLevel.ErrorLevel.Warning}','{message}')";

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();

                sqlCommand.ExecuteNonQuery();

                conn.Close();
            }
        }

        private void PrepareConnection()
        {
            //string immutable, will build over and over again when appended
            //string builder holds values and then when you are done you get the string
            SqlConnectionStringBuilder connBldr = new SqlConnectionStringBuilder();
            connBldr.DataSource = $"(localdb)\\MSSQLLocalDB";
            connBldr.IntegratedSecurity = true;
            connBldr.InitialCatalog = $"PROG455SP23";
            _sqlConnString = connBldr.ConnectionString;
        }
    }
}
