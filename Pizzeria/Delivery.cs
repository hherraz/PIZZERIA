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
    public partial class Delivery : Form
    {
        public Delivery()
        {
            InitializeComponent();
        }

        int switchModificar=0; //switch de 2 pasos para boton modificar

        #region INSTANCIAS
        conexion conX = new conexion();
        NumerosPedido NumX = new NumerosPedido();
        ClientesDelivery cd = new ClientesDelivery();
        Mesas mesX = new Mesas();
        #endregion

        private void Delivery_Load(object sender, EventArgs e)
        {
            txtTelefono.Focus();

            //Guardo Nombre del Formulari Activo
            DatosCompartidos.Instance().NombreFormularioActivo = "Delivery";

            //formateo de la pantalla
            CentrarPantalla();

            //formateo del GridConsumo       
            FormatearGridConsumo();

            //genera el folio para los pedidos
            label20.Text = Convert.ToString(NumX.GenerarNumero());
            NumX.LimpiarFoliosSinUso();

            //carga el combobox forma de pago
            FormaPagoCombo();

        }   ////**** LANZADOR DEL FORMULARIO

        #region FORMATEO DE LA PANTALLA
        private void CentrarPantalla()
        {
            this.Size = new Size(820, 550);
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }                                                               ////**** CENTRAR PANTALLA
        private void FormatearGridConsumo()
        {
            GridDelivery.AutoGenerateColumns = false;
            GridDelivery.AllowUserToAddRows = false;
            GridDelivery.ReadOnly = true;

            GridDelivery.ColumnHeadersVisible = true;
            GridDelivery.MultiSelect = false;
            GridDelivery.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridDelivery.ColumnCount = 4;

            GridDelivery.Columns[0].Name = "Cantidad";
            GridDelivery.Columns[1].Name = "Item";
            GridDelivery.Columns[2].Name = "Unitario";
            GridDelivery.Columns[3].Name = "SubTotal";

            GridDelivery.Columns[0].Width = 100;
            GridDelivery.Columns[1].Width = 300;
            GridDelivery.Columns[2].Width = 100;
            GridDelivery.Columns[3].Width = 100;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            GridDelivery.Columns.Add(btn);
            btn.Text = "Borrar";
            btn.ToolTipText = "Borrar";
            btn.Name = "Borrar";
            btn.UseColumnTextForButtonValue = true;
            btn.Width = 100;
            btn.HeaderText = "";
        }                                                          ////**** FORMATEAR GRIDCONSUMO
        public void FormaPagoCombo()
        {
            conX.Abrir();
            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter adapt=new MySqlDataAdapter("select * from formapago", conX.cn);
                adapt.Fill(dt);
                FormaPago.DataSource = dt;
                FormaPago.ValueMember = "FormaPago";
                FormaPago.DisplayMember = "FormaPago";
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
        }
        #endregion

        #region BOTONES GENERALES DEL FORMULARIO
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            if (GridDelivery.RowCount != 0)
            {
                Guardar();
            }
            Close();
        }                                    ////**** BOTON TOPE DERECHO
        private void btn_pagar_Click(object sender, EventArgs e)
        {
            //GUARDAR PARA OBTENER LA ULTIMA MODIFICACION
            Guardar();

            if (GridDelivery.RowCount > 0)
            {
                //PASAR VARIABLE DEL NUMERO DE PEDIDO AL GLOBAL
                DatosCompartidos.Instance().PagarPedido = Convert.ToInt32(label20.Text);

                //ABRIR FORMULARIO
                Pagar pag = new Pagar();
                pag.ShowDialog(this);

                //VERIFICAR QUE SE HAYA PAGADO Y TERMINAR EL PROCESO
                if (DatosCompartidos.Instance().Pagado == 1)
                {
                    //PAGADO OK
                    mesX.CerrarMesa(2);

                    DatosCompartidos.Instance().PagarPedido = 0;
                    DatosCompartidos.Instance().Pagado = 0;
                }
                else
                {
                    MessageBox.Show("PEDIDO NO PAGADO");
                }
                Close();
            }
            else
            {
                MessageBox.Show("NO HAY PRODUCTOS PARA REALIZAR EL PAGO.\nAGREGUE ALGUNOS Y CONTINUE CON EL PAGO.");
            }

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
        private void Delivery_Activated(object sender, EventArgs e)                                ////**** ACTUALIZA LA SUMA DEL GRID
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
            if(txtNombre.TextLength!=0 && txtDireccion.TextLength!=0 && txtTelefono.TextLength != 0)
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

                //SU NUMERO DE PEDIDO ES
                MessageBox.Show("Su numero de pedido es el: " + (Convert.ToInt32(label20.Text)+1));

                //LIMPIA EL GRID
                GridDelivery.Rows.Clear();
                //MARCA EL NUMERO DE PEDIDO Y TRAE EL PROXIMO
                NumX.MarcarUltimoNumero(Convert.ToInt32(label20.Text));
                label20.Text = Convert.ToString(NumX.GenerarNumero());
                NumX.LimpiarFoliosSinUso();

                txtNombre.BackColor = Color.White;
                txtTelefono.BackColor = Color.White;
                txtDireccion.BackColor = Color.White;
            }
            else
            {
                MessageBox.Show("ERROR, FALTAN DATOS DEL SOLICITANTE PARA COMPLETAR EL PEDIDO.\nCOMPLETE LOS DATOS EN ROJO Y CONTINUE.");
                if (txtNombre.TextLength == 0)
                {
                    txtNombre.BackColor = Color.Red;
                    txtNombre.Focus();
                }
                if (txtDireccion.TextLength == 0)
                {
                    txtDireccion.BackColor = Color.Red;
                    txtDireccion.Focus();
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
            foreach (DataGridViewRow row in GridDelivery.Rows)
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
            if (txtVuelto.TextLength == 0)
            {
                txtVuelto.Text = "0";
            }

            try
            {
                DateTime theDate = DateTime.Now;
                theDate.ToString("yyyy-MM-dd H:mm:ss");

                MySqlCommand cmd = new MySqlCommand("INSERT INTO pedidos (N_Pedido, Tipo_Pedido, Id_Mesa, Id_Garzon, Fecha_Pedido, PAGADO, NombreRetiro, TelefonoRetiro, IdClienteDelivery, FormaPago, Vuelto) VALUES (@N_Pedido, @Tipo_Pedido, @Id_Mesa, @Id_Garzon, @Fecha_Pedido, @PAGADO, @NombreRetiro, @TelefonoRetiro, @idcliente, @formapago, @vuelto )", conX.cn);
                cmd.Parameters.AddWithValue("@N_Pedido", Convert.ToInt32(label20.Text) + 1);
                cmd.Parameters.AddWithValue("@Tipo_Pedido", "DELIVERY");
                cmd.Parameters.AddWithValue("@Id_Mesa", 2);
                cmd.Parameters.AddWithValue("@Id_Garzon", 2);
                cmd.Parameters.AddWithValue("@Fecha_Pedido", theDate);
                cmd.Parameters.AddWithValue("@PAGADO", 0);
                cmd.Parameters.AddWithValue("@NombreRetiro", txtNombre.Text);
                cmd.Parameters.AddWithValue("@TelefonoRetiro", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@idcliente", IDCLIENTE.Text);
                cmd.Parameters.AddWithValue("@formapago", FormaPago.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@vuelto", Convert.ToInt32(txtVuelto.Text));




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

            foreach (DataGridViewRow row in GridDelivery.Rows)
            {
                sumatoria += Convert.ToInt32(row.Cells["SubTotal"].Value);
            }

            Total.Text = Convert.ToString(sumatoria);
        }                                                                 ////**** CALCULA EL TOTAL A PAGAR
        #endregion

        #region BOTONES CLIENTE
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtReferencia.Clear();

            List<string> cliente = new List<string>();
            cliente = cd.TraeCliente(txtTelefono.Text);

            if (cliente.Count != 0)
            {
                IDCLIENTE.Text = cliente[0].ToString();
                txtNombre.Text = cliente[1].ToString();
                txtDireccion.Text = cliente[2].ToString();
                txtReferencia.Text = cliente[3].ToString();
                txtTelefono.Text = cliente[4].ToString();
                btnGuardarConsumo.Visible = true;
            }
            else
            {
                MessageBox.Show("Numero no se encuentra. \nIngreselo como nuevo Cliente.");
                txtNombre.Enabled = true;
                txtDireccion.Enabled = true;
                txtReferencia.Enabled = true;
            }
        }                                     ////**** BOTON BUSCAR
        private void deliveryAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.TextLength == 0)
            {
                MessageBox.Show("EL CAMPO NOMBRE ESTA VACIO\nCORRIJALO.");
            }
            else if (txtDireccion.TextLength == 0)
            {
                MessageBox.Show("EL CAMPO DIRECCION ESTA VACIO\nCORRIJALO.");
            }
            else if (txtTelefono.TextLength == 0)
            {
                MessageBox.Show("EL CAMPO TELEFONO ESTA VACIO\nCORRIJALO.");
            }
            else
            {
                if (txtReferencia.TextLength == 0)
                {
                    txtReferencia.Text = "-";
                }
                if (cd.InsertaCliente(txtNombre.Text, txtDireccion.Text, txtReferencia.Text, txtTelefono.Text) == 1)
                {
                    MessageBox.Show("Cliente ingresado con Exito");
                    txtNombre.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtReferencia.Enabled = false;
                    btnBuscar_Click(null, null);
                }
                else
                {
                    MessageBox.Show("ERROR - No se ingreso Cliente");
                }
            }
        }                               ////**** BOTON AGREGAR
        private void deliveryModificar_Click(object sender, EventArgs e)
        {
            if (switchModificar == 0)
            {
                txtNombre.Enabled = true;
                txtDireccion.Enabled = true;
                txtReferencia.Enabled = true;
                txtTelefono.Enabled = true;

                btnBuscar.Enabled = false;
                deliveryAgregar.Enabled = false;
                deliveryBorrar.Enabled = false;
                deliveryModificar.Text = "LISTO";
                switchModificar = 1;
            }
            else
            {
                if (txtNombre.TextLength == 0)
                {
                    MessageBox.Show("EL CAMPO NOMBRE ESTA VACIO\nCORRIJALO.");
                }
                else if (txtDireccion.TextLength == 0)
                {
                    MessageBox.Show("EL CAMPO DIRECCION ESTA VACIO\nCORRIJALO.");
                }
                else if (txtTelefono.TextLength == 0)
                {
                    MessageBox.Show("EL CAMPO TELEFONO ESTA VACIO\nCORRIJALO.");
                }
                else
                {
                    if (txtReferencia.TextLength == 0)
                    {
                        txtReferencia.Text = "-";
                    }
                    if (cd.ModificarCliente(txtNombre.Text, txtDireccion.Text, txtReferencia.Text, txtTelefono.Text, Convert.ToInt32(IDCLIENTE.Text)) == 1)
                    {
                        MessageBox.Show("Cliente Modificado con Exito");
                        txtNombre.Enabled = false;
                        txtDireccion.Enabled = false;
                        txtReferencia.Enabled = false;

                        btnBuscar.Enabled = true;
                        deliveryAgregar.Enabled = true;
                        deliveryBorrar.Enabled = true;
                        deliveryModificar.Text = "MODIFICAR";
                        switchModificar = 0;

                        btnBuscar_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("ERROR - No se Modifico Cliente");
                    }
                }
            }
        }                             ////**** BOTON MODIFICAR
        #endregion




    }
}

