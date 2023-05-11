using APPTienda.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace APPTienda
{
    public class Logic
    {
        public MySqlConnection getConnection()
        {
            MySqlConnection cn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString.ToString());
            return cn;
        }

        public List<Articulo> ObtenerArticulos()
        {
            const List<Articulo> = _connectionDb

            return new List<Articulo>();
        }
        {
            bool valid = false;
            try
            {
                using (MySqlConnection cn = getConnection())
                {
                    cn.Open();
                    string query = @"CALL `TED`.`sp_users`(null,null,null,'" + email + "','" + pass + "',0,null,'validar');";
                    MySqlCommand comando = new MySqlCommand(query, cn);
                    MySqlDataReader dr = comando.ExecuteReader();
                    while (dr.Read())
                    {
                        valid = true;
                    }
                    cn.Close();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return valid;
        }
    }
}
