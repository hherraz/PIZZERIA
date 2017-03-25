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
    public partial class DetalleRetiro : Form
    {
        public DetalleRetiro()
        {
            InitializeComponent();
        }

        Conexion conX = new Conexion();
        int sw = 0; //0=retiro 1=delivery

        private void DetalleRetiro_Load(object sender, EventArgs e)
        {
            CentrarPantalla();

            btnRetiro.BackColor = Color.Red;
            btnDelivery.BackColor = Color.Aqua;

            FormateoRetiro();
            PoblarRetiro();
        }

        private void CentrarPantalla()
        {
            this.Size = new Size(777, 493);
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        public void FormateoRetiro()
        {
            GridPendientes.Columns.Clear();
            GridPendientes.Rows.Clear();

            GridPendientes.ReadOnly = true;
            GridPendientes.AutoGenerateColumns = false;

            GridPendientes.ColumnHeadersVisible = true;
            GridPendientes.RowHeadersVisible = false;

            GridPendientes.MultiSelect = false;
            GridPendientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridPendientes.ColumnCount = 5;

            DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
            boton.HeaderText = "Ver Detalle";
            boton.Name = "Ver Detalle";
            boton.Text = "Ver Detalle";
            boton.Tag = "Ver Detalle";
            boton.UseColumnTextForButtonValue = true;

            GridPendientes.Columns[0].Name = "Fecha";
            GridPendientes.Columns[1].Name = "Numero Pedido";
            GridPendientes.Columns[2].Name = "Cliente";
            GridPendientes.Columns[3].Name = "Telefono";
            GridPendientes.Columns[4].Name = "Total";
            GridPendientes.Columns.Add(boton);

            GridPendientes.Columns[0].Width = 145;
            GridPendientes.Columns[1].Width = 80;
            GridPendientes.Columns[2].Width = 230;
            GridPendientes.Columns[3].Width = 100;
            GridPendientes.Columns[4].Width = 60;

            GridPendientes.AllowUserToAddRows = false;

            GridPendientes.DefaultCellStyle.Font = new Font("Arial", 9);

        }
        public void PoblarRetiro()
        {
            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT pedidos.Fecha_Pedido, pedidos.N_Pedido, pedidos.NombreRetiro, pedidos.TelefonoRetiro, SUM(prod_pedidos.Subtotal) AS Total FROM pedidos, prod_pedidos WHERE pedidos.N_Pedido = prod_pedidos.N_Pedido AND (PAGADO=@pagado) AND (Tipo_Pedido=@Retiro);", conX.cn);
                cmd.Parameters.AddWithValue("@pagado",0);
                cmd.Parameters.AddWithValue("@Retiro", "Retiro");
                MySqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    if (da["Fecha_Pedido"].ToString().Length != 0)
                    {
                        GridPendientes.Rows.Add(da["Fecha_Pedido"].ToString(), da["N_Pedido"].ToString(), da["NombreRetiro"].ToString(), da["TelefonoRetiro"].ToString(), da["Total"].ToString());
                    }
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
        }

        public void FormateoDelivery()
        {
            GridPendientes.Columns.Clear();
            GridPendientes.Rows.Clear();

            GridPendientes.ReadOnly = true;
            GridPendientes.AutoGenerateColumns = false;

            GridPendientes.ColumnHeadersVisible = true;
            GridPendientes.RowHeadersVisible = false;

            GridPendientes.MultiSelect = false;
            GridPendientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridPendientes.ColumnCount = 5;

            DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
            boton.HeaderText = "Ver Detalle";
            boton.Name = "Ver Detalle";
            boton.Text = "Ver Detalle";
            boton.Tag = "Ver Detalle";
            boton.UseColumnTextForButtonValue = true;

            GridPendientes.Columns[0].Name = "Fecha";
            GridPendientes.Columns[1].Name = "Numero Pedido";
            GridPendientes.Columns[2].Name = "Cliente";
            GridPendientes.Columns[3].Name = "Telefono";
            GridPendientes.Columns[4].Name = "Total";
            GridPendientes.Columns.Add(boton);

            GridPendientes.Columns[0].Width = 145;
            GridPendientes.Columns[1].Width = 80;
            GridPendientes.Columns[2].Width = 230;
            GridPendientes.Columns[3].Width = 100;
            GridPendientes.Columns[4].Width = 60;

            GridPendientes.AllowUserToAddRows = false;

            GridPendientes.DefaultCellStyle.Font = new Font("Arial", 9);
        }
        public void PoblarDelivery()
        {
            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT pedidos.Fecha_Pedido, pedidos.N_Pedido, clientes_delivery.DL_Nombre, clientes_delivery.DL_Telefono, SUM(prod_pedidos.Subtotal) AS Total FROM pedidos, clientes_delivery, prod_pedidos WHERE pedidos.IdClienteDelivery = clientes_delivery.idCliente AND pedidos.N_Pedido = prod_pedidos.N_Pedido AND (pedidos.Tipo_Pedido = @Delivery) AND (pedidos.PAGADO = @pagado)", conX.cn);
                cmd.Parameters.AddWithValue("@pagado", 0);
                cmd.Parameters.AddWithValue("@Delivery", "Delivery");
                MySqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    if (da["Fecha_Pedido"].ToString().Length != 0)
                    {
                        GridPendientes.Rows.Add(da["Fecha_Pedido"].ToString(), da["N_Pedido"].ToString(), da["DL_Nombre"].ToString(), da["DL_Telefono"].ToString(), da["Total"].ToString());
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            sw = 0;

            btnRetiro.BackColor = Color.Red;
            btnDelivery.BackColor = Color.Aqua;

            FormateoRetiro();
            PoblarRetiro();

            txtNombre.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtReferencia.Clear();
        }
        private void btnDelivery_Click(object sender, EventArgs e)
        {
            sw = 1;

            btnRetiro.BackColor = Color.Aqua;
            btnDelivery.BackColor = Color.Red;

            FormateoDelivery();
            PoblarDelivery();

            txtNombre.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtReferencia.Clear();
        }

        private void GridPendientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int n_pedido = Convert.ToInt32(GridPendientes.CurrentRow.Cells[1].Value);
            lblPedido.Text = Convert.ToString(GridPendientes.CurrentRow.Cells[1].Value);

            if (sw == 0)
            {
                CargaDetalleRetiro(n_pedido);
            }
            if (sw == 1)
            {
                CargaDetalleDelivery(n_pedido);
            }
        }

        public void CargaDetalleRetiro(int n_pedido)
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtReferencia.Clear();

            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("select NombreRetiro, TelefonoRetiro from pedidos where N_Pedido=@numero;", conX.cn);
                cmd.Parameters.AddWithValue("@numero", n_pedido);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtNombre.Text = dr["NombreRetiro"].ToString();
                    txtTelefono.Text = dr["TelefonoRetiro"].ToString();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
        }
        public void CargaDetalleDelivery(int n_pedido)
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtReferencia.Clear();

            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT clientes_delivery.DL_Nombre, clientes_delivery.DL_Direccion, clientes_delivery.DL_Referencia, clientes_delivery.DL_Telefono FROM pedidos, clientes_delivery WHERE pedidos.IdClienteDelivery = clientes_delivery.idCliente AND(pedidos.N_Pedido = @numero);", conX.cn);
                cmd.Parameters.AddWithValue("@numero", n_pedido);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtNombre.Text = dr["DL_Nombre"].ToString();
                    txtTelefono.Text = dr["DL_Telefono"].ToString();
                    txtDireccion.Text = dr["DL_Direccion"].ToString();
                    txtReferencia.Text = dr["DL_Referencia"].ToString();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblPedido.Text.Length > 0)
            {
                DatosCompartidos.Instance().PagarPedido = Convert.ToInt32(lblPedido.Text);
                Pagar pag = new Pagar();
                pag.ShowDialog(this);

                if (DatosCompartidos.Instance().Pagado == 1)
                {
                    DatosCompartidos.Instance().PagarPedido = 0;
                    DatosCompartidos.Instance().Pagado = 0;
                }
                else
                {
                    MessageBox.Show("ALERTA - PEDIDO NO TERMINADO");
                }
                Close();
            }
            else
            {
                MessageBox.Show("Selecciones un Pedido de la Lista.\nY Vuelva a Intentarlo.");
            }
        }
    }
}
