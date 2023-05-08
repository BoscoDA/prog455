using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class DatabaseConnectionSingleton
    {
        private static DatabaseConnectionSingleton _instance;

        private static SqlConnectionStringBuilder _connectionBuilder;

        /// <summary>
        /// Gets the singleton instance of the class
        /// </summary>
        /// <returns></returns>
        public static DatabaseConnectionSingleton Instance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseConnectionSingleton();
                _connectionBuilder = new SqlConnectionStringBuilder();
            }
            return _instance;
        }

        private DatabaseConnectionSingleton() { }

        /// <summary>
        /// Builds the SQL connection needed to connect to the database for the project 
        /// </summary>
        /// <returns></returns>
        public string PrepareDBConnection()
        {
            _connectionBuilder.DataSource = $"(localdb)\\MSSQLLocalDB";
            _connectionBuilder.IntegratedSecurity = true;
            _connectionBuilder.InitialCatalog = $"GuessThatPokemon";

            //The string that is associated and will be used to reference/represent the DB connection
            return _connectionBuilder.ConnectionString;
        }
    }
}
