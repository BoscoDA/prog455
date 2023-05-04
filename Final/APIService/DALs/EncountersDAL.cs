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
    public class EncountersDAL
    {
        private string sqlConnectString = string.Empty;
        private DatabaseConnectionSingleton connectionSingleton;

        public EncountersDAL()
        {
            connectionSingleton = DatabaseConnectionSingleton.Instance();
            sqlConnectString = connectionSingleton.PrepareDBConnection();
        }

        public List<EncounterRecordModel> GetById(Guid id)
        {
            List<EncounterRecordModel> models = new List<EncounterRecordModel>();

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
                        EncounterRecordModel model = new EncounterRecordModel();
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
                        model.ID = (Guid)results["id"];

                        models.Add(model);
                    }
                }
                conn.Close();
            }
            return models;
        }
    }
}
