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
    public partial class RetiroLocal : Form
    {
        public RetiroLocal()
        {
            InitializeComponent();
        }

        #region INSTANCIAS
        conexion conX = new conexion();
        NumerosPedido NumX = new NumerosPedido();
        #endregion

        private void RetiroLocal_Load(object sender, EventArgs e)
        {
            //Guardo Nombre del Formulari Activo
            DatosCompartidos.Instance().NombreFormularioActivo = "RetiroLocal";

            //formateo de la pantalla
            CentrarPantalla();

            //formateo del GridConsumo       
            FormatearGridConsumo();

            //genera el folio para los pedidos
            label20.Text = Convert.ToString(NumX.GenerarNumero());
            NumX.LimpiarFoliosSinUso();

        }   ////**** LANZADOR DEL FORMULARIO

        #region FORMATEO DE LA PANTALLA
        private void CentrarPantalla()
        {
            this.Size = new Size(821, 422);
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }                                                               ////**** CENTRAR PANTALLA
        private void FormatearGridConsumo()
        {
            GridRetiro.AutoGenerateColumns = false;
            GridRetiro.AllowUserToAddRows = false;
            GridRetiro.ReadOnly = true;

            GridRetiro.ColumnHeadersVisible = true;
            GridRetiro.MultiSelect = false;
            GridRetiro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridRetiro.ColumnCount = 4;

            GridRetiro.Columns[0].Name = "Cantidad";
            GridRetiro.Columns[1].Name = "Item";
            GridRetiro.Columns[2].Name = "Unitario";
            GridRetiro.Columns[3].Name = "SubTotal";

            GridRetiro.Columns[0].Width = 100;
            GridRetiro.Columns[1].Width = 300;
            GridRetiro.Columns[2].Width = 100;
            GridRetiro.Columns[3].Width = 100;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            GridRetiro.Columns.Add(btn);
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
            if (GridRetiro.RowCount != 0)
            {
                Guardar();
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
        private void button4_Click(object sender, EventArgs e)
        {
            ArmaPizza arma = new ArmaPizza();
            arma.ShowDialog(this);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddProductos prod = new AddProductos();
            prod.ShowDialog(this);
        }
        #endregion

        #region EVENTOS
        private void RetiroLocal_Activated(object sender, EventArgs e)                                ////**** ACTUALIZA LA SUMA DEL GRID
        {
            ActualizarSuma();
        }

        private void GridRetiro_BorrarFila(object sender, DataGridViewCellEventArgs e)
        {

        }             ////**** BORRAR FILA DEL GRIDCONSUMO
        private void GridRetiro_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ActualizarSuma();
        }     ////**** ACTUALIZA SUMA DESPUES DE BORRAR UNA FILA


        #endregion

        #region OPERACIONES EN GRIDCONSUMO
        public void Guardar()
        {
            if(txtNombre.TextLength!=0 && txtTelefono.TextLength != 0)
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
                GridRetiro.Rows.Clear();
                //MARCA EL NUMERO DE PEDIDO Y TRAE EL PROXIMO
                NumX.MarcarUltimoNumero(Convert.ToInt32(label20.Text));
                label20.Text = Convert.ToString(NumX.GenerarNumero());
                NumX.LimpiarFoliosSinUso();

                txtNombre.BackColor = Color.White;
                txtTelefono.BackColor = Color.White;

            }
            else
            {
                MessageBox.Show("ERROR, DEBE INGRESAR UN NOMBRE O UN TELEFONO VALIDO.");
                if (txtNombre.TextLength == 0)
                {
                    txtNombre.BackColor = Color.Red;
                    txtNombre.Focus();
                }
                if (txtTelefono.TextLength == 0)
                {
                    txtTelefono.BackColor = Color.Red;
                    txtTelefono.Focus();
                }
            }
        }                                                                        ////**** GUARDA EL GRID EN LA BASE DATOS
        public void AgregaDetallePedidoMySql()                                                          ////**** GUARDA LOS DATOS DEL GRID EN DETALLE PRODUCTOS
        {
            conX.Abrir();
            foreach (DataGridViewRow row in GridRetiro.Rows)
            {
                MySqlCommand GridConsumoMySql = new MySqlCommand("insert into prod_pedidos (N_Pedido, Cantidad, Item, Unitario, Subtotal, Cocina) values (@N_pedido, @cantidad, @item, @unitario, @subtotal, 0);", conX.cn);
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

                MySqlCommand cmd = new MySqlCommand("INSERT INTO pedidos (N_Pedido, Tipo_Pedido, Id_Mesa, Id_Garzon, Fecha_Pedido, PAGADO, NombreRetiro, TelefonoRetiro) VALUES (@N_Pedido, @Tipo_Pedido, @Id_Mesa, @Id_Garzon, @Fecha_Pedido, @PAGADO, @NombreRetiro, @TelefonoRetiro)", conX.cn);
                cmd.Parameters.AddWithValue("@N_Pedido", Convert.ToInt32(label20.Text) + 1);
                cmd.Parameters.AddWithValue("@Tipo_Pedido", "Retiro");
                cmd.Parameters.AddWithValue("@Id_Mesa", 2);
                cmd.Parameters.AddWithValue("@Id_Garzon", 2);
                cmd.Parameters.AddWithValue("@Fecha_Pedido", theDate);
                cmd.Parameters.AddWithValue("@PAGADO", 0);
                cmd.Parameters.AddWithValue("@NombreRetiro", txtNombre.Text);
                cmd.Parameters.AddWithValue("@TelefonoRetiro", txtTelefono.Text);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                conX.Cerrar();
            }
            conX.Cerrar();
        }                                                             ////**** GUARDA LOS DATOS EN PEDIDO

        public void ActualizarSuma()
        {
            int sumatoria = 0;

            foreach (DataGridViewRow row in GridRetiro.Rows)
            {
                sumatoria += Convert.ToInt32(row.Cells["SubTotal"].Value);
            }

            Total.Text = Convert.ToString(sumatoria);
        }                                                                 ////**** CALCULA EL TOTAL A PAGAR
        #endregion

        #region HABILITAR BOTON GUARDAR
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.TextLength > 1 && txtTelefono.TextLength > 5)
            {
                btnGuardarConsumo.Visible = true;
            }
        }
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.TextLength > 1 && txtTelefono.TextLength > 5)
            {
                btnGuardarConsumo.Visible = true;
            }
        }
        #endregion


    }
}
