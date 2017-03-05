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

        public int ancho = Screen.PrimaryScreen.Bounds.Width;
        public int alto = Screen.PrimaryScreen.Bounds.Height;

        private void TomaPedidos_Load(object sender, EventArgs e)
        {
            // tamaño de la pantalla para todos los menus
            this.Location = new Point(0, 25);
            this.Size = new Size(ancho, alto - 25);
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CONFIRMAR LA FORMA DE PAGO EN OTRO FORMULARIO");
            MessageBox.Show("DESEA CERRAR LA MESA?");
        }

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

            FooterTitle.Text = "TOMA DE PEDIDOS / CONSUMO EN EL LOCAL";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

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

            FooterTitle.Text = "TOMA DE PEDIDOS / RETIRO EN EL LOCAL";
        }

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

            FooterTitle.Text = "TOMA DE PEDIDOS / PEDIDO TELEFONICO";
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            PanelConsumoLocal.Visible = false;
            PanelRetiro.Visible = false;
            PanelDelivery.Visible = false;

            btnConsumoLocal.BackColor = Color.Silver;
            btnRetiroLocal.BackColor = Color.Silver;
            btnDelivery.BackColor = Color.Silver;

            FooterTitle.Text = "TOMA DE PEDIDOS";

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
