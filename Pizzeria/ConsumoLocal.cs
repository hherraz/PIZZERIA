using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzeria
{
    public partial class ConsumoLocal : Form
    {
        public ConsumoLocal()
        {
            InitializeComponent();
        }

        #region VARIABLES
        public int ancho = Screen.PrimaryScreen.Bounds.Width;
        public int alto = Screen.PrimaryScreen.Bounds.Height;
        conexion conX = new conexion();
        #endregion

        #region FORMATO GENERAL DEL FORMULARIO
        private void CentrarPantalla()
        {
            // tamaño de la pantalla para todos los menus
            this.Size = new Size(821, 422);
            this.Location = new Point((ancho - this.Width)/2,(alto-this.Height)/2);
            
        }                               ////**** CENTRAR PANTALLA
        private void ConsumoLocal_Load(object sender, EventArgs e)
        {
            CentrarPantalla();          //formateo de la pantalla
            FormatearGridConsumo();     //formateo del GridConsumo
            GenerarFolio();             //genera el folio para los pedidos
            GenerarMesas();             //carga el listado de mesas

        }   ////**** LANZADOR DEL FORMULARIO
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }    ////**** BOTON TOPE DERECHO
        #endregion

        #region OPERACIONES EN GRIDCONSUMO
        private void FormatearGridConsumo()
        {
            GridConsumo.AutoGenerateColumns = false;
            GridConsumo.AllowUserToAddRows = false;
            GridConsumo.ReadOnly = true;

            GridConsumo.ColumnHeadersVisible = true;
            GridConsumo.MultiSelect = false;
            GridConsumo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridConsumo.ColumnCount = 4;

            GridConsumo.Columns[0].Name = "Cantidad";
            GridConsumo.Columns[1].Name = "Item";
            GridConsumo.Columns[2].Name = "Unitario";
            GridConsumo.Columns[3].Name = "SubTotal";

            GridConsumo.Columns[0].Width = 100;
            GridConsumo.Columns[1].Width = 300;
            GridConsumo.Columns[2].Width = 100;
            GridConsumo.Columns[3].Width = 100;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            GridConsumo.Columns.Add(btn);
            btn.Text = "Borrar";
            btn.ToolTipText = "Borrar";
            btn.Name = "Borrar";
            btn.UseColumnTextForButtonValue = true;
            btn.Width = 100;
            btn.HeaderText = "";

        }                                                          ////**** FORMATEAR GRIDCONSUMO
        private void GenerarFolio()
        {
            try
            {
                conX.Abrir();
                MySqlCommand cmd = new MySqlCommand("SELECT MAX(N_Pedido) FROM folios_pedidos WHERE (Usado = 1)", conX.cn);
                int UltimoFolio = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine("SE HA RESCATADO EL ULTIMO FOLIO USADO: " + UltimoFolio);
                label20.Text = Convert.ToString(UltimoFolio);
                conX.Cerrar();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conX.Cerrar();
            }

            try
            {
                conX.Abrir();
                MySqlCommand cmd1 = new MySqlCommand("Borrar_Folios_Fantasmas", conX.cn);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                int res = cmd1.ExecuteNonQuery();

                if (res == 1)
                {
                    Console.WriteLine("BORRADOS LOS FOLIOS FANTASMAS");
                }
                else
                {
                    Console.WriteLine("NO HABIAN FOLIOS FANTASMAS A BORRAR");
                }

                conX.Cerrar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                conX.Cerrar();
            }
        }                                                                  ////**** GENERA EL NUMERO DE FOLIO Y BORRA LOS FANTASMAS
        private void NumeroPedido_Usado()
        {
            try
            {
                conX.Abrir();
                int nuevofolio = Convert.ToInt32(label20.Text) + 1;
                MySqlCommand cmd = new MySqlCommand("Nuevo_Folio_Pedido", conX.cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("NUEVO", nuevofolio);
                int res = cmd.ExecuteNonQuery();

                if (res == 1)
                {
                    Console.WriteLine("INSERTADO EL NUEVO FOLIO");
                }
                else
                {
                    Console.WriteLine("ERROR AL INSERTAR EL NUEVO FOLIO");
                }
                conX.Cerrar();

                GenerarFolio();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en INSERT del SQL de Folios - NumeroPedido_usado");
                Console.WriteLine(ex.Message);
            }
        }                                                            ////**** MARCA EL NUMERO DE FOLIO USADO
        private void btn_pagar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CONFIRMAR LA FORMA DE PAGO EN OTRO FORMULARIO");
            MessageBox.Show("DESEA CERRAR LA MESA?");
        }                                     ////**** BOTON PAGAR

        private void AddPizzaMenu_Click(object sender, EventArgs e)
        {
            AddPizzaMenu PM = new AddPizzaMenu();
            PM.ShowDialog(this);
            PM.Dispose();
        }
        private void GridConsumo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //SI EL CLICK ES EN UNA FILA NUEVA, O INFERIOR A LA FILA 0
            if (e.RowIndex == GridConsumo.NewRowIndex || e.RowIndex < 0)
            {
                return;
            }
            if(e.ColumnIndex == GridConsumo.Columns["Borrar"].Index)
            {
                GridConsumo.Rows.RemoveAt(e.RowIndex);
            }

        }               ////**** BORRAR FILA DEL GRIDCONSUMO
        public void GridConsumo_ProductosMySql()                                                        ////**** GUARDA LOS DATOS DEL GRID EN LA BASE DE DATOS
        {
            conX.Abrir();
            foreach (DataGridViewRow row in GridConsumo.Rows)
            {
                MySqlCommand GridConsumoMySql = new MySqlCommand("insert into prod_pedidos (N_Pedido, Cantidad, Item, Unitario, Subtotal) values (@N_pedido, @cantidad, @item, @unitario, @subtotal);", conX.cn);
                GridConsumoMySql.Parameters.AddWithValue("@N_pedido", Convert.ToInt32(label20.Text) + 1);           //N_pedido
                GridConsumoMySql.Parameters.AddWithValue("@cantidad", Convert.ToInt32(row.Cells[0].Value));     //cantidad
                GridConsumoMySql.Parameters.AddWithValue("@item", Convert.ToString(row.Cells[1].Value));        //item
                GridConsumoMySql.Parameters.AddWithValue("@unitario", Convert.ToInt32(row.Cells[2].Value));     //Unitario
                GridConsumoMySql.Parameters.AddWithValue("@subtotal", Convert.ToInt32(row.Cells[3].Value));     //subtotal
                GridConsumoMySql.ExecuteNonQuery();
            }
            conX.Cerrar();
        }
        private void btnGuardarConsumo_Click(object sender, EventArgs e)
        {
            GenerarFolio();
            GridConsumo_ProductosMySql();
            GridConsumo.Rows.Clear();

            NumeroPedido_Usado();

        }                             ////**** BOTON PARA GUARDAR LOS DATOS DEL GRIDCONSUMO EN BASE DE DATOS
        public void ActualizarSuma()
        {
            int sumatoria = 0;

            foreach (DataGridViewRow row in GridConsumo.Rows)
            {
                sumatoria += Convert.ToInt32(row.Cells["SubTotal"].Value);
            }

            Total.Text = Convert.ToString(sumatoria);
        }                                                                 ////**** CALCULA EL TOTAL A PAGAR
        private void ConsumoLocal_Activated(object sender, EventArgs e)
        {
            ActualizarSuma();
        }                              ////**** ACTUALIZA SUMA
        private void GridConsumo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ActualizarSuma();
        }      ////**** ACTUALIZA SUMA
        #endregion

        #region MESAS
        public void GenerarMesas()
        {
            conX.Abrir();
            Console.WriteLine("ABRE");
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from mesas;", conX.cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (MySqlException EX)
            {
                Console.WriteLine(EX.Message);
                conX.Cerrar();
            }
            conX.Cerrar();
            Console.WriteLine("CIERRA");

            ListaMesas.ValueMember = "IdMesa";
            ListaMesas.DisplayMember = "Nombre_Mesa";
            ListaMesas.DataSource = dt;

            CargarStatusMesas();
        }
        public void CargarStatusMesas()
        {
            Console.WriteLine("############### CARGA STATUS DE MESA");
            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT Status_Mesa FROM mesas Where Nombre_Mesa=" + ListaMesas.SelectedValue.ToString() + ";", conX.cn);
                string MesaStatus = Convert.ToString(cmd.ExecuteScalar());
                if (MesaStatus == "True")
                {
                    status.Text = "ABIERTA";
                }
                else
                {
                    status.Text = "CERRADA";
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                conX.Cerrar();
            }
            conX.Cerrar();
        }

        public int UbicaNumeroPedido()
        {
            Console.WriteLine("############### UBICAR NUMERO DE PEDIDO CUANDO MESA EXISTE");
            int n_pedido=0;
            conX.Abrir();
            try
            {
                string sql = "SELECT N_Pedido FROM pedidos WHERE Id_Mesa=" + ListaMesas.SelectedValue.ToString() + ";";
                MySqlCommand cmd = new MySqlCommand(sql, conX.cn);
                n_pedido = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch(MySqlException EX)
            {
                Console.WriteLine(EX.Message);
                conX.Cerrar();
            }
            conX.Cerrar();
            return n_pedido;
        }                                                               //SI LA MESA ESTA ABIERTA - UBICA EL NUMERO DE PEDIDO
        
        private void ListaMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarStatusMesas();                                                                        //IDENTIFICA SI LA MESA ESTA ABIERTA O CERRADA

            Console.WriteLine("############### CUANDO CAMBIA EL INDICE DE MESAS");
            if (status.Text == "ABIERTA")
            {
                int numPedido = UbicaNumeroPedido();
                conX.Abrir();
                try
                {
                    Console.WriteLine("############### DESCARGA AL GRID PEDIDO DE MESA ABIERTA");
                    string sql = "SELECT Cantidad, Item, Unitario, Subtotal FROM prod_pedidos WHERE N_Pedido=" + numPedido + ";";
                    MySqlDataAdapter adapt = new MySqlDataAdapter(sql, conX.cn);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    foreach(DataRow row in dt.Rows)
                    {
                        GridConsumo.Rows.Add(row["Cantidad"].ToString(),row["Item"].ToString(),row["Unitario"].ToString(),row["Subtotal"].ToString());
                    }
                    label20.Text = numPedido.ToString();
                }
                catch (MySqlException EX)
                {
                    Console.WriteLine(EX.Message);
                    conX.Cerrar();
                }
                borrarpedidotemporal();
                conX.Cerrar();
            }
        }

        private void borrarpedidotemporal()
        {
            conX.Abrir();
            Console.WriteLine("############################## BORRAR PEDIDO TEMPORAL ##########################");
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from prod_pedidos where n_pedido=?pedido;");
                cmd.Parameters.AddWithValue("?pedido", label20.Text);
                cmd.ExecuteNonQuery();
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                conX.Cerrar();
            }
            conX.Cerrar();
        }
        #endregion
    }
}
