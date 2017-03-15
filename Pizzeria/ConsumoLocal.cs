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

        #region INSTANCIAS
        conexion conX = new conexion();

        NumerosPedido NumX = new NumerosPedido();
        Garzones garX = new Garzones();
        Mesas mesX = new Mesas();
        #endregion

        private void ConsumoLocal_Load(object sender, EventArgs e)
        {
            //formateo de la pantalla
            CentrarPantalla();

            //formateo del GridConsumo       
            FormatearGridConsumo();     

            //genera el folio para los pedidos
            label20.Text = Convert.ToString(NumX.GenerarNumero());
            NumX.LimpiarFoliosSinUso();

            //carga el listado de mesas
            ListaMesas.ValueMember = "IdMesa";
            ListaMesas.DisplayMember = "Nombre_Mesa";
            ListaMesas.DataSource = mesX.TraerMesas();

            //carga status de la mesa
            status.Text = mesX.StatusMesas(Convert.ToInt32(ListaMesas.SelectedValue.ToString()));

            //carga garzones
            ListaGarzones.ValueMember = "IdGarzon";
            ListaGarzones.DisplayMember = "aliasGarzon";
            ListaGarzones.DataSource = garX.TraeGarzones();

        }   ////**** LANZADOR DEL FORMULARIO

        #region FORMATEO DE LA PANTALLA
        private void CentrarPantalla()
        {
            this.Size = new Size(821, 422);
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }                                                               ////**** CENTRAR PANTALLA
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
        #endregion

        #region BOTONES GENERALES DEL FORMULARIO
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            if(GridConsumo.RowCount != 0)
            {
                DialogResult res = MessageBox.Show("Desea Cancelar el Pedido?", "Salir", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    Guardar();
                }
            }
            Close();
        }                                    ////**** BOTON TOPE DERECHO
        private void btn_pagar_Click(object sender, EventArgs e)
        {
            Guardar();
            MessageBox.Show("CONFIRMAR LA FORMA DE PAGO EN OTRO FORMULARIO");
            MessageBox.Show("DESEA CERRAR LA MESA?");
        }                                     ////**** BOTON PAGAR
        private void btnGuardarConsumo_Click(object sender, EventArgs e)
        {
            Guardar();
            Close();
        }                             ////**** BOTON PARA GUARDAR LOS DATOS DEL GRIDCONSUMO EN BASE DE DATOS
        #endregion

        #region BOTONES PARA AGREGAR AL PEDIDO
        private void AddPizzaMenu_Click(object sender, EventArgs e)
        {
            AddPizzaMenu PM = new AddPizzaMenu();
            PM.ShowDialog(this);
            PM.Dispose();
        }
        #endregion

        #region EVENTOS
        private void ConsumoLocal_Activated(object sender, EventArgs e)                                ////**** ACTUALIZA LA SUMA DEL GRID
        {
            ActualizarSuma();
        }                             

        private void GridConsumo_BorrarFila(object sender, DataGridViewCellEventArgs e)
        {
            //SI EL CLICK ES EN UNA FILA NUEVA, O INFERIOR A LA FILA 0
            if (e.RowIndex == GridConsumo.NewRowIndex || e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == GridConsumo.Columns["Borrar"].Index)
            {
                GridConsumo.Rows.RemoveAt(e.RowIndex);
            }
        }             ////**** BORRAR FILA DEL GRIDCONSUMO
        private void GridConsumo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ActualizarSuma();
        }     ////**** ACTUALIZA SUMA DESPUES DE BORRAR UNA FILA

        private void ListaMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            status.Text = mesX.StatusMesas(Convert.ToInt32(ListaMesas.SelectedValue.ToString()));

            if (status.Text == "CERRADA")
            {
                DialogResult res = MessageBox.Show("Desea abrir esta mesa?", "Mesas", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    btnGuardarConsumo.Visible = true;
                }
                else
                {
                    Close();
                }
            }
            else
            {
                btnGuardarConsumo.Visible = true;
                
                //BLOQUEA BOTONES
                ListaMesas.Enabled = false;
                ListaGarzones.Enabled = false;

                //TRAE PEDIDO MESA ABIERTA
                TrarPedidoMesa();
                NumX.BorrarPedido(Convert.ToInt32(label1.Text));

                //TRAER AL GARZON
                int num_pedido = NumX.TraeNumeroMesaAbierta(Convert.ToInt32(ListaMesas.SelectedValue.ToString()));
                ListaGarzones.SelectedValue = garX.GarzonPedido(num_pedido);

                //SUMAR
                ActualizarSuma();
            }
        }                    ////**** SI SE CAMBIA LA MESA, TRAE DATOS SI ESTA ABIERTA
        #endregion

        #region OPERACIONES EN GRIDCONSUMO
        public void Guardar()
        {
            if (status.Text == "ABIERTA")
            {
                label20.Text = Convert.ToString(Convert.ToInt32(label1.Text) - 1);
            }
            else
            {
                label20.Text = Convert.ToString(NumX.GenerarNumero());
                NumX.LimpiarFoliosSinUso();
            }
            //AGREGA A LA TABLA PEDIDOS
            AgregarPedidoMySql();
            //AGREGA A LA TABLA DETALLE DE PEDIDOS
            AgregaDetallePedidoMySql();
            //LIMPIA EL GRID
            GridConsumo.Rows.Clear();
            //MARCA EL NUMERO DE PEDIDO Y TRAE EL PROXIMO
            NumX.MarcarUltimoNumero(Convert.ToInt32(label20.Text));
            label20.Text = Convert.ToString(NumX.GenerarNumero());
            NumX.LimpiarFoliosSinUso();

            //LIBERA LOS BOTONES BLOQUEADOS
            ListaMesas.Enabled = true;
            ListaGarzones.Enabled = true;
        }                                                                        ////**** GUARDA EL GRID EN LA BASE DATOS
        public void AgregaDetallePedidoMySql()                                                          ////**** GUARDA LOS DATOS DEL GRID EN DETALLE PRODUCTOS
        {
            conX.Abrir();
            foreach (DataGridViewRow row in GridConsumo.Rows)
            {
                MySqlCommand GridConsumoMySql = new MySqlCommand("insert into prod_pedidos (N_Pedido, Cantidad, Item, Unitario, Subtotal) values (@N_pedido, @cantidad, @item, @unitario, @subtotal);", conX.cn);
                GridConsumoMySql.Parameters.AddWithValue("@N_pedido", Convert.ToInt32(label20.Text) + 1);       //N_pedido
                GridConsumoMySql.Parameters.AddWithValue("@cantidad", Convert.ToInt32(row.Cells[0].Value));     //cantidad
                GridConsumoMySql.Parameters.AddWithValue("@item", Convert.ToString(row.Cells[1].Value));        //item
                GridConsumoMySql.Parameters.AddWithValue("@unitario", Convert.ToInt32(row.Cells[2].Value));     //Unitario
                GridConsumoMySql.Parameters.AddWithValue("@subtotal", Convert.ToInt32(row.Cells[3].Value));     //subtotal
                GridConsumoMySql.ExecuteNonQuery();
            }
            conX.Cerrar();
        }
        public void AgregarPedidoMySql()
        {
            conX.Abrir();
            Console.WriteLine("AGREGAR PEDIDO");
            try
            {
                DateTime theDate = DateTime.Now;
                theDate.ToString("yyyy-MM-dd H:mm:ss");

                MySqlCommand cmd = new MySqlCommand("INSERT INTO pedidos (N_Pedido, Tipo_Pedido, Id_Mesa, Id_Garzon, Total_Pedido, Fecha_Pedido, PAGADO) VALUES (@N_Pedido, @Tipo_Pedido, @Id_Mesa, @Id_Garzon, @Total_Pedido, @Fecha_Pedido, @PAGADO)", conX.cn);
                cmd.Parameters.AddWithValue("@N_Pedido", Convert.ToInt32(label20.Text) + 1);
                cmd.Parameters.AddWithValue("@Tipo_Pedido", "Consumo");
                cmd.Parameters.AddWithValue("@Id_Mesa", Convert.ToInt32(ListaMesas.SelectedValue.ToString()));
                cmd.Parameters.AddWithValue("@Id_Garzon", Convert.ToInt32(ListaGarzones.SelectedValue.ToString()));
                cmd.Parameters.AddWithValue("@Total_Pedido", Convert.ToInt32(Total.Text));
                cmd.Parameters.AddWithValue("@Fecha_Pedido", theDate);
                cmd.Parameters.AddWithValue("@PAGADO", 0);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                conX.Cerrar();
            }
            conX.Cerrar();
            mesX.AbrirMesa(Convert.ToInt32(ListaMesas.SelectedValue.ToString()));
        }                                                             ////**** GUARDA LOS DATOS EN PEDIDO

        public void ActualizarSuma()
        {
            int sumatoria = 0;

            foreach (DataGridViewRow row in GridConsumo.Rows)
            {
                sumatoria += Convert.ToInt32(row.Cells["SubTotal"].Value);
            }

            Total.Text = Convert.ToString(sumatoria);
        }                                                                 ////**** CALCULA EL TOTAL A PAGAR
        public void TrarPedidoMesa()
        {
            int numPedido = NumX.TraeNumeroMesaAbierta(Convert.ToInt32(ListaMesas.SelectedValue.ToString()));
            conX.Abrir();
            try
            {
                Console.WriteLine("TRAE PEDIDO DE MESA ABIERTA");
                string sql = "SELECT Cantidad, Item, Unitario, Subtotal FROM prod_pedidos WHERE N_Pedido=" + numPedido + ";";
                MySqlDataAdapter adapt = new MySqlDataAdapter(sql, conX.cn);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    GridConsumo.Rows.Add(row["Cantidad"].ToString(), row["Item"].ToString(), row["Unitario"].ToString(), row["Subtotal"].ToString());
                }
                label1.Text = numPedido.ToString();
            }
            catch (MySqlException EX)
            {
                Console.WriteLine(EX.Message);
                conX.Cerrar();
            }
            conX.Cerrar();
        }                                                                 ////**** TRAE EL PEDIDO SI MESA ABIERTA
        #endregion
    }
}
