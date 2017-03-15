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
        conexion conX = new conexion();

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

    }
}
