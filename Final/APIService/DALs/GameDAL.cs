using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using APIService.DALs;
using APIService.Models;
using System.Reflection;

namespace APIService.DALs
{
    public class GameDAL : IGameDAL
    {
        private string sqlConnectString = string.Empty;
        private DatabaseConnectionSingleton connectionSingleton;

        public GameDAL()
        {
            connectionSingleton = DatabaseConnectionSingleton.Instance();
            sqlConnectString = connectionSingleton.PrepareDBConnection();
        }

        public Guid InsertGameRecord(GameRecordModel model)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[GamesInsertRecord]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerId", model.UserId).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@EncounterId", model.Encounter).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Timestemp", DateTime.Now).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Completed", model.Completed).Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("@ReturnValue", SqlDbType.UniqueIdentifier).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    var result = (Guid)cmd.Parameters["@ReturnValue"].Value;
                    conn.Close();
                    return result;
                }
            }
        }

        public GameRecordModel GetGameById(Guid id)
        {
            GameRecordModel result = new GameRecordModel();
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GamesGetRecordById]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", id).Direction = ParameterDirection.Input;

                    conn.Open();
                    var results = sqlCommand.ExecuteReader();

                    while (results.Read())
                    {
                        result.Id = (Guid)results["id"];
                        result.UserId = (Guid)results["player_id"];
                        result.Encounter = (Guid)results["pokemon_encounter_id"];
                        result.Completed = (bool)results["completed"];
                        result.Timestamp = (DateTime)results["timestamp"];
                    }
                }
                conn.Close();
            }
            return result;
        }

        public void UpdateGameById(GameRecordModel model)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[GamesUpdateRecordById]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", model.Id).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@PlayerId", model.UserId).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@EncounterId", model.Encounter).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Timestemp", model.Timestamp).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Completed", model.Completed).Direction = ParameterDirection.Input;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        
    }
}
