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

namespace APIService.Data_Access_Layers
{
    public class DAL
    {
        private string sqlConnectString = string.Empty;
        private DatabaseConnectionSingleton connectionSingleton;

        public DAL()
        {
            connectionSingleton = DatabaseConnectionSingleton.Instance();
            sqlConnectString = connectionSingleton.PrepareDBConnection();
        }

        public PokemonModel GetById(int id)
        {
            PokemonModel model = new PokemonModel();

            using(SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                using(SqlCommand sqlCommand = new SqlCommand("[dbo].[GetPokemonRecordById]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", id).Direction = ParameterDirection.Input;
                    
                    conn.Open();
                    var result = sqlCommand.ExecuteReader();

                    while (result.Read())
                    {
                        model.PokedexNumber = (int)result["dex_number"];
                        model.Name = (string)result["name"];
                        model.Type1 = (string)result[7];
                        if(result[9] != DBNull.Value)
                        {
                            model.Type2 = (string)result[9];
                        }
                        else
                        {
                            model.Type2 = string.Empty;
                        }
                        
                        model.Ability = (string)result["abi_name"];
                        model.AbilityDescription = (string)result["abi_effect"];
                        model.SpriteLocation = (string)result["sprite_path"];
                        model.OutlineLocation = (string)result["shape_path"];
                    }
                }
                conn.Close();
            }
            return model;
        }

        public List<string> GetLocationsMetByPokemonId(int id)
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[PokemonLocationsGetById]", conn))
                {
                    

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", id).Direction = ParameterDirection.Input;

                    conn.Open();
                    var results = sqlCommand.ExecuteReader();

                    while (results.Read())
                    {
                        result.Add((string)results["location_name"]);
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
                    if(model.Type2 == null)
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

        public Guid InsertGameRecord(GameRecordModel model)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[GamesInsertRecord]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerId", model.UserId).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@EncounterId", model.Encounter).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Timestemp", model.Timestamp).Direction = ParameterDirection.Input;
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

        public EncounterRecordModel GetEncounterById(Guid id)
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
    }
}
