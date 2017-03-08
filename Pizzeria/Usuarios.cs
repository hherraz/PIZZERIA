using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    class Usuarios
    {
        conexion conX = new conexion();

        public int ValidarUsuario(string user, string pass)
        {
            int CantidadOK = 0;
            try
            {
                conX.Abrir();
                MySqlCommand Users = new MySqlCommand("SELECT COUNT(*) FROM USUARIOS WHERE user=?user AND pass=?pass;", conX.cn);
                Users.Parameters.AddWithValue("?user", user);
                Users.Parameters.AddWithValue("?pass", pass);
                CantidadOK = Convert.ToInt32(Users.ExecuteScalar());
                conX.Cerrar();
                return CantidadOK;
            }
            catch (Exception Ex)
            {
                Console.Write("Error de verificar usuario: " + Ex);
                return 0;
            }
        }

        public List<string> DatosUsuario(string user)
        {
            List<string> dtUsuario = new List<string>();

            try
            {
                conX.Abrir();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM USUARIOS WHERE user = ?usuario", conX.cn);
                cmd.Parameters.AddWithValue("?usuario", user);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dtUsuario.Add(reader.GetString(reader.GetOrdinal("IdUsuario")));        //0
                        dtUsuario.Add(reader.GetString(reader.GetOrdinal("user")));             //1
                        dtUsuario.Add(reader.GetString(reader.GetOrdinal("pass")));             //2
                        dtUsuario.Add(reader.GetString(reader.GetOrdinal("NombreUsuario")));    //3
                        dtUsuario.Add(reader.GetString(reader.GetOrdinal("DireccionUsuario"))); //4
                        dtUsuario.Add(reader.GetString(reader.GetOrdinal("TelefonoUsuario")));  //5
                        dtUsuario.Add(reader.GetString(reader.GetOrdinal("MailUsuario")));      //6
                        dtUsuario.Add(reader.GetString(reader.GetOrdinal("Nivel")));            //7
                    }
                }
                conX.Cerrar();
                return dtUsuario;
            }
            catch (Exception Ex)
            {
                Console.Write("Sin nombre de usuario: " + Ex);
                return null;
            }
        }

        public void log(string user)
        {
            try
            {
                conX.Abrir(); 
                MySqlCommand cmd = new MySqlCommand("LogUsuario", conX.cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UserX", user);

                int res = cmd.ExecuteNonQuery();

                if (res == 1)
                {
                    Console.WriteLine("LOG OK");
                }
                else
                {
                    Console.WriteLine("PROBLEMA CON EL LOG");
                }
                conX.Cerrar();
            }catch(Exception EX)
            {
                Console.WriteLine(EX.Message);
            }
        }

    }
}
