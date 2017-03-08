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

        private void FormatearGridConsumo()
        {
            GridConsumo.AllowUserToAddRows = false;
            GridConsumo.ReadOnly = true;

            GridConsumo.ColumnHeadersVisible = true;
            GridConsumo.MultiSelect = false;
            GridConsumo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridConsumo.ColumnCount = 4;

            GridConsumo.Columns[0].Name = "Cantidad";
            GridConsumo.Columns[1].Name = "Item";
            GridConsumo.Columns[2].Name = "Unitario";
            GridConsumo.Columns[3].Name = "SubTotal";

            GridConsumo.Columns[0].Width = 100;
            GridConsumo.Columns[1].Width = 300;
            GridConsumo.Columns[2].Width = 100;
            GridConsumo.Columns[3].Width = 100;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            GridConsumo.Columns.Add(btn);
            btn.Text = "Borrar";
            btn.ToolTipText = "Borrar";
            btn.Name = "Borrar";
            btn.UseColumnTextForButtonValue = true;
            btn.Width = 100;
            btn.HeaderText = "";

        }                          ////**** FORMATEAR GRIDCONSUMO
        private void CentrarPantalla()
        {
            // tamaño de la pantalla para todos los menus
            this.Location = new Point(0, 25);
            this.Size = new Size(ancho, alto - 25);
        }                               ////**** CENTRAR PANTALLA
        private void TomaPedidos_Load(object sender, EventArgs e)
        {
            CentrarPantalla();
            FormatearGridConsumo();
        }    ////**** LANZADOR DEL FORMULARIO

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

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AddPizzaMenu add = new AddPizzaMenu();
            add.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            AddPizzaMenu PM = new AddPizzaMenu();
            PM.ShowDialog();
            PM.Dispose();
        }

        private void GridConsumo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //SI EL CLICK ES EN UNA FILA NUEVA, O INFERIOR A LA FILA 0
            if (e.RowIndex == GridConsumo.NewRowIndex || e.RowIndex < 0)
            {
                return;
            }
            if(e.ColumnIndex == GridConsumo.Columns["Borrar"].Index)
            {
                GridConsumo.Rows.RemoveAt(e.RowIndex);
            }

        }      ////**** BORRAR FILA DEL GRIDCONSUMO

        public void ActualizarSuma()
        {
            int sumatoria = 0;

            foreach (DataGridViewRow row in GridConsumo.Rows)
            {
                sumatoria += Convert.ToInt32(row.Cells["SubTotal"].Value);
            }

            Total.Text = Convert.ToString(sumatoria);
        }

        private void TomaPedidos_Activated(object sender, EventArgs e)
        {
            ActualizarSuma();
        }

        private void GridConsumo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ActualizarSuma();
        }
    }
}
