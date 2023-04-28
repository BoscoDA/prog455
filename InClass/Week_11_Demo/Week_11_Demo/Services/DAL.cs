using Services.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DAL
    {
        private string _sqlConnString = String.Empty;
        public DAL()
        {
            PrepareConnection();

        }

        public void InsertRecord(RecordModel record)
        {
            string query = $"Insert into dbo.Game (PlayerName,Attempts,CorrectAnswer,Duration)" +
                $"VALUES( '{record.PlayerName}','{record.Attempts}','{record.CorrectAnswer}','{record.Duration}')";


            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();

                sqlCommand.ExecuteNonQuery();

                conn.Close();
            }
        }

        public int APIInsertRecord(RecordModel record)
        {

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[ApiInsertRecord]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Playername", record.PlayerName).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Attempts", record.Attempts).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@CorrectAnswer", record.CorrectAnswer).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Duration", record.Duration).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.Output;


                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    var result = (int)sqlCommand.Parameters["@ReturnValue"].Value;
                    conn.Close();
                    return result;

                }
            }
        }

        public List<RecordModel> APIGetAll()
        {
            List<RecordModel> list = new List<RecordModel>();

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[ApiGetAll]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    var result = sqlCommand.ExecuteReader();


                    while (result.Read())
                    {
                        //use dapper here or AutoMapper
                        RecordModel model = new RecordModel();
                        model.GameId = (int)result["id"];
                        model.PlayerName = (string)result["PlayerName"];
                        model.Attempts = (int)result["Attempts"];
                        model.Duration = (int)result["Duration"];
                        model.CorrectAnswer = (int)result["CorrectAnswer"];
                        list.Add(model);

                    }

                }

            }

            return list;
        }

        public List<RecordModel> APIGetbyName(string name)
        {
            List<RecordModel> list = new List<RecordModel>();

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[ApiGetByName]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@playerName", name).Direction = ParameterDirection.Input;
                    conn.Open();
                    var result = sqlCommand.ExecuteReader();


                    while (result.Read())
                    {
                        RecordModel model = new RecordModel();
                        model.GameId = (int)result["id"];
                        model.PlayerName = (string)result["PlayerName"];
                        model.Attempts = (int)result["Attempts"];
                        model.Duration = (int)result["Duration"];
                        model.CorrectAnswer = (int)result["CorrectAnswer"];
                        list.Add(model);

                    }

                }
                conn.Close();
            }

            return list;
        }

        public RecordModel APIGetById(int id)
        {
            RecordModel model = new RecordModel();

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[ApiGetById]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", id).Direction = ParameterDirection.Input;

                    conn.Open();
                    var result = sqlCommand.ExecuteReader();


                    while (result.Read())
                    {

                        model.GameId = (int)result["id"];
                        model.PlayerName = (string)result["PlayerName"];
                        model.Attempts = (int)result["Attempts"];
                        model.Duration = (int)result["Duration"];
                        model.CorrectAnswer = (int)result["CorrectAnswer"];


                    }

                }

            }

            return model;
        }

        public string APIDeleteById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[ApiDeleteById]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", id).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conn.Open();
                    string result = sqlCommand.ExecuteNonQuery() == 0 ? "Fail" : "Success";
                    conn.Close();
                    return result;


                }

            }

        }
    
        private void PrepareConnection()
        {
            SqlConnectionStringBuilder connBldr = new SqlConnectionStringBuilder();
            connBldr.DataSource = $"(localdb)\\MSSQLLocalDB";
            connBldr.IntegratedSecurity = true;
            connBldr.InitialCatalog = $"PROG455FA22";
            _sqlConnString = connBldr.ConnectionString;
        }
    }
}
