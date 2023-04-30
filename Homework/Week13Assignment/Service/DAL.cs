using Service.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DAL
    {
        private string _sqlConnString = String.Empty;
        public DAL()
        {
            PrepareConnection();

        }

        public List<RecordModel> APIGetAll()
        {
            List<RecordModel> list = new List<RecordModel>();

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GetAllRecords]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    var result = sqlCommand.ExecuteReader();
                    

                    while (result.Read())
                    {
                        //use dapper here or AutoMapper
                        RecordModel model = new RecordModel();
                        model.Id = (string)result["player_id"];
                        model.Name = (string)result["name"];
                        model.UniformColor = (int)result["uniform_color"];
                        model.GemStone = (string)result["gem_stone"];
                        model.HP = (int)result["hp"];
                        model.Weight = (int)result["weight"];
                        model.DepthDived = (int)result["depth_dived"];
                        list.Add(model);

                    }

                }
                conn.Close();
            }

            return list;
        }

        public List<RecordModel> APIGetAllByName(string name)
        {
            List<RecordModel> list = new List<RecordModel>();

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GetRecordByName]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name", name).Direction = ParameterDirection.Input;
                    conn.Open();
                    var result = sqlCommand.ExecuteReader();


                    while (result.Read())
                    {
                        RecordModel model = new RecordModel();
                        model.Id = (string)result["player_id"];
                        model.Name = (string)result["name"];
                        model.UniformColor = (int)result["uniform_color"];
                        model.GemStone = (string)result["gem_stone"];
                        model.HP = (int)result["hp"];
                        model.Weight = (int)result["weight"];
                        model.DepthDived = (int)result["depth_dived"];
                        list.Add(model);

                    }

                }
                conn.Close();
            }

            return list;
        }

        public string APIDeleteById(string id) 
        { 
            using(SqlConnection connection = new SqlConnection(_sqlConnString)) 
            {
                using(SqlCommand sqlCommand = new SqlCommand("[dbo].[DeleteRecordById]", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(@"Id", id).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.Output;

                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    string result = (int)sqlCommand.Parameters[1].Value == 0 ? "Fail" : "Success";
                    connection.Close();
                    return result;
                }
            }
        }

        public string APIInsertRecord(RecordModel record) 
        {
            using (SqlConnection conn = new SqlConnection(_sqlConnString)) 
            { 
                using(SqlCommand sqlCommand = new SqlCommand("[dbo].[InsertRecord]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", record.Id).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Name", record.Name).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@UniformColor", (int)record.UniformColor).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@GemStone", record.GemStone).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@HP", record.HP).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Weight", record.Weight).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@DepthDived", record.DepthDived).Direction = ParameterDirection.Input;

                    conn.Open();
                    
                    var result = sqlCommand.ExecuteNonQuery() == 0 ? "Failed" : "Success";
                    conn.Close();
                    return result;
                }
            }
        }

        public string APIUpdateRecord(RecordModel record)
        {
            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[UpdateRecordByID]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", record.Id).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Name", record.Name).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@UniformColor", (int)record.UniformColor).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@GemStone", record.GemStone).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@HP", record.HP).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Weight", record.Weight).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@DepthDived", record.DepthDived).Direction = ParameterDirection.Input;

                    conn.Open();
                    var result = sqlCommand.ExecuteNonQuery() == 0 ? "Failed" : "Success";
                    conn.Close();
                    return result; ;
                }
            }
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
