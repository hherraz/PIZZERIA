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
            BackColor = Color.Gray;
            TransparencyKey = Color.Gray;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 0)
            {
                conexion conX = new conexion();
                conX.Abrir();
                conX.Cerrar();
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
    }
}
