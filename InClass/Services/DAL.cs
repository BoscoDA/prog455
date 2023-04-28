using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Services.Model;

namespace Services
{
    public class DAL
    {
        private string _sqlConnString = String.Empty;
        public DAL() 
        {
            PrepareConnection();
        }
        public List<UserModel> APIGetAll()
        {
            List<UserModel> list = new List<UserModel>();

            using (SqlConnection conn = new SqlConnection(_sqlConnString)) 
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GetAllUser]",conn)) 
                { 
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    var result = sqlCommand.ExecuteReader();

                    while(result.Read()) 
                    {
                        UserModel model = new UserModel();
                        model.Id = (int)result["id"];
                        model.Username = (string)result["username"];
                        model.FirstName = (string)result["First_Name"];
                        model.LastName = (string)result["Last_Name"];
                        model.Role = (string)result["role"];
                        list.Add(model);

                    }
                }
            }

            return list;
        }

        private void PrepareConnection()
        {
            SqlConnectionStringBuilder connBldr = new SqlConnectionStringBuilder();
            connBldr.DataSource = $"(localdb)\\MSSQLLocalDB";
            connBldr.IntegratedSecurity = true;
            connBldr.InitialCatalog = $"PROG455SP23";
            _sqlConnString = connBldr.ConnectionString;
        }
    }
}
