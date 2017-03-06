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

        public int ancho = Screen.PrimaryScreen.Bounds.Width;
        public int alto = Screen.PrimaryScreen.Bounds.Height;

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

            /// CENTRAR DE RIGOR
            this.Size = new Size(1008, 567);
            this.Location = new Point((ancho - this.Width) / 2, (alto - this.Height) / 2);

            ////**** DEFINIENDO PARAMETROS PARA EL DATAGRID
            int _imageSize = 120;                //TAMANO DE LOS ICONOS
            dataGridView1.Rows.Clear();         //LIMPIAR FILAS
            dataGridView1.Columns.Clear();      //LIMPIAR COLUMNAS
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;

            // OBTENER EL TOTAL DE REGISTROS A MOSTRAR
            cn.Open();
            MySqlCommand contar = new MySqlCommand("select count(*) from pizzacasa;", cn);
            int cantidadfilas = Convert.ToInt32(contar.ExecuteScalar());
            cn.Close();

            //CALCULO DEL TOTAL DE COLUMNAS CON MARGENES
            int numColumnsForWidth = (dataGridView1.Width - 10) / (_imageSize + 20);

            //CALCULO DEL TOTAL DE FILAS
            int numRows = cantidadfilas / numColumnsForWidth;

            // CALCULO PARA DEJAR EL NUMERO DE FILAS EN 1, SI ES QUE SON MENOS REGISTROS QUE COLUMNAS Y NO TIENDA A CERO
            if (cantidadfilas % numColumnsForWidth > 0)
            {
                numRows += 1;
            }

            // CORRECCION EN CANTIDAD DE COLUMNAS, SI ES QUE HAY MENOS REGISTROS QUE COLUMNAS
            if (cantidadfilas < numColumnsForWidth)
            {
                numColumnsForWidth = cantidadfilas;
            }

            // CALCULO DE LA CANTIDAD TOTAL DE CUADROS A GENERAR / FILAS POR COLUMNAS
            int numGeneratedCells = numRows * numColumnsForWidth;

            //*** CREAR COLUMNAS Y SETEO DE ANCHO DE CADA UNA
            for (int index = 0; index < numColumnsForWidth; index++)
            {
                DataGridViewImageColumn dataGridViewColumn = new DataGridViewImageColumn();
                dataGridView1.Columns.Add(dataGridViewColumn);
                dataGridView1.Columns[index].Width = _imageSize + 20;
            }

            //*** CREAR FILAS Y SETEO DEL ALTO DE CADA UNA
            for (int index = 0; index < numRows; index++) 
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Height = _imageSize + 20;
            }

            // VARIABLES PARA CORRER DENTRO DE LAS FILAS Y COLUMNAS UNA VEZ DENTRO DEL WHILE
            int columnIndex = 0;
            int rowIndex = 0;

            // CONECTANDO DATOS DESDE MYSQL
            MySqlCommand cm = new MySqlCommand("select * from pizzacasa;",cn);
            try
            {
                conectar();
                MySqlDataReader dr = cm.ExecuteReader();

                //LISTOS PARA POBLAR EL IMAGELIST Y EL LISTVIEW
                while (dr.Read())
                {
                    
                    // EMPAQUETAMOS IMAGEN YA CON EL TAMANO QUE QUEREMO 80X80 Y LA AGREGAMOS A LA FILA DEL DATAGRID
                    Image image = resizeImage(Image.FromFile(dr["RutaFoto"].ToString()), new Size(80,80));
                    dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = image;
                    dataGridView1.Rows[rowIndex].Cells[columnIndex].ToolTipText = dr["Item"].ToString();    // TOOLTIP GUARDA EL NOMBRE DEL ITEM
                    dataGridView1.Rows[rowIndex].Cells[columnIndex].Tag = dr["codProduct"].ToString();      // TAG GUARDA EL CODIGO DEL PRODUCTO
                    dataGridView1.CellBorderStyle= DataGridViewCellBorderStyle.None;

                    // INDICAMOS SI SEGUIMOS AGREGANDO COLUMNAS O SALTAMOS A OTRA FILA
                    if (columnIndex == numColumnsForWidth - 1)
                    {
                        rowIndex++;
                        columnIndex = 0;
                    }
                    else
                    {
                        columnIndex++;
                    }

                    // BORRAR FILAS DE DATOS NO USADOS
                    if (numGeneratedCells > cantidadfilas)
                    {
                        for (int index = 0; index < numGeneratedCells - cantidadfilas; index++)
                        {
                            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
                            dataGridViewCellStyle.NullValue = null;
                            dataGridViewCellStyle.Tag = "BLANK";
                            dataGridView1.Rows[rowIndex].Cells[columnIndex + index].Style = dataGridViewCellStyle;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK);
                Application.ExitThread();
            }
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            // LO DICE POR SI SOLO... ES PARA CAMBIAR EL TAMANO DE LA IMAGEN
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // MOSTRAR LOS DATOS DE LA CELDA PINCHADA / GUARDADO COMO TAG
            MessageBox.Show(dataGridView1[e.ColumnIndex, e.RowIndex].Tag.ToString());
            pizza = dataGridView1[e.ColumnIndex, e.RowIndex].Tag.ToString();

            // MOSTRAR LOS DATOS DE LA CELDA PINCHADA / GUARDADO COMO TOOLTIP
            MessageBox.Show(dataGridView1[e.ColumnIndex, e.RowIndex].ToolTipText.ToString());
            pizza1 = dataGridView1[e.ColumnIndex, e.RowIndex].ToolTipText.ToString();

            label7.Text = pizza + " / " + pizza1 + " / " + tamano;
        }

        private void ListaTamano_DoubleClick(object sender, EventArgs e)
        {
            if (ListaTamano.SelectedIndices[0].ToString() == "0")
            {
                tamano = "Individual";
            }
            if (ListaTamano.SelectedIndices[0].ToString() == "1")
            {
                tamano = "Mediana";
            }
            if (ListaTamano.SelectedIndices[0].ToString() == "2")
            {
                tamano = "Familiar";
            }
            if (ListaTamano.SelectedIndices[0].ToString() == "3")
            {
                tamano = "XL";
            }

            label7.Text = pizza + " / " + pizza1 + " / " + tamano;
        }

    }
}
