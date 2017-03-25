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
    public partial class Pagar : Form
    {
        public Pagar()
        {
            InitializeComponent();
        }

        int n_pedido = DatosCompartidos.Instance().PagarPedido;
        string forma=null;

        Conexion conX = new Conexion();
        Garzones garX = new Garzones();
        Mesas mesX = new Mesas();

        private void Pagar_Load(object sender, EventArgs e)
        {
            CentrarPantalla();
            llenarForm();

            if(DatosCompartidos.Instance().PagoInmediato == 1)
            {
                btnSalir.Visible = false;
            }

        }

        private void CentrarPantalla()
        {
            this.Size = new Size(830, 470);
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }
        private void FormatoGrid()
        {
            dgConsumo.Rows.Clear();         //LIMPIAR FILAS
            dgConsumo.Columns.Clear();      //LIMPIAR COLUMNAS
            dgConsumo.AllowUserToAddRows = false;
            dgConsumo.ColumnHeadersVisible = true;
            dgConsumo.RowHeadersVisible = false;

            dgConsumo.Columns.Add("Cantidad", "Cantidad");
            dgConsumo.Columns.Add("Item", "Item");
            dgConsumo.Columns.Add("SubTotal", "SubTotal");

            dgConsumo.Columns[0].Name = "Cantidad";
            dgConsumo.Columns[1].Name = "Item";
            dgConsumo.Columns[2].Name = "SubTotal";

            dgConsumo.Columns[0].Width = 50;
            dgConsumo.Columns[1].Width = 200;
            dgConsumo.Columns[2].Width = 80;
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            btnEfectivo.BackColor = Color.Red;
            btnTarjeta.BackColor = Color.Aqua;
            btnOtro.BackColor = Color.Aqua;
            forma = "EFECTIVO";
        }
        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            btnEfectivo.BackColor = Color.Aqua;
            btnTarjeta.BackColor = Color.Red;
            btnOtro.BackColor = Color.Aqua;
            forma = "DEBITO";
        }
        private void btnOtro_Click(object sender, EventArgs e)
        {
            btnEfectivo.BackColor = Color.Aqua;
            btnTarjeta.BackColor = Color.Aqua;
            btnOtro.BackColor = Color.Red;
            forma = "OTRO";
        }

        public void llenarForm()
        {
            CentrarPantalla();
            FormatoGrid();

            lblPedido.Text = Convert.ToString(n_pedido);
            lblGarzon.Text = GarzonPedido(garX.GarzonPedido(n_pedido));
            lblMesa.Text = MesaPedido(mesX.MesaPedido(n_pedido));

            poblargrid();

            txtTotal.Text = sumartodo();
            txtTotalPagar.Text = sumartodo();
        }

        //Metodo
        public void poblargrid()
        {
            DataTable dt = new DataTable();
            conX.Abrir();
            try
            {
                string sql = "select Cantidad, Item, Subtotal from prod_pedidos where N_Pedido=" + n_pedido + ";";
                MySqlCommand cm = new MySqlCommand(sql, conX.cn);
                MySqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dgConsumo.Rows.Add(Convert.ToInt32(dr["Cantidad"].ToString()), dr["Item"].ToString(), Convert.ToInt32(dr["Subtotal"].ToString()));
                }
                dgConsumo.Columns[0].Width = 70;
                dgConsumo.Columns[1].Width = 270;
                dgConsumo.Columns[2].Width = 80;

                dgConsumo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgConsumo.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                sumartodo();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
        }

        //Funciones
        public string GarzonPedido(int idGarzon)
        {
            string garzon = null;
            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("select aliasGarzon from garzones where idGarzon=@idgarzon;", conX.cn);
                cmd.Parameters.AddWithValue("@idgarzon", idGarzon);
                garzon = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
            return garzon;
        }
        public string MesaPedido(int IdMesa)
        {
            string Mesa = null;
            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("select Nombre_mesa from mesas where idMesa=@idMesa;", conX.cn);
                cmd.Parameters.AddWithValue("@idMesa", IdMesa);
                Mesa = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
            return Mesa;
        }
        public string sumartodo()
        {
            int sumatoria = 0;

            foreach (DataGridViewRow row in dgConsumo.Rows)
            {
                sumatoria += Convert.ToInt32(row.Cells["SubTotal"].Value);
            }

            return Convert.ToString(sumatoria);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (forma != null)
            {
                DatosCompartidos.Instance().Pagado = 1;
                RegistrarPago();

                MessageBox.Show("NUMERO DE PEDIDO: " + n_pedido + " PAGADO OK! \nGRACIAS POR SU COMPRA.");

                Close();
            }
            else
            {
                MessageBox.Show("SELECCIONE UNA FORMA DE PAGO E INTENTE DE NUEVO");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void RegistrarPago()
        {
            //marcar pedidos como pagado e insertar el valor pagado
            conX.Abrir();
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE pedidos SET PAGADO=@pagado, TotalPagado=@total, FORMAPAGO_CAJA=@forma WHERE N_Pedido = @n_pedido;", conX.cn);
                cmd.Parameters.AddWithValue("@pagado", 1);
                cmd.Parameters.AddWithValue("@total", Convert.ToInt32(txtTotal.Text));
                cmd.Parameters.AddWithValue("@forma", forma);
                cmd.Parameters.AddWithValue("@n_pedido", n_pedido);
                cmd.ExecuteScalar();
                Console.WriteLine("****************************************************************** NUMERO DE PEDIDO: " + n_pedido  + " PAGADO **********");
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
        }

        private void txtIngreso_Leave(object sender, EventArgs e)
        {
            txtVuelto.Text = Convert.ToString(Convert.ToInt32(txtIngreso.Text) - Convert.ToInt32(txtTotal.Text));
        }

        private void txtIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtVuelto.Text = Convert.ToString(Convert.ToInt32(txtIngreso.Text) - Convert.ToInt32(txtTotal.Text));
                btnPagar.Focus();
            }
        }
    }
}
