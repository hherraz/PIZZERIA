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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("INICIO DEL TIMER");
            timer1.Enabled = true;
            //BackColor = Color.Black;
            //TransparencyKey = Color.Black;
        }

        public Boolean Verifica(string url)
        {
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry(url);
                return true;

            }
            catch (Exception es)
            {
                Console.WriteLine("NO URL: " + es.Message);
                return false;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 0)
            {
                status.Text = "Verificando Conexión a Internet...";
            }

            if (progressBar1.Value == 20)
            {
                if (Verifica("www.google.cl") == true)
                {
                    status.Text = "Conexión Exitosa a Internet.";
                }
                else
                {
                    status.Text = "Equipo no conectado Internet.";
                    MessageBox.Show("ERROR - Equipo no conectado a Internet");
                    Dispose();
                }
            }

            if (progressBar1.Value == 40)
            {
                Conexion conX = new Conexion();
                status.Text = "Abriendo Servidor de Base de Datos...";
                conX.Abrir();
                conX.Cerrar();
            }

            if (progressBar1.Value == 60)
            {
                status.Text = "Base de Datos Abierta de Forma Exitosa.";
            }

            if (progressBar1.Value == 80)
            {
                status.Text = "Verificando Licencia de Producto...";
            }

            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 20;
            }
            else
            {
                Console.WriteLine("100% DE CARGA DE LA BARRA DE PROGRESO");
                timer1.Stop();
                timer1.Enabled = false;
                this.Close();
                this.Dispose();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.ShowDialog();
        }
    }
}
