using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    class Mesas
    {
        Conexion conX = new Conexion();

        //FUNCIONES
        public DataTable TraerMesas()
        {
            Console.WriteLine("Traer Mesas");
            DataTable dt = new DataTable();
            conX.Abrir();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from mesas;", conX.cn);
                da.Fill(dt);
            }
            catch (MySqlException EX)
            {
                Console.WriteLine(EX.Message);
            }
            conX.Cerrar();
            return dt;
        }
        public string StatusMesas(int IdMesa)
        {
            Console.WriteLine("STATUS DE MESA");
            string MesaStatus;
            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT Status_Mesa FROM mesas Where IdMesa=" + IdMesa + ";", conX.cn);
                MesaStatus = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            conX.Cerrar();

            if (MesaStatus == "True")
            {
                return "ABIERTA";
            }
            else
            {
                return "CERRADA";
            }
        }
        public int MesaPedido(int num_pedido)
        {
            Console.WriteLine("Mesa en Numero de Pedido");
            int Mesa = 0;
            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT Id_Mesa FROM pedidos WHERE N_Pedido=@pedido;", conX.cn);
                cmd.Parameters.AddWithValue("@pedido", num_pedido);
                Mesa = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException EX)
            {
                Console.WriteLine(EX.Message);
            }
            conX.Cerrar();
            return Mesa;
        }

        //PROCEDIMIENTOS
        public void AbrirMesa(int IdMesa)
        {
            Console.WriteLine("ABRIR MESA");
            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE mesas SET Status_Mesa=1 WHERE IdMesa=@mesa;", conX.cn);
                cmd.Parameters.AddWithValue("@mesa", IdMesa);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
        }
        public void CerrarMesa(int IdMesa)
        {
            Console.WriteLine("CERRAR MESA");
            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE mesas SET Status_Mesa=0 WHERE IdMesa=@mesa;", conX.cn);
                cmd.Parameters.AddWithValue("@mesa", IdMesa);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
        }

        public string TraerMesaPedido(int num_pedido)
        {
            string Mesa = "";
            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT mesas.Nombre_Mesa FROM mesas, pedidos WHERE mesas.IdMesa = pedidos.Id_Mesa AND(pedidos.N_Pedido = @pedido);", conX.cn);
                cmd.Parameters.AddWithValue("@pedido", num_pedido);
                Mesa = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (MySqlException EX)
            {
                Console.WriteLine(EX.Message);
            }
            conX.Cerrar();
            return Mesa;
        }

    }
}
