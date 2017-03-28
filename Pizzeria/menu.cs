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
using System.IO;

namespace Pizzeria
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        #region VARIABLES
        public int ancho = Screen.PrimaryScreen.Bounds.Width;
        public int alto = Screen.PrimaryScreen.Bounds.Height;
        int sorpresa = 0;
        #endregion

        #region INSTANCIAS
        Conexion conX = new Conexion();
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
            PanelTomaPedidos.Location = new Point((this.Width - PanelTomaPedidos.Width) / 2, PanelTomaPedidos.Location.Y);

            //datos de la barra superior
            label1.Text = DateTime.Now.ToShortDateString();
            label3.Text = DateTime.Now.ToLongTimeString();
            timer1.Enabled = true;
        }                                    ////*** FORMATEA LA PANTALLA
        #endregion

        private void Menu_Load(object sender, EventArgs e)
        {
            FormatoPantalla();
            panel3.Visible = true;
            label2.Text = DatosCompartidos.Instance().Usuario;

            //CambiaImg();

        }               ////*** LANZADOR DEL FORMULARIO

        #region EVENTOS
        private void Timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
        }             ////*** ACCION DEL TIMER
        #endregion

        #region BOTONES DEL FORMULARIO
        private void Cerrar_Click(object sender, EventArgs e)
        {
            int cerr = Program.cerrar();

            if (cerr == 1)
            {
                Environment.Exit(0);
            }
        }            ////*** BOTON CERRAR
        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }         ////*** BOTON MINIMIZAR
        private void Btn_salir_Click(object sender, EventArgs e)
        {
            int cerr = Program.cerrar();

            if (cerr == 1)
            {
                Environment.Exit(0);
            }
        }         ////*** BOTON SALIR
        private void Btn_tomapedido_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;

            PanelTomaPedidos.Visible = true;
            PanelTomaPedidos.Location = new Point((this.Width - PanelTomaPedidos.Width) / 2, panel2.Location.Y);
            //(panel2.Location.Y - PanelTomaPedidos.Height+5));
            //PanelTomaPedidos.Location = new Point((this.Width - PanelTomaPedidos.Width) / 2, panel3.Location.Y);

        }    ////*** BOTON TOMA DE PEDIDO
        private void Button1_Click(object sender, EventArgs e)
        {
            PanelTomaPedidos.Visible = false;
            panel3.Visible = true;
        }           ////*** HACE INVISIBLE LOS BOTONES DE ACCION
        #endregion

        #region BOTONES DE ACCION
        private void BtnConsumoLocal_Click(object sender, EventArgs e)
        {
            ConsumoLocal consumo = new ConsumoLocal();
            consumo.ShowDialog(this);
        }   ////*** BOTON ABRIR CONSUMO EN EL LOCAL
        private void BtnRetiroLocal_Click(object sender, EventArgs e)
        {
            RetiroLocal retiro = new RetiroLocal();
            retiro.ShowDialog(this);
        }    ////*** BOTON ABRIR RETIRO EN EL LOCAL
        private void BtnDelivery_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery();
            delivery.ShowDialog(this);
        }       ////*** BOTON ABRIR DELIVERY
        #endregion

        #region BOTONES QUE SE MUEVEN
        private void Btn_tomapedido_MouseHover(object sender, EventArgs e)
        {
            btn_tomapedido.Size = new System.Drawing.Size(91, 89);
        }

        private void Btn_tomapedido_MouseLeave(object sender, EventArgs e)
        {
            btn_tomapedido.Size = new System.Drawing.Size(81, 79);
        }

        private void Btn_delivery_MouseHover(object sender, EventArgs e)
        {
            btn_delivery.Size = new System.Drawing.Size(91, 89);
        }

        private void Btn_delivery_MouseLeave(object sender, EventArgs e)
        {
            btn_delivery.Size = new System.Drawing.Size(81, 79);
        }

        private void Btn_productos_MouseHover(object sender, EventArgs e)
        {
            btn_productos.Size = new System.Drawing.Size(91, 89);
        }

        private void Btn_productos_MouseLeave(object sender, EventArgs e)
        {
            btn_productos.Size = new System.Drawing.Size(81, 79);
        }

        private void Btn_cierrecaja_MouseHover(object sender, EventArgs e)
        {
            btn_cierrecaja.Size = new System.Drawing.Size(91, 89);
        }

        private void Btn_cierrecaja_MouseLeave(object sender, EventArgs e)
        {
            btn_cierrecaja.Size = new System.Drawing.Size(81, 79);
        }

        private void Btn_administrar_MouseHover(object sender, EventArgs e)
        {
            btn_administrar.Size = new System.Drawing.Size(91, 89);
        }

        private void Btn_administrar_MouseLeave(object sender, EventArgs e)
        {
            btn_administrar.Size = new System.Drawing.Size(81, 79);
        }

        private void Btn_salir_MouseHover(object sender, EventArgs e)
        {
            btn_salir.Size = new System.Drawing.Size(91, 89);
        }

        private void Btn_salir_MouseLeave(object sender, EventArgs e)
        {
            btn_salir.Size = new System.Drawing.Size(81, 79);
        }



        #endregion

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            sorpresa++;
            if (sorpresa == 10)
            {
                About about = new About();
                about.ShowDialog(this);
                sorpresa = 0;
            }
        }

        private void Btn_delivery_Click(object sender, EventArgs e)
        {
            DetalleRetiro det = new DetalleRetiro();
            det.ShowDialog(this);
        }

        private void Btn_productos_Click(object sender, EventArgs e)
        {
            MantenimientoProductos man = new MantenimientoProductos();
            man.ShowDialog(this);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Size = new System.Drawing.Size(91, 89);

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Size = new System.Drawing.Size(81, 79);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Size = new System.Drawing.Size(91, 89);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Size = new System.Drawing.Size(81, 79);
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Size = new System.Drawing.Size(91, 89);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Size = new System.Drawing.Size(81, 79);
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Size = new System.Drawing.Size(91, 89);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Size = new System.Drawing.Size(81, 79);
        }

        private void btn_cierrecaja_Click(object sender, EventArgs e)
        {
            Caja cj = new Caja();
            cj.ShowDialog(this);
        }

        //public Image TextoImagen(Image img, string txt)
        //{
        //    Image imgX;
        //    Font fuente = new Font("Verdana", 12);                                                          //PREDETERMINO LA FUENTE Y EL TAMANO DEL TEXTO A GENERAR

        //    Bitmap output = new Bitmap(img.Width, img.Height + 25, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //    using (Graphics graphics = Graphics.FromImage(output))
        //    {
        //        graphics.DrawImage(img, new Rectangle(new Point(), img.Size),
        //            new Rectangle(new Point(), img.Size), GraphicsUnit.Pixel);
        //    }

        //    Graphics g = Graphics.FromImage(output);                                                           //LA PASAMOS A OBJETO GRAFICO
        //    g.FillRectangle(Brushes.Black, new Rectangle(0, img.Height, img.Width, 25));                            //DIBUJO EL RECTANGULO NEGRO CON GDI+
        //    SizeF txtsize = TextRenderer.MeasureText(txt, fuente);                                          //CALCULO EL TAMANO GRAFICO DEL STRING PARA PODER CENTRAR EL TEXTO
        //    g.DrawString(txt, fuente, Brushes.White, new PointF((img.Width - txtsize.Width) / 2, img.Height));       //ESCRIBO SOBRE EL RECTANGULO CON GDI+
        //    imgX = output;
        //    g.Dispose();
        //    return imgX;
        //}

        //public void CambiaImg()
        //{
        //    pictureBox2.Image = TextoImagen(pictureBox2.Image, "CONSUMO");
        //}
    }
}
