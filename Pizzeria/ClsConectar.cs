using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pizzeria
{
    public class ClsConectar
    {
        public MySqlConnection conectar;
        public MySqlDataAdapter Adaptador = new MySqlDataAdapter();
        public MySqlDataReader Reader;


        public ClsConectar()
        { }
        public void Conexion()
        {
            try
            {
                conectar = new MySqlConnection("server=rentaboxer.cl; database=pizzeria; Uid=pizzeria; pwd=12345;");
                //return conectar;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }

        public void abrirConexion()
        {
            Conexion();
            try
            {
                conectar.Open();
                //MessageBox.Show("Conectado");

            }
            catch (MySqlException ex)
            {
                //cuando existe un error en nuestra aplicacion, siempre responde
                //con un erro numerico.
                //Los dos errores mas comunes son:
                //0: no se pudo conectar al servidor.
                //1045: usuario o password invalido.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("No se puede conectar con el servidor.comuniquese con el administrador");
                        break;

                    case 1045:
                        Console.WriteLine("Usuario o contraseña invalido, intente de nuevo");
                        break;
                }
                Console.Read();
            }

        }

        public void cerrarConexion()
        {
            conectar.Close();
            try
            {
                conectar.Close();
                Console.WriteLine("Conexion Finalizada");
                Console.Read();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }

            //Esta catch agregarlo despues del comando update    
            catch (NullReferenceException exn)
            {
                Console.WriteLine("\n Error de referncia a objeto nula: \n\n" + exn);
            }
            Console.Read();
        }

        public void ejecutarQuery(string ingresar)
        {
            MySqlCommand Comando = conectar.CreateCommand();  // revisar con heber
            Comando.CommandText = ingresar;
            try
            {
                abrirConexion();
                Reader = Comando.ExecuteReader();
                cerrarConexion();
            }
            catch (MySqlException ee)
            {
                MessageBox.Show("error" + ee);
            }

        }
    }
}
