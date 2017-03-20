using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    class NumerosPedido
    {
        conexion conX = new conexion();

        // FUNCIONES
        public int GenerarNumero()
        {
            int UltimoFolio=0;
            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT MAX(N_Pedido) FROM folios_pedidos WHERE (Usado = 1)", conX.cn);
                UltimoFolio = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine("ULTIMO FOLIO USADO: " + UltimoFolio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
            return UltimoFolio;
        }
        public int TraeNumeroMesaAbierta(int IdMesa)
        {
            Console.WriteLine("UBICAR NUMERO DE PEDIDO CUANDO MESA ABIERTA");
            int n_pedido = 0;
            conX.Abrir();
            try
            {
                string sql = "SELECT MAX(N_Pedido) FROM pedidos WHERE Id_Mesa=" + IdMesa + ";";
                MySqlCommand cmd = new MySqlCommand(sql, conX.cn);
                n_pedido = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException EX)
            {
                Console.WriteLine(EX.Message);
            }
            conX.Cerrar();
            return n_pedido;
        }

        //PROCEDIMIENTOS
        public void LimpiarFoliosSinUso()
        {
            conX.Abrir();
            try
            {
                MySqlCommand cmd1 = new MySqlCommand("Borrar_Folios_Fantasmas", conX.cn);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                int res = cmd1.ExecuteNonQuery();

                if (res == 1)
                {
                    Console.WriteLine("BORRADOS LOS FOLIOS SIN USO");
                }
                else
                {
                    Console.WriteLine("NO HABIAN FOLIOS SIN USAR");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
        }
        public void MarcarUltimoNumero(int nuevofolio)
        {
            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Nuevo_Folio_Pedido", conX.cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NUEVO", nuevofolio+1);
                int res = cmd.ExecuteNonQuery();

                if (res == 1)
                {
                    Console.WriteLine("INSERTADO EL NUEVO FOLIO");
                }
                else
                {
                    Console.WriteLine("ERROR AL INSERTAR EL NUEVO FOLIO");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en INSERT del SQL de Folios - NumeroPedido_usado");
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
        }
        public void BorrarPedido(int n_pedido)
        {
            conX.Abrir();
            Console.WriteLine("BORRAR PEDIDO");
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from prod_pedidos where n_pedido=?pedido;", conX.cn);
                cmd.Parameters.AddWithValue("?pedido", n_pedido);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
        }

        public void CerrarPedido(int n_pedido, int pagado, int totalpagado)
        {
            conX.Abrir();
            Console.WriteLine("CERRAR PEDIDO");
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE pedidos SET PAGADO=@pagado, TotalPagado=@totalpagado WHERE N_Pedido=@n_pedido;", conX.cn);
                cmd.Parameters.AddWithValue("@pagado", pagado);
                cmd.Parameters.AddWithValue("@totalpagado", totalpagado);
                cmd.Parameters.AddWithValue("@pedido", n_pedido);
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
