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
    public class PokemonDAL : IPokemonDAL
    {
        private string sqlConnectString = string.Empty;
        private DatabaseConnectionSingleton connectionSingleton;

        public PokemonDAL()
        {
            connectionSingleton = DatabaseConnectionSingleton.Instance();
            sqlConnectString = connectionSingleton.PrepareDBConnection();
        }

        public PokemonRecordModel GetById(int id)
        {
            PokemonRecordModel model = new PokemonRecordModel();

            using (SqlConnection conn = new SqlConnection(sqlConnectString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[GetPokemonRecordById]", conn))
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
                        if (result[9] != DBNull.Value)
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
    }
}
