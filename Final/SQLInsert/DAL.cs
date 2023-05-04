using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Drawing.Imaging;

namespace SQLInsert
{
    public class DAL
    {
        private string _sqlConnString = String.Empty;
        public DAL()
        {
            PrepareConnection();

        }
        public void InsertPokemon(string name, int t1, int t2, int a, int sprite)
        {

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[InsertPokemon]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name", name).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Type_1_id", t1).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Type_2_id", t2).Direction = ParameterDirection.Input;
                    
                    sqlCommand.Parameters.AddWithValue("@Abil_id", a).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@sprite_Id", sprite).Direction = ParameterDirection.Input;

                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void InsertAbility(string name, string effect)
        {
            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[SpriteInsertRecord ]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name", name).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Effect", effect).Direction = ParameterDirection.Input;

                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public void InsertSprites(string name, string effect, int id)
        {
            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[SpritesInsertRecord]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Sprite_File_Path", name).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Shape_File_Path", effect).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Id", id).Direction = ParameterDirection.Input;
                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void InsertPokemonLocation(int mon, int loc,int id)
        {
            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[PokemonLocationInsertRecord]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@PokemonId", mon).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@LocationId", loc).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Id", id).Direction = ParameterDirection.Input;
                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void PrepareConnection()
        {
            SqlConnectionStringBuilder connBldr = new SqlConnectionStringBuilder();
            connBldr.DataSource = $"(localdb)\\MSSQLLocalDB";
            connBldr.IntegratedSecurity = true;
            connBldr.InitialCatalog = $"GuessThatPokemon";
            _sqlConnString = connBldr.ConnectionString;
        }
    }
}
