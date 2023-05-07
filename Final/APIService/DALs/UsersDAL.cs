using APIService.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace APIService.DALs
{
    public class UsersDAL
    {
        private string sqlConnectString = string.Empty;
        private DatabaseConnectionSingleton connectionSingleton;

        public UsersDAL()
        {
            connectionSingleton = DatabaseConnectionSingleton.Instance();
            sqlConnectString = connectionSingleton.PrepareDBConnection();
        }

        public List<UserRecordModel> GetByUsername(string username)
        {
            List<UserRecordModel> models = new List<UserRecordModel>();

            using(SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                using(SqlCommand cmd = new SqlCommand("[dbo].[UsersGetByUsername]", conn)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username).Direction = ParameterDirection.Input;

                    conn.Open();
                    var result = cmd.ExecuteReader();

                    while (result.Read()) 
                    {
                        models.Add(MapToModel(result));
                    }
                    conn.Close();
                }
            }
            return models;
        }

        public Guid InsertUser(UserRecordModel model)
        {

            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[UsersInsertRecord]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", model.Username).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Password", model.Password).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Salt", model.Salt).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@SignupTime", model.SignupTime).Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("@ReturnValue", SqlDbType.UniqueIdentifier).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    var result = (Guid)cmd.Parameters["@ReturnValue"].Value;
                    conn.Close();
                    return result;
                }
            }
        }

        private UserRecordModel MapToModel(SqlDataReader result)
        {
            UserRecordModel model = new UserRecordModel();
            model.Id = (Guid)result["id"];
            model.Username = (string)result["username"];
            model.Password = (string)result["password"];
            model.Salt = (string)result["salt"];
            model.SignupTime = (DateTime)result["signup_time"];

            return model;
        }
    }
}
