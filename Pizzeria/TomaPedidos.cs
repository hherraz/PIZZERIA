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
    public partial class TomaPedidos : Form
    {
        public TomaPedidos()
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
            this.Location = new Point(0, 25);
            this.Size = new Size(ancho, alto - 25);
        }                               ////**** CENTRAR PANTALLA
        private void TomaPedidos_Load(object sender, EventArgs e)
        {
            CentrarPantalla();          //formateo de la pantalla

            #region gridconsumo
            FormatearGridConsumo();     //formateo del GridConsumo
            GenerarFolio();             //genera el folio para los pedidos
            GenerarMesas();             //carga el listado de mesas
            #endregion

        }    ////**** LANZADOR DEL FORMULARIO
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }    ////**** BOTON CERRAR FOOTER
        #endregion

        #region OPERACIONES EN GRIDCONSUMO
        private void FormatearGridConsumo()
        {
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

        }                                  ////**** FORMATEAR GRIDCONSUMO

        public void GenerarMesas()
        {
            conX.Abrir();
            string sql = "SELECT mesas.idMesa, CONCAT( mesas.Nombre_Mesa, ' / ', statusmesas.nombre ) AS Detalle FROM mesas, statusmesas WHERE mesas.Status_Mesa = statusmesas.switch";
            MySqlCommand cmd = new MySqlCommand(sql, conX.cn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ListaMesas.ValueMember = "IdMesa";
            ListaMesas.DisplayMember = "Detalle";
            ListaMesas.DataSource = dt;

            conX.Cerrar();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CONFIRMAR LA FORMA DE PAGO EN OTRO FORMULARIO");
            MessageBox.Show("DESEA CERRAR LA MESA?");
        }               ////**** BOTON PAGAR
        private void button1_Click(object sender, EventArgs e)
        {
            PanelConsumoLocal.Visible = true;
            PanelConsumoLocal.Size = new Size(821, 422);
            PanelConsumoLocal.Location = new Point((ancho-PanelConsumoLocal.Width)/2, (alto-PanelConsumoLocal.Height)/2);

            btnConsumoLocal.BackColor=Color.Gray;
            btnRetiroLocal.BackColor = Color.Silver;
            btnDelivery.BackColor = Color.Silver;

            PanelRetiro.Visible = false;
            PanelDelivery.Visible = false;

            GenerarFolio();

            FooterTitle.Text = "TOMA DE PEDIDOS / CONSUMO EN EL LOCAL";
        }               ////**** BOTON CONSUMO
        private void btnRetiroLocal_Click(object sender, EventArgs e)
        {
            PanelRetiro.Visible = true;
            PanelRetiro.Size = new Size(821, 422);
            PanelRetiro.Location = new Point((ancho - PanelRetiro.Width) / 2, (alto - PanelRetiro.Height) / 2);

            btnConsumoLocal.BackColor = Color.Silver;
            btnRetiroLocal.BackColor = Color.Gray;
            btnDelivery.BackColor = Color.Silver;

            PanelConsumoLocal.Visible = false;
            PanelDelivery.Visible = false;

            GenerarFolio();

            FooterTitle.Text = "TOMA DE PEDIDOS / RETIRO EN EL LOCAL";
        }        ////**** BOTON RETIRO
        private void btnDelivery_Click(object sender, EventArgs e)
        {
            PanelDelivery.Visible = true;
            PanelDelivery.Size = new Size(821, 511);
            PanelDelivery.Location = new Point((ancho - PanelDelivery.Width) / 2, (alto - PanelDelivery.Height) / 2);

            btnConsumoLocal.BackColor = Color.Silver;
            btnRetiroLocal.BackColor = Color.Silver;
            btnDelivery.BackColor = Color.Gray;

            PanelRetiro.Visible = false;
            PanelConsumoLocal.Visible = false;

            GenerarFolio();

            FooterTitle.Text = "TOMA DE PEDIDOS / PEDIDO TELEFONICO";
        }           ////**** BOTON DELIVERY
        private void cerrar_Click(object sender, EventArgs e)
        {
            PanelConsumoLocal.Visible = false;
            PanelRetiro.Visible = false;
            PanelDelivery.Visible = false;

            btnConsumoLocal.BackColor = Color.Silver;
            btnRetiroLocal.BackColor = Color.Silver;
            btnDelivery.BackColor = Color.Silver;

            GenerarFolio();

            FooterTitle.Text = "TOMA DE PEDIDOS";
        }                ////**** BOTON CERRAR OPCIONES
        private void button3_Click(object sender, EventArgs e)
        {

            AddPizzaMenu PM = new AddPizzaMenu();
            PM.ShowDialog();
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
        private void TomaPedidos_Activated(object sender, EventArgs e)
        {
            ActualizarSuma();
        }                               ////**** ACTUALIZA SUMA
        private void GridConsumo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ActualizarSuma();
        }      ////**** ACTUALIZA SUMA

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
                    Console.WriteLine("PROBLEMA CON EL BORRADO DE LOS FOLIOS FANTASMAS");
                }
                conX.Cerrar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
        #endregion
    }
}
