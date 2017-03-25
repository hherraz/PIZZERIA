using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    class Garzones
    {
        Conexion conX = new Conexion();

        //FUNCIONES
        public DataTable TraeGarzones()
        {
            Console.WriteLine("TRAE GARZONES");
            conX.Abrir();

            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter adap = new MySqlDataAdapter("select * from garzones;", conX.cn);
                adap.Fill(dt);
            }
            catch (MySqlException EX)
            {
                Console.WriteLine(EX.Message);
            }
            conX.Cerrar();
            return dt;
        }
        public int GarzonPedido(int num_pedido)
        {
            Console.WriteLine("Garzon en Numero de Pedido");
            int gar = 0;
            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT Id_Garzon FROM pedidos WHERE N_Pedido=@pedido;", conX.cn);
                cmd.Parameters.AddWithValue("@pedido", num_pedido);
                gar = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException EX)
            {
                Console.WriteLine(EX.Message);
            }
            conX.Cerrar();
            return gar;
        }
    }
}
