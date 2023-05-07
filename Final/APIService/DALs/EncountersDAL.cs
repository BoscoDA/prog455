using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIService.Models;

namespace APIService.DALs
{
    public class EncountersDAL : IEncountersDAL
    { 
        private string sqlConnectString = string.Empty;
        private DatabaseConnectionSingleton connectionSingleton;

        public EncountersDAL()
        {
            connectionSingleton = DatabaseConnectionSingleton.Instance();
            sqlConnectString = connectionSingleton.PrepareDBConnection();
        }

        public List<EncounterHistoryRecordModel> GetByUserId(Guid id)
        {
            List<EncounterHistoryRecordModel> models = new List<EncounterHistoryRecordModel>();

            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[EncountersGetAllByUserId]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", id).Direction = ParameterDirection.Input;

                    conn.Open();
                    var results = sqlCommand.ExecuteReader();

                    while (results.Read())
                    {
                        EncounterHistoryRecordModel model = new EncounterHistoryRecordModel();
                        model.PokedexNum = (int)results["dex_num"];
                        model.Name = (string)results["name"];
                        model.Type1 = (string)results["type_1"];
                        if (results["type_2"] == DBNull.Value)
                        {
                            model.Type2 = string.Empty;
                        }
                        else
                        {
                            model.Type2 = (string)results["type_2"];
                        }
                        
                        model.Ability = (string)results["ability"];
                        model.AbilDesc = (string)results["ability_desc"];
                        model.Location = (string)results["location"];
                        model.Sprite = (string)results["sprite_path"];
                        model.Caught = (bool)results["caught"];
                        model.TimeStamp = (DateTime)results["timestamp"];
                        models.Add(model);
                    }
                }
                conn.Close();
            }
            return models;
        }

        public void UpdateEncounterById(EncounterRecordModel model)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[EncountersUpdateRecordById]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", model.ID).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@DexNum", model.PokedexNum).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Name", model.Name).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Type1", model.Type1).Direction = ParameterDirection.Input;
                    if (model.Type2 == null)
                    {
                        cmd.Parameters.AddWithValue("@Type2", DBNull.Value).Direction = ParameterDirection.Input;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Type2", model.Type2).Direction = ParameterDirection.Input;
                    }

                    cmd.Parameters.AddWithValue("@Ability", model.Ability).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@AbilDesc", model.AbilDesc).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Location", model.Location).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Sprite", model.Sprite).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Caught", model.Caught).Direction = ParameterDirection.Input;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public EncounterRecordModel GetEncounterById(Guid? id)
        {
            EncounterRecordModel result = new EncounterRecordModel();
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[EncountersGetRecordById]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", id).Direction = ParameterDirection.Input;

                    conn.Open();
                    var results = sqlCommand.ExecuteReader();

                    while (results.Read())
                    {
                        result.PokedexNum = (int)results["dex_num"];
                        result.Name = (string)results["name"];
                        result.Type1 = (string)results["type_1"];
                        result.Type2 = (string)results["type_2"];
                        result.Ability = (string)results["ability"];
                        result.AbilDesc = (string)results["ability_desc"];
                        result.Location = (string)results["location"];
                        result.Sprite = (string)results["sprite_path"];
                        result.Caught = (bool)results["caught"];
                        result.ID = (Guid)results["id"];

                    }
                }
                conn.Close();
            }
            return result;
        }

        public Guid InsertEncounter(EncounterRecordModel model)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[EncountersInsertRecord]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DexNum", model.PokedexNum).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Name", model.Name).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Type1", model.Type1).Direction = ParameterDirection.Input;
                    if (model.Type2 == null)
                    {
                        cmd.Parameters.AddWithValue("@Type2", DBNull.Value).Direction = ParameterDirection.Input;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Type2", model.Type2).Direction = ParameterDirection.Input;
                    }

                    cmd.Parameters.AddWithValue("@Ability", model.Ability).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@AbilDesc", model.AbilDesc).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Location", model.Location).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Sprite", model.Sprite).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Caught", model.Caught).Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("@ReturnValue", SqlDbType.UniqueIdentifier).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    var result = (Guid)cmd.Parameters["@ReturnValue"].Value;
                    conn.Close();
                    return result;
                }
            }
        }
    }
}
