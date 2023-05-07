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

        //use this to reference the DB connection
        private static SqlConnectionStringBuilder _connectionBuilder;

        //make sure there is only one instance of the reference to the database
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

        //Create the reference that will be used to connect to the db
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
