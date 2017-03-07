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

        conexion conX = new conexion();

        //// JUEGO DE VARIABLES DEL FORMULARIO
        string pizza;
        int ancho = Screen.PrimaryScreen.Bounds.Width;
        int alto = Screen.PrimaryScreen.Bounds.Height;
        int PorteImagenes;

        string MasaSeleccionada;
        string PorteSeleccionada;
        string PizzaSeleccionada;

        public void CentrarForm()                                                                       ////**** CENTRAR FORMULARIO
        {
            this.Size = new Size(1008, 567);
            this.Location = new Point((ancho - this.Width) / 2, (alto - this.Height) / 2);
        }
        public void FormatoGrid()                                                                       ////**** DEFINIENDO PARAMETROS PARA LOS DATAGRIDS
        {
            PorteImagenes = 120;                //TAMANO DE LOS ICONOS
            
            //PIZZA DE LA CASA
            dataGridView1.Rows.Clear();         //LIMPIAR FILAS
            dataGridView1.Columns.Clear();      //LIMPIAR COLUMNAS
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            
            //MEDIDA PIZZA
            dataGridView2.Rows.Clear();         //LIMPIAR FILAS
            dataGridView2.Columns.Clear();      //LIMPIAR COLUMNAS
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;

            //MASA PIZZA
            dataGridView3.Rows.Clear();         //LIMPIAR FILAS
            dataGridView3.Columns.Clear();      //LIMPIAR COLUMNAS
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.ColumnHeadersVisible = false;
            dataGridView3.RowHeadersVisible = false;
        }

        public void CargaPizzasCasa()                                                                   ////**** CARGA DATOS EN GRID PIZZAS DE LA CASA
        {
            #region CALCULO DE TOTAL DE REGISTROS / TOTALES DE COLUMNAS, FILAS, ETC

            // OBTENER EL TOTAL DE REGISTROS A MOSTRAR
            conX.Abrir();
            MySqlCommand Contar = new MySqlCommand("select count(*) from pizzacasa;", conX.cn);
            int TotalRegistros = Convert.ToInt32(Contar.ExecuteScalar());
            conX.Cerrar();

            //CALCULO DEL TOTAL DE COLUMNAS CON MARGENES
            int TotalColumnas = (dataGridView1.Width - 10) / (PorteImagenes + 20);

            //CALCULO DEL TOTAL DE FILAS
            int TotalFilas = TotalRegistros / TotalColumnas;

            // CALCULO PARA DEJAR EL NUMERO DE FILAS EN 1, SI ES QUE SON MENOS REGISTROS QUE COLUMNAS Y NO TIENDA A CERO
            if (TotalRegistros % TotalColumnas > 0)
            {
                TotalFilas += 1;
            }

            // CORRECCION EN CANTIDAD DE COLUMNAS, SI ES QUE HAY MENOS REGISTROS QUE COLUMNAS
            if (TotalRegistros < TotalColumnas)
            {
                TotalColumnas = TotalRegistros;
            }

            // CALCULO DE LA CANTIDAD TOTAL DE CUADROS A GENERAR / FILAS POR COLUMNAS
            int TotalCeldasGeneradas = TotalFilas * TotalColumnas;

            #endregion

            #region DIAGRAMA COLUMNAS Y FILAS EN EL DATAGRID

            // VARIABLES PARA CORRER DENTRO DE LAS FILAS Y COLUMNAS UNA VEZ DENTRO DEL WHILE
            int NumeroColumna = 0;
            int NumeroFila = 0;

            //*** CREAR COLUMNAS Y SETEO DE ANCHO DE CADA UNA
            for (int index = 0; index < TotalColumnas; index++)
            {
                DataGridViewImageColumn dataGridViewColumn = new DataGridViewImageColumn();
                dataGridView1.Columns.Add(dataGridViewColumn);
                dataGridView1.Columns[index].Width = PorteImagenes + 20;
            }

            //*** CREAR FILAS Y SETEO DEL ALTO DE CADA UNA
            for (int index = 0; index < TotalFilas; index++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Height = PorteImagenes + 20;
            }

            #endregion

            #region CONEXION A LA BASE DE DATOS Y POBLADO DE DATOS

            // CONECTANDO DATOS DESDE MYSQL
            MySqlCommand cm = new MySqlCommand("select * from pizzacasa;", conX.cn);
            try
            {
                conX.Abrir();
                MySqlDataReader dr = cm.ExecuteReader();

                //LISTOS PARA POBLAR EL IMAGELIST Y EL LISTVIEW
                while (dr.Read())
                {
                    // SETEO EL BORDE DE LA CELDA
                    dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;

                    // EMPAQUETAMOS IMAGEN YA CON EL TAMANO QUE QUEREMOS 80X80 Y LA AGREGAMOS A LA FILA DEL DATAGRID
                    Image image = resizeImage(Image.FromFile(dr["RutaFoto"].ToString()), new Size(80, 80));
                    dataGridView1.Rows[NumeroFila].Cells[NumeroColumna].Value = image;

                    // TOOLTIP GUARDA EL NOMBRE DEL ITEM
                    dataGridView1.Rows[NumeroFila].Cells[NumeroColumna].ToolTipText = dr["Item"].ToString();

                    // TAG GUARDA EL CODIGO DEL PRODUCTO
                    dataGridView1.Rows[NumeroFila].Cells[NumeroColumna].Tag = dr["Id"].ToString();

                    // INDICAMOS SI SEGUIMOS AGREGANDO COLUMNAS O SALTAMOS A OTRA FILA
                    if (NumeroColumna == TotalColumnas - 1)
                    {
                        NumeroFila++;
                        NumeroColumna = 0;
                    }
                    else
                    {
                        NumeroColumna++;
                    }

                    // BORRAR FILAS DE DATOS NO USADOS
                    if (TotalCeldasGeneradas > TotalRegistros)
                    {
                        for (int index = 0; index < TotalCeldasGeneradas - TotalRegistros; index++)
                        {
                            DataGridViewCellStyle EstiloCelda = new DataGridViewCellStyle();
                            EstiloCelda.NullValue = null;
                            EstiloCelda.Tag = "BLANK";
                            dataGridView1.Rows[NumeroFila].Cells[NumeroColumna + index].Style = EstiloCelda;
                        }
                    }
                }
                conX.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK);
                Application.ExitThread();
            }

            #endregion
        }
        public void CargaMedidaPizzas()                                                                 ////**** CARGA DATOS EN GRID MEDIDA DE LAS PIZZAS
        {
            #region CALCULO DE TOTAL DE REGISTROS / TOTALES DE COLUMNAS, FILAS, ETC

            // OBTENER EL TOTAL DE REGISTROS A MOSTRAR
            conX.Abrir();
            MySqlCommand Contar = new MySqlCommand("select count(*) from medidapizza;", conX.cn);
            int TotalRegistros1 = Convert.ToInt32(Contar.ExecuteScalar());
            conX.Cerrar();

            //CALCULO DEL TOTAL DE COLUMNAS CON MARGENES
            int TotalColumnas1 = 4;

            //CALCULO DEL TOTAL DE FILAS
            int TotalFilas1 = 1;

            // CALCULO PARA DEJAR EL NUMERO DE FILAS EN 1, SI ES QUE SON MENOS REGISTROS QUE COLUMNAS Y NO TIENDA A CERO
            if (TotalRegistros1 % TotalColumnas1 > 0)
            {
                TotalFilas1 += 1;
            }

            // CORRECCION EN CANTIDAD DE COLUMNAS, SI ES QUE HAY MENOS REGISTROS QUE COLUMNAS
            if (TotalRegistros1 < TotalColumnas1)
            {
                TotalColumnas1 = TotalRegistros1;
            }

            // CALCULO DE LA CANTIDAD TOTAL DE CUADROS A GENERAR / FILAS POR COLUMNAS
            int TotalCeldasGeneradas1 = TotalFilas1 * TotalColumnas1;

            #endregion

            #region DIAGRAMA COLUMNAS Y FILAS EN EL DATAGRID

            // VARIABLES PARA CORRER DENTRO DE LAS FILAS Y COLUMNAS UNA VEZ DENTRO DEL WHILE
            int NumeroColumna1 = 0;
            int NumeroFila1 = 0;

            //*** CREAR COLUMNAS Y SETEO DE ANCHO DE CADA UNA
            for (int index = 0; index < TotalColumnas1; index++)
            {
                DataGridViewImageColumn dataGridViewColumn1 = new DataGridViewImageColumn();
                dataGridView2.Columns.Add(dataGridViewColumn1);
                dataGridView2.Columns[index].Width = PorteImagenes + 5;
            }

            //*** CREAR FILAS Y SETEO DEL ALTO DE CADA UNA
            for (int index = 0; index < TotalFilas1; index++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[index].Height = PorteImagenes + 5;
            }

            #endregion

            #region CONEXION A LA BASE DE DATOS Y POBLADO DE DATOS

            // CONECTANDO DATOS DESDE MYSQL
            MySqlCommand cm1 = new MySqlCommand("select * from medidapizza;", conX.cn);
            try
            {
                conX.Abrir();
                MySqlDataReader dr1 = cm1.ExecuteReader();

                //LISTOS PARA POBLAR EL IMAGELIST Y EL LISTVIEW
                while (dr1.Read())
                {
                    // SETEO EL BORDE DE LA CELDA
                    dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;

                    // EMPAQUETAMOS IMAGEN YA CON EL TAMANO QUE QUEREMOS 80X80 Y LA AGREGAMOS A LA FILA DEL DATAGRID
                    Image image1 = resizeImage(Image.FromFile(dr1["RutaFoto_Medida"].ToString()), new Size(100, 100));
                    dataGridView2.Rows[NumeroFila1].Cells[NumeroColumna1].Value = image1;

                    // TOOLTIP GUARDA EL NOMBRE DEL ITEM
                    dataGridView2.Rows[NumeroFila1].Cells[NumeroColumna1].ToolTipText = dr1["Item_Medida"].ToString();

                    // TAG GUARDA EL CODIGO DEL PRODUCTO
                    dataGridView2.Rows[NumeroFila1].Cells[NumeroColumna1].Tag = dr1["IdMedida"].ToString();

                    // INDICAMOS SI SEGUIMOS AGREGANDO COLUMNAS O SALTAMOS A OTRA FILA
                    if (NumeroColumna1 == TotalColumnas1 - 1)
                    {
                        NumeroFila1++;
                        NumeroColumna1 = 0;
                    }
                    else
                    {
                        NumeroColumna1++;
                    }

                    // BORRAR FILAS DE DATOS NO USADOS
                    if (TotalCeldasGeneradas1 > TotalRegistros1)
                    {
                        for (int index = 0; index < TotalCeldasGeneradas1 - TotalRegistros1; index++)
                        {
                            DataGridViewCellStyle EstiloCelda1 = new DataGridViewCellStyle();
                            EstiloCelda1.NullValue = null;
                            EstiloCelda1.Tag = "BLANK";
                            dataGridView2.Rows[NumeroFila1].Cells[NumeroColumna1 + index].Style = EstiloCelda1;
                        }
                    }
                }
                conX.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK);
                Application.ExitThread();
            }

            #endregion
        }
        public void CargaMasasPizzas()                                                                  ////**** CARGA DATOS EN GRID MASAS DE LAS PIZZAS
        {
            #region CALCULO DE TOTAL DE REGISTROS / TOTALES DE COLUMNAS, FILAS, ETC

            // OBTENER EL TOTAL DE REGISTROS A MOSTRAR
            conX.Abrir();
            MySqlCommand Contar = new MySqlCommand("select count(*) from medidapizza;", conX.cn);
            int TotalRegistros2 = Convert.ToInt32(Contar.ExecuteScalar());
            conX.Cerrar();

            //CALCULO DEL TOTAL DE COLUMNAS CON MARGENES
            int TotalColumnas2 = 1;

            //CALCULO DEL TOTAL DE FILAS
            int TotalFilas2 = 3;

            // CALCULO PARA DEJAR EL NUMERO DE FILAS EN 1, SI ES QUE SON MENOS REGISTROS QUE COLUMNAS Y NO TIENDA A CERO
            if (TotalRegistros2 % TotalColumnas2 > 0)
            {
                TotalFilas2 += 1;
            }

            // CORRECCION EN CANTIDAD DE COLUMNAS, SI ES QUE HAY MENOS REGISTROS QUE COLUMNAS
            if (TotalRegistros2 < TotalColumnas2)
            {
                TotalColumnas2 = TotalRegistros2;
            }

            // CALCULO DE LA CANTIDAD TOTAL DE CUADROS A GENERAR / FILAS POR COLUMNAS
            int TotalCeldasGeneradas2 = TotalFilas2 * TotalColumnas2;

            #endregion

            #region DIAGRAMA COLUMNAS Y FILAS EN EL DATAGRID

            // VARIABLES PARA CORRER DENTRO DE LAS FILAS Y COLUMNAS UNA VEZ DENTRO DEL WHILE
            int NumeroColumna2 = 0;
            int NumeroFila2 = 0;

            //*** CREAR COLUMNAS Y SETEO DE ANCHO DE CADA UNA
            for (int index = 0; index < TotalColumnas2; index++)
            {
                DataGridViewImageColumn dataGridViewColumn2 = new DataGridViewImageColumn();
                dataGridView3.Columns.Add(dataGridViewColumn2);
                dataGridView3.Columns[index].Width = 120 + 5;
            }

            //*** CREAR FILAS Y SETEO DEL ALTO DE CADA UNA
            for (int index = 0; index < TotalFilas2; index++)
            {
                dataGridView3.Rows.Add();
                dataGridView3.Rows[index].Height = 90 + 5;
            }

            #endregion

            #region CONEXION A LA BASE DE DATOS Y POBLADO DE DATOS

            // CONECTANDO DATOS DESDE MYSQL
            MySqlCommand cm2 = new MySqlCommand("select * from masaspizza;", conX.cn);
            try
            {
                conX.Abrir();
                MySqlDataReader dr2 = cm2.ExecuteReader();

                //LISTOS PARA POBLAR EL IMAGELIST Y EL LISTVIEW
                while (dr2.Read())
                {
                    // SETEO EL BORDE DE LA CELDA
                    dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.None;

                    // EMPAQUETAMOS IMAGEN YA CON EL TAMANO QUE QUEREMOS 80X80 Y LA AGREGAMOS A LA FILA DEL DATAGRID
                    Image image2 = resizeImage(Image.FromFile(dr2["RutaFoto_Masa"].ToString()), new Size(120, 90));
                    dataGridView3.Rows[NumeroFila2].Cells[NumeroColumna2].Value = image2;

                    // TOOLTIP GUARDA EL NOMBRE DEL ITEM
                    dataGridView3.Rows[NumeroFila2].Cells[NumeroColumna2].ToolTipText = dr2["Item_Masa"].ToString();

                    // TAG GUARDA EL CODIGO DEL PRODUCTO
                    dataGridView3.Rows[NumeroFila2].Cells[NumeroColumna2].Tag = dr2["IdMasa"].ToString();

                    // INDICAMOS SI SEGUIMOS AGREGANDO COLUMNAS O SALTAMOS A OTRA FILA
                    if (NumeroColumna2 == TotalColumnas2 - 1)
                    {
                        NumeroFila2++;
                        NumeroColumna2 = 0;
                    }
                    else
                    {
                        NumeroColumna2++;
                    }

                    // BORRAR FILAS DE DATOS NO USADOS
                    if (TotalCeldasGeneradas2 > TotalRegistros2)
                    {
                        for (int index = 0; index < TotalCeldasGeneradas2 - TotalRegistros2; index++)
                        {
                            DataGridViewCellStyle EstiloCelda2 = new DataGridViewCellStyle();
                            EstiloCelda2.NullValue = null;
                            EstiloCelda2.Tag = "BLANK";
                            dataGridView3.Rows[NumeroFila2].Cells[NumeroColumna2 + index].Style = EstiloCelda2;
                        }
                    }
                }
                conX.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK);
                Application.ExitThread();
            }

            #endregion
        }

        public static Image resizeImage(Image imgToResize, Size size)                                   ////**** CAMBIA EL TAMANO DE LA IMAGEN
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void AddProductos_Load(object sender, EventArgs e)                                      ////**** LANZADOR DEL FORMULARIO AL ABRIR
        {
            CentrarForm();
            FormatoGrid();
            CargaPizzasCasa();
            CargaMedidaPizzas();
            CargaMasasPizzas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)                                        ////**** BOTON CERRAR
        {
            Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)         ////**** LANZADOR DEL CLICK EN MASAS
        {
            conX.Abrir();
            MySqlCommand Masa = new MySqlCommand("select Item_Masa from masaspizza where IdMasa=" + dataGridView3[e.ColumnIndex, e.RowIndex].Tag.ToString() + ";", conX.cn);
            MasaSeleccionada = Convert.ToString(Masa.ExecuteScalar());
            conX.Cerrar();

            ProductoSeleccionado.Text = PizzaSeleccionada + " / " + PorteSeleccionada + " / " + MasaSeleccionada;
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)         ////**** LANZADOR DEL CLICK EN TAMAÑO
        {
            conX.Abrir();
            MySqlCommand Porte = new MySqlCommand("select Item_Medida from medidapizza where IdMedida=" + dataGridView2[e.ColumnIndex, e.RowIndex].Tag.ToString() + ";", conX.cn);
            PorteSeleccionada = Convert.ToString(Porte.ExecuteScalar());
            conX.Cerrar();

            ProductoSeleccionado.Text = PizzaSeleccionada + " / " + PorteSeleccionada + " / " + MasaSeleccionada;

        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)   ////**** LANZADOR DEL CLICK EN PIZZA DE LA CASA
        {
            conX.Abrir();
            MySqlCommand Pizzas = new MySqlCommand("select Item from pizzacasa where Id=" + dataGridView1[e.ColumnIndex, e.RowIndex].Tag.ToString() + ";", conX.cn);
            PizzaSeleccionada = Convert.ToString(Pizzas.ExecuteScalar());
            conX.Cerrar();

            ProductoSeleccionado.Text = PizzaSeleccionada + " / " + PorteSeleccionada + " / " + MasaSeleccionada;

            // ESTE ES EL ID DE LA PIZZA
            pizza = dataGridView1[e.ColumnIndex, e.RowIndex].Tag.ToString();
        }
    }
}
