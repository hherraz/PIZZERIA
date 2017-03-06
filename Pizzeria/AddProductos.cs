using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pizzeria
{
    public partial class AddProductos : Form
    {
        public AddProductos()
        {
            InitializeComponent();
        }

        string pizza, pizza1, tamano;

        public MySqlConnection cn = new MySqlConnection("server=rentaboxer.cl;database=pizzeria;uid=pizzeria;pwd=12345;");

        public void conectar() //SOLO PARA PROBAR LOS DATOS... DESPUES HACER CLASE CONECCION
        {
            try
            {
                cn.Open();
                MessageBox.Show("Conexión Existosa! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede conectar ! " + ex);
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK);
                Application.ExitThread();
            }
        }

        private void AddProductos_Load(object sender, EventArgs e)
        {

            ListaPizzasDeLaCasa.Items.Clear();

            // DEFINIENDO LOS PARAMETROS PARA EL IMAGELIST
            ImageList imageList1 = new ImageList();
            imageList1.ImageSize = new Size(100, 100);
            ListaPizzasDeLaCasa.SmallImageList = imageList1;
            ListaPizzasDeLaCasa.LargeImageList = imageList1;

            // TRAYENDO DATOS DE MYSQL
            MySqlCommand cm = new MySqlCommand("select * from pizzacasa;",cn);
            try
            {
                conectar();
                MySqlDataReader dr = cm.ExecuteReader();

                //LISTOS PARA POBLAR EL IMAGELIST Y EL LISTVIEW
                int key = 0;
                while (dr.Read())
                {
                    imageList1.Images.Add(key.ToString(), Image.FromFile(dr["RutaFoto"].ToString())); //se agrega el KEY de la Foto y la Ruta
                    ListaPizzasDeLaCasa.Items.Add(dr["Item"].ToString(), key); // se agrega el NOMBRE del item, y se asocia al KEY de la foto
                    key++;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK);
                Application.ExitThread();
            }

        }

        private void ListaPizzasDeLaCasa_DoubleClick(object sender, EventArgs e)
        {
            pizza=ListaPizzasDeLaCasa.SelectedIndices[0].ToString();
            pizza1 = ListaPizzasDeLaCasa.SelectedItems[0].ToString();
            label7.Text = pizza + " " + pizza1 + " " + tamano;
        }

        private void ListaTamano_DoubleClick(object sender, EventArgs e)
        {
            tamano = ListaTamano.SelectedIndices[0].ToString();
            label7.Text = pizza + " " + pizza1 + " " + tamano;
        }

    }
}
