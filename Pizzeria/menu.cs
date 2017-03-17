using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Pizzeria
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        #region VARIABLES
        public int ancho = Screen.PrimaryScreen.Bounds.Width;
        public int alto = Screen.PrimaryScreen.Bounds.Height;
        #endregion

        #region INSTANCIAS
        conexion conX = new conexion();
        #endregion

        #region FORMATEO DEL FORMULARIO
        public void FormatoPantalla()
        {
            //a la izquierda
            label1.Location = new Point(10, panel1.Location.Y + 5);

            //al centro
            Int32 ancho = (this.Width - label2.Width) / 2;
            label2.Location = new Point(ancho, panel1.Location.Y + 5);

            //a la derecha
            Int32 derecha = (this.Width - label3.Width - 10);
            label3.Location = new Point(derecha, panel1.Location.Y + 5);

            //minimizar y cerrar a la derecha
            Int32 derecha1 = (this.Width - minimizar.Width - 10);
            minimizar.Location = new Point(derecha1, minimizar.Location.Y);
            //cerrar.Location = new Point(derecha1, minimizar.Location.Y);
            cerrar.Visible = false;

            //CENTRAL PANEL3
            Int32 anchopanel3 = (this.Width - panel3.Width) / 2;
            panel3.Location = new Point(anchopanel3, panel3.Location.Y);

            //datos de la barra superior
            label1.Text = DateTime.Now.ToShortDateString();
            label3.Text = DateTime.Now.ToLongTimeString();
            timer1.Enabled = true;
        }                                    ////*** FORMATEA LA PANTALLA
        #endregion

        private void menu_Load(object sender, EventArgs e)
        {
            FormatoPantalla();
            panel3.Visible = true;
            label2.Text = DatosCompartidos.Instance().Usuario;

        }               ////*** LANZADOR DEL FORMULARIO

        #region EVENTOS
        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
        }             ////*** ACCION DEL TIMER
        #endregion

        #region BOTONES DEL FORMULARIO
        private void cerrar_Click(object sender, EventArgs e)
        {
            int cerr = Program.cerrar();

            if (cerr == 1)
            {
                Environment.Exit(0);
            }
        }            ////*** BOTON CERRAR
        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }         ////*** BOTON MINIMIZAR
        private void btn_salir_Click(object sender, EventArgs e)
        {
            int cerr = Program.cerrar();

            if (cerr == 1)
            {
                Environment.Exit(0);
            }
        }         ////*** BOTON SALIR
        private void btn_tomapedido_Click(object sender, EventArgs e)
        {
            PanelTomaPedidos.Visible = true;
            PanelTomaPedidos.Location = new Point((ancho - PanelTomaPedidos.Width) / 2, (panel2.Location.Y - PanelTomaPedidos.Height+5));
        }    ////*** BOTON TOMA DE PEDIDO
        private void button1_Click(object sender, EventArgs e)
        {
            PanelTomaPedidos.Visible = false;
        }           ////*** HACE INVISIBLE LOS BOTONES DE ACCION
        #endregion

        #region BOTONES DE ACCION
        private void btnConsumoLocal_Click(object sender, EventArgs e)
        {
            ConsumoLocal consumo = new ConsumoLocal();
            consumo.ShowDialog(this);
        }   ////*** BOTON ABRIR CONSUMO EN EL LOCAL
        private void btnRetiroLocal_Click(object sender, EventArgs e)
        {
            RetiroLocal retiro = new RetiroLocal();
            retiro.ShowDialog(this);
        }    ////*** BOTON ABRIR RETIRO EN EL LOCAL
        #endregion

        #region BOTONES QUE SE MUEVEN
        private void btn_tomapedido_MouseHover(object sender, EventArgs e)
        {
            btn_tomapedido.Size = new System.Drawing.Size(91, 89);
        }

        private void btn_tomapedido_MouseLeave(object sender, EventArgs e)
        {
            btn_tomapedido.Size = new System.Drawing.Size(81, 79);
        }

        private void btn_delivery_MouseHover(object sender, EventArgs e)
        {
            btn_delivery.Size = new System.Drawing.Size(91, 89);
        }

        private void btn_delivery_MouseLeave(object sender, EventArgs e)
        {
            btn_delivery.Size = new System.Drawing.Size(81, 79);
        }

        private void btn_productos_MouseHover(object sender, EventArgs e)
        {
            btn_productos.Size = new System.Drawing.Size(91, 89);
        }

        private void btn_productos_MouseLeave(object sender, EventArgs e)
        {
            btn_productos.Size = new System.Drawing.Size(81, 79);
        }

        private void btn_cierrecaja_MouseHover(object sender, EventArgs e)
        {
            btn_cierrecaja.Size = new System.Drawing.Size(91, 89);
        }

        private void btn_cierrecaja_MouseLeave(object sender, EventArgs e)
        {
            btn_cierrecaja.Size = new System.Drawing.Size(81, 79);
        }

        private void btn_administrar_MouseHover(object sender, EventArgs e)
        {
            btn_administrar.Size = new System.Drawing.Size(91, 89);
        }

        private void btn_administrar_MouseLeave(object sender, EventArgs e)
        {
            btn_administrar.Size = new System.Drawing.Size(81, 79);
        }

        private void btn_salir_MouseHover(object sender, EventArgs e)
        {
            btn_salir.Size = new System.Drawing.Size(91, 89);
        }

        private void btn_salir_MouseLeave(object sender, EventArgs e)
        {
            btn_salir.Size = new System.Drawing.Size(81, 79);
        }

        #endregion


    }
}
