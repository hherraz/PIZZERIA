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

        private void TomaPedidos_Load(object sender, EventArgs e)
        {
            // tamaño de la pantalla para todos los menus
            int ancho=Screen.PrimaryScreen.Bounds.Width;
            int alto=Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 25);
            this.Size = new Size(ancho, alto - 160);

            //boton cerrar al tope derecho
            Int32 derecha = (this.Width - btn_cerrar.Width - 3);
            btn_cerrar.Location = new Point(derecha, panel1.Location.Y);

            //TABS
            tabControl1.Size = new Size(ancho-20,this.Height-50);
            tabControl1.Location = new Point(10,35);


        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
