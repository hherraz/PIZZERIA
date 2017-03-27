using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    class Conexion
    {
        public MySqlConnection cn = new MySqlConnection("server=rentaboxer.cl;database=pizzeria;uid=pizzeria;pwd=12345;");

        public void Abrir()
        {
            try
            {
                cn.Open();
                Console.WriteLine("********** Conexión Existosa! ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se puede conectar ! " + ex);
                Console.WriteLine(ex.Message);
            }
        }

        public void Cerrar()
        {
            try
            {
                cn.Close();
                Console.WriteLine("********** DES-Conexión Existosa! ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se puede desconectar ! " + ex);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
