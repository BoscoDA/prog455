﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIService.DALs
{
    public class DatabaseConnectionSingleton
    {
        private static DatabaseConnectionSingleton instance;

        //use this to reference the DB connection
        private static SqlConnectionStringBuilder connectionBuilder;

        //make sure there is only one instance of the reference to the database
        public static DatabaseConnectionSingleton Instance()
        {
            if (instance == null)
            {
                instance = new DatabaseConnectionSingleton();
                connectionBuilder = new SqlConnectionStringBuilder();
            }
            return instance;
        }

        private DatabaseConnectionSingleton() { }

        //Create the reference that will be used to connect to the db
        public string PrepareDBConnection()
        {
            connectionBuilder.DataSource = $"(localdb)\\MSSQLLocalDB";
            connectionBuilder.IntegratedSecurity = true;
            connectionBuilder.InitialCatalog = $"GuessThatPokemon";

            //The string that is associated and will be used to reference/represent the DB connection
            return connectionBuilder.ConnectionString;
        }
    }
}