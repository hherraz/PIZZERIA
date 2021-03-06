﻿using MySql.Data.MySqlClient;
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
    public partial class Caja : Form
    {
        public Caja()
        {
            InitializeComponent();
        }
        Conexion conX = new Conexion();

        private void Caja_Load(object sender, EventArgs e)
        {
            CentrarPantalla();
            FormatoGrid();
            CargaGrid();
        }

        private void CentrarPantalla()
        {
            this.Size = new Size(967, 526);
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        public void FormatoGrid()
        {
            dataGrid1.AllowDrop = false;
            dataGrid1.AllowSorting = false;
            dataGrid1.PreferredColumnWidth = 130;
        }

        public void CargaGrid()
        {
            Fusion(DTPedidos(), DTDetallePedidos());
        }
        
        public DataTable DTPedidos()
        {
            conX.Abrir();
            DataTable dt = new DataTable("Pedidos");
            dt.Columns.Add("Fecha_Pedido");
            dt.Columns.Add("N_Pedido");
            dt.Columns.Add("Tipo_Pedido");
            dt.Columns.Add("FORMAPAGO_CAJA");
            dt.Columns.Add("TotalPagado");
            dt.Columns.Add("Pagado");
            dt.Columns.Add("Contabilizado");
            try
            {
                MySqlDataAdapter adapt= new MySqlDataAdapter("SELECT Fecha_Pedido, N_Pedido, Tipo_Pedido, FORMAPAGO_CAJA, TotalPagado, PAGADO, Contabilizado FROM pedidos WHERE(Contabilizado = 0) ORDER BY Fecha_Pedido, N_Pedido",conX.cn);
                adapt.Fill(dt);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
            return dt;
        }

        public DataTable DTDetallePedidos()
        {
            conX.Abrir();
            DataTable dt = new DataTable("Detalle");
            dt.Columns.Add("N_Pedido");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Item");
            dt.Columns.Add("Unitario");
            dt.Columns.Add("Subtotal");
            try
            {
                MySqlDataAdapter adapt = new MySqlDataAdapter("SELECT N_Pedido, Cantidad, Item, Unitario, Subtotal FROM prod_pedidos ORDER BY Item;", conX.cn);
                adapt.Fill(dt);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
            return dt;
        }

        public void Fusion(DataTable DtPedidos, DataTable DtDetalle)
        {
            DataSet Fus = new DataSet();
            Fus.Tables.Add(DtPedidos);
            Fus.Tables.Add(DtDetalle);

            DataRelation rel = new DataRelation("Detalle del Pedido", Fus.Tables[0].Columns[1], Fus.Tables[1].Columns[0], true);
            
            try
            {
                Fus.Relations.Add(rel);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dataGrid1.DataSource = Fus.Tables[0];
            
            //calcular la suma total
            int suma = 0;
            try
            {
                foreach (DataRow dr in DtPedidos.Rows)
                {
                    suma += Convert.ToInt32(dr["TotalPagado"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            txtTotal.Text = suma.ToString("#,##0");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {

        }

        private void BtnMail_Click(object sender, EventArgs e)
        {

        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
