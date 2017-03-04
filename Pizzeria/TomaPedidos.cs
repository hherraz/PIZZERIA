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
            int ancho=Screen.PrimaryScreen.Bounds.Width;
            int alto=Screen.PrimaryScreen.Bounds.Height;

            this.Location = new Point(10, 70);
            this.Size = new Size(ancho-20, alto - 220);
        }
    }
}
