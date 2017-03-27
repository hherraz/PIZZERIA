using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    class ClientesDelivery
    {
        Conexion conX = new Conexion();

        public List<string> TraeCliente(string telefono)
        {
            conX.Abrir();
            List<string> clientedelivery = new List<string>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM  clientes_delivery WHERE  DL_Telefono LIKE '%" + telefono + "%';", conX.cn);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientedelivery.Add(Convert.ToString(reader.GetInt32("idCliente")));      //0
                        clientedelivery.Add(reader.GetString("DL_Nombre"));      //1
                        clientedelivery.Add(reader.GetString("DL_Direccion"));   //2
                        clientedelivery.Add(reader.GetString("DL_Referencia"));  //3
                        clientedelivery.Add(reader.GetString("DL_Telefono"));    //4
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
            return clientedelivery;
        }

        public int InsertaCliente(string nombres, string direccion, string referencia, string telefono)
        {
            conX.Abrir();
            try
            {
                string sql = "INSERT INTO clientes_delivery (idCliente, DL_Nombre, DL_Direccion, DL_Referencia, DL_Telefono) VALUES (NULL, '" + nombres + "', '" + direccion + "', '" + referencia + "', '" + telefono + "');";
                MySqlCommand cmd = new MySqlCommand(sql, conX.cn);
                cmd.ExecuteScalar();
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            conX.Cerrar();
            return 1;
        }

        public int ModificarCliente(string nombres, string direccion, string referencia, string telefono, int idcliente)
        {
            conX.Abrir();
            try
            {
                string sql = "UPDATE clientes_delivery SET DL_Nombre='" + nombres + "', DL_Direccion='" + direccion + "', DL_Referencia='" + referencia + "',DL_Telefono='" + telefono + "' WHERE idCliente = " + idcliente + ";";
                MySqlCommand cmd = new MySqlCommand(sql, conX.cn);
                cmd.ExecuteScalar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            conX.Cerrar();
            return 1;
        }
    }
}
