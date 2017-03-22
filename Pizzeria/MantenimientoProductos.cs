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
    public partial class MantenimientoProductos : Form
    {
        public MantenimientoProductos()
        {
            InitializeComponent();
        }

        private void btnIngredientes_Click(object sender, EventArgs e)
        {
            Agregar_Ingredientes ing = new Agregar_Ingredientes();
            ing.ShowDialog(this);
        }

        private void MantenimientoProductos_Load(object sender, EventArgs e)
        {
            CentrarPantalla();
        }

        private void CentrarPantalla()
        {
            this.Size = new Size(407, 465);
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }                                                               ////**** CENTRAR PANTALLA

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Agregar_Productos prod = new Agregar_Productos();
            prod.ShowDialog(this);
        }
    }
}
