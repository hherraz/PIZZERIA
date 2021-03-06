﻿using System;
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
    public partial class ArmaPizza : Form
    {
        public ArmaPizza()
        {
            InitializeComponent();
        }

        Conexion conX = new Conexion();

        //// JUEGO DE VARIABLES DEL FORMULARIO
        int medida = 0;                                                                                ////**** ID DE MEDIDA PIZZA SELECCIONADA
        int masa = 0;                                                                                  ////**** ID DE MASA PIZZA SELECCIONADA

        int ancho = Screen.PrimaryScreen.Bounds.Width;
        int alto = Screen.PrimaryScreen.Bounds.Height;
        int PorteImagenes;

        int SeleccionActivaPizza = 0;
        int SeleccionActivaPorte = 0;
        int SeleccionActivaMasa = 0;

        string MasaSeleccionada;                                                                        ////**** STRING NOMBRE MASA
        string PorteSeleccionada;                                                                       ////**** STRING PORTE PIZZA
        string Seleccionada;                                                                            ////**** STRING ITEMS SELECCIONADOS

        public void CentrarForm()                                                                       ////**** CENTRAR FORMULARIO
        {
            this.Size = new Size(1008, 567);
            this.Location = new Point((ancho - this.Width) / 2, (alto - this.Height) / 2);
        }
        public void FormatoGrid()                                                                       ////**** DEFINIENDO PARAMETROS PARA LOS DATAGRIDS
        {
            PorteImagenes = 120;                //TAMANO DE LOS ICONOS
            
            //INGREDIENTES
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

            //INGREDIENTES SELECCIONADOS
            dgIngredientes.Rows.Clear();
            dgIngredientes.Columns.Clear();
            dgIngredientes.ColumnHeadersVisible = false;
            dgIngredientes.RowHeadersVisible = false;

            DataGridViewButtonColumn boton = new DataGridViewButtonColumn()
            {
                Text = "Borrar",
                HeaderText = "Borrar",
                ToolTipText = "Borrar",
                Name = "Borrar",
                UseColumnTextForButtonValue = true,
                Width = 50
            };
            dgIngredientes.Columns.Add("Ingrediente", "Ingrediente");
            dgIngredientes.Columns.Add("Precio", "Precio");
            dgIngredientes.Columns.Add(boton);

            dgIngredientes.Columns[0].Name = "Ingrediente";
            dgIngredientes.Columns[1].Name = "Precio";
            dgIngredientes.Columns[2].Name = "Borrar";

            dgIngredientes.Columns[0].Width = 125;
            dgIngredientes.Columns[1].Width = 50;
            dgIngredientes.Columns[2].Width = 55;

        }
        private void AddProductos_Load(object sender, EventArgs e)                                      ////**** LANZADOR DEL FORMULARIO AL ABRIR
        {
            CentrarForm();
            FormatoGrid();
            CargaIngredientes();
            CargaMedidaPizzas();
            CargaMasasPizzas();

            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
        }

        public void ActivarPedido()                                                                     ////**** ACTIVA O DESACTIVA EL BOTON PEDIDO
        {
            if (SeleccionActivaPizza + SeleccionActivaPorte + SeleccionActivaMasa == 3)
            {
                AgregarPizzaMenu.Visible = true;
                txtpreciounitario.Text = Convert.ToString(CalcularPedido());
                txtprecio.Text = Convert.ToString(cantidadBox.Value * Convert.ToInt32(txtpreciounitario.Text));
            }
            else
            {
                AgregarPizzaMenu.Visible = false;
                txtpreciounitario.Clear();
                txtprecio.Clear();
            }
        }

        public int CalcularPedido()                                                                     ////**** CALCULAR PEDIDO
        {
            int PrecioPizza = 0;
            int PrecioMasa = 0;
            int PrecioPedido = 0;

            #region String de Tarifa
            string TituloTarifa="";
            if (medida == 1)
            {
                TituloTarifa = "PrecioIndividual";
            }
            if (medida == 2)
            {
                TituloTarifa = "PrecioMediana";
            }
            if (medida == 3)
            {
                TituloTarifa = "PrecioFamiliar";
            }
            if (medida == 4)
            {
                TituloTarifa = "PrecioXL";
            }

            conX.Abrir();
            string sql = "select " + TituloTarifa + " from preciosbasepizza where IdBase=1;";
            MySqlCommand Precio = new MySqlCommand(sql, conX.cn);
            PrecioPizza = Convert.ToInt32(Precio.ExecuteScalar());
            #endregion

            #region String de Masa
            conX.Abrir();
            string sql1 = "select PrecioMasa from masaspizza where IdMasa=" + masa + ";";
            MySqlCommand Masa = new MySqlCommand(sql1, conX.cn);
            Masa.Parameters.AddWithValue("?masa", masa);
            PrecioMasa = Convert.ToInt32(Masa.ExecuteScalar());
            conX.Cerrar();
            #endregion

            PrecioPedido = PrecioPizza + PrecioMasa + ActualizarSuma();

            return PrecioPedido;
        }
        public void EnviarPedido()                                                                      ////**** ENVIAR PEDIDO
        {
            Seleccionada = PorteSeleccionada + " - " + MasaSeleccionada + " " + FilaIngredientes();

            if (DatosCompartidos.Instance().NombreFormularioActivo == "ConsumoLocal")
            {
                Application.OpenForms.OfType<ConsumoLocal>().First().GridConsumo.Rows.Add(cantidadBox.Value, Seleccionada, txtpreciounitario.Text, txtprecio.Text);
                Close();
            }

            if (DatosCompartidos.Instance().NombreFormularioActivo == "RetiroLocal")
            {
                Application.OpenForms.OfType<RetiroLocal>().First().GridRetiro.Rows.Add(cantidadBox.Value, Seleccionada, txtpreciounitario.Text, txtprecio.Text);
                Close();
            }

            if (DatosCompartidos.Instance().NombreFormularioActivo == "Delivery")
            {
                Application.OpenForms.OfType<Delivery>().First().GridDelivery.Rows.Add(cantidadBox.Value, Seleccionada, txtpreciounitario.Text, txtprecio.Text);
                Close();
            }
        }

        public void CargaIngredientes()                                                                 ////**** CARGA DATOS EN GRID LOS INGREDIENTES
        {
            #region CALCULO DE TOTAL DE REGISTROS / TOTALES DE COLUMNAS, FILAS, ETC

            // OBTENER EL TOTAL DE REGISTROS A MOSTRAR
            conX.Abrir();
            MySqlCommand Contar = new MySqlCommand("select count(*) from ingredientes; ", conX.cn);
            int TotalRegistros = Convert.ToInt32(Contar.ExecuteScalar());
            conX.Cerrar();

            //CALCULO DEL TOTAL DE COLUMNAS CON MARGENES
            int TotalColumnas = (dataGridView1.Width - 10) / (PorteImagenes + 10);

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
                dataGridView1.Columns[index].Width = PorteImagenes + 10;
            }

            //*** CREAR FILAS Y SETEO DEL ALTO DE CADA UNA
            for (int index = 0; index < TotalFilas; index++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Height = PorteImagenes + 10;
            }

            #endregion
            #region CONEXION A LA BASE DE DATOS Y POBLADO DE DATOS
            MySqlCommand cm = new MySqlCommand("select * from ingredientes; ", conX.cn);                                // CONECTANDO DATOS DESDE MYSQL
            try
            {
                conX.Abrir();
                MySqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())                                                                                   //LISTOS PARA POBLAR EL IMAGELIST Y EL LISTVIEW
                {
                    dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;                               // SETEO EL BORDE DE LA CELDA
                    Font fuente = new Font("Verdana", 8);                                                           //PREDETERMINO LA FUENTE Y EL TAMANO DEL TEXTO A GENERAR


                    /////CODIGO PARA LEER LAS FOTOS DESDE LA BASE DATOS
                    byte[] imgArr = (byte[])dr["Imagen"];
                    imgArr = (byte[])dr["Imagen"];
                    MemoryStream stream = new MemoryStream(imgArr);
                    Image image = ResizeImage(Image.FromStream(stream), new Size(120, 120));
                    /////CODIGO PARA LEER LAS FOTOS DESDE LA BASE DATOS


                    Graphics g = Graphics.FromImage(image);                                                         //LA PASAMOS A OBJETO GRAFICO
                    g.FillRectangle(Brushes.Black, new Rectangle(0, 0, this.Width, 15));                            //DIBUJO EL RECTANGULO NEGRO CON GDI+
                    SizeF txtsize=TextRenderer.MeasureText(dr["NombreIngrediente"].ToString(), fuente);                           //CALCULO EL TAMANO GRAFICO DEL STRING PARA PODER CENTRAR EL TEXTO
                    g.DrawString(dr["NombreIngrediente"].ToString(), fuente, Brushes.White, new PointF((image.Width-txtsize.Width)/2, 0));   //ESCRIBO SOBRE EL RECTANGULO CON GDI+
                    dataGridView1.Rows[NumeroFila].Cells[NumeroColumna].Value = image;                              //AGREGO LA IMAGEN MODIFICADA A LA FILA DEL GRIDVIEW
                    g.Dispose();                                                                                    //BOTO LA INFO DEL GDI+

                    dataGridView1.Rows[NumeroFila].Cells[NumeroColumna].ToolTipText = dr["NombreIngrediente"].ToString();        // TOOLTIP GUARDA EL NOMBRE DEL ITEM
                    dataGridView1.Rows[NumeroFila].Cells[NumeroColumna].Tag = dr["IdIngrediente"].ToString();                  // TAG GUARDA EL CODIGO DEL PRODUCTO

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
                            DataGridViewCellStyle EstiloCelda = new DataGridViewCellStyle()
                            {
                                NullValue = null,
                                Tag = "BLANK"
                            };
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
                    //Image image1 = ResizeImage(Image.FromFile(dr1["RutaFoto_Medida"].ToString()), new Size(100, 100));

                    byte[] imgArr = (byte[])dr1["Imagen"];
                    imgArr = (byte[])dr1["Imagen"];
                    MemoryStream stream = new MemoryStream(imgArr);
                    Image image1 = ResizeImage(Image.FromStream(stream), new Size(100, 100));

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
                            DataGridViewCellStyle EstiloCelda1 = new DataGridViewCellStyle()
                            {
                                NullValue = null,
                                Tag = "BLANK"
                            };
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
                    //Image image2 = ResizeImage(Image.FromFile(dr2["RutaFoto_Masa"].ToString()), new Size(120, 90));

                    byte[] imgArr = (byte[])dr2["Imagen"];
                    imgArr = (byte[])dr2["Imagen"];
                    MemoryStream stream = new MemoryStream(imgArr);
                    Image image2 = ResizeImage(Image.FromStream(stream), new Size(120, 90));

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
                            DataGridViewCellStyle EstiloCelda2 = new DataGridViewCellStyle()
                            {
                                NullValue = null,
                                Tag = "BLANK"
                            };
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

        private void CantidadBox_ValueChanged(object sender, EventArgs e)                               ////**** ACTUALIZAR EL VALOR, SI CAMBIA LA CANTIDAD
        {
            ActivarPedido();
        }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)         ////**** LANZADOR DEL CLICK EN MASAS
        {
            conX.Abrir();
            MySqlCommand MasaX = new MySqlCommand("select Item_Masa from masaspizza where IdMasa=" + dataGridView3[e.ColumnIndex, e.RowIndex].Tag.ToString() + ";", conX.cn);
            MasaSeleccionada = Convert.ToString(MasaX.ExecuteScalar());
            conX.Cerrar();

            // ESTE ES EL ID DE LA MASA
            masa = Convert.ToInt32(dataGridView3[e.ColumnIndex, e.RowIndex].Tag.ToString());
            SeleccionActivaMasa = 1;

            ProductoSeleccionado.Text = PorteSeleccionada + "\n" + MasaSeleccionada;
            ActivarPedido();
        }
        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)         ////**** LANZADOR DEL CLICK EN TAMAÑO
        {
            conX.Abrir();
            MySqlCommand Porte = new MySqlCommand("select Item_Medida from medidapizza where IdMedida=" + dataGridView2[e.ColumnIndex, e.RowIndex].Tag.ToString() + ";", conX.cn);
            PorteSeleccionada = Convert.ToString(Porte.ExecuteScalar());
            conX.Cerrar();

            // ESTE ES EL ID DE LA MEDIDA
            medida = Convert.ToInt32(dataGridView2[e.ColumnIndex, e.RowIndex].Tag.ToString());
            SeleccionActivaPorte = 1;

            ProductoSeleccionado.Text = PorteSeleccionada + "\n" + MasaSeleccionada;
            ActivarPedido();
        }
        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)   ////**** LANZADOR DEL CLICK EN PIZZA DE LA CASA
        {
            conX.Abrir();
            try
            {
                MySqlCommand Pizzas = new MySqlCommand("select PrecioIngrediente from ingredientes where IdIngrediente=" + dataGridView1[e.ColumnIndex, e.RowIndex].Tag.ToString() + ";", conX.cn);

                //agrega al grid de ingredientes nombre y precio
                dgIngredientes.Rows.Add(dataGridView1[e.ColumnIndex, e.RowIndex].ToolTipText.ToString(), Convert.ToString(Pizzas.ExecuteScalar()));
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();

            // ESTE ES EL ID DE LA PIZZA
            //pizza = Convert.ToInt32(dataGridView1[e.ColumnIndex, e.RowIndex].Tag.ToString());
            SeleccionActivaPizza = 1;
            ProductoSeleccionado.Text = PorteSeleccionada + "\n" + MasaSeleccionada;
            ActivarPedido();
        }

        private void AgregarPizzaMenu_Click(object sender, EventArgs e)                                 ////**** ENVIAR LA PIZZA SELECCIONADA AL TOMA DE PEDIDOS
        {
            EnviarPedido();
        }
        private void BtnCerrar_Click(object sender, EventArgs e)                                        ////**** BOTON CERRAR
        {
            Close();
        }

        public static Image ResizeImage(Image imgToResize, Size size)                                   ////**** CAMBIA EL TAMANO DE LA IMAGEN
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void DgIngredientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //SI EL CLICK ES EN UNA FILA NUEVA, O INFERIOR A LA FILA 0
            if (e.RowIndex == dgIngredientes.NewRowIndex || e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == dgIngredientes.Columns["Borrar"].Index)
            {
                dgIngredientes.Rows.RemoveAt(e.RowIndex);
            }
            ActivarPedido();

        }     ////**** BORRAR INGREDIENTE
        public int ActualizarSuma()
        {
            int sumatoria = 0;

            foreach (DataGridViewRow row in dgIngredientes.Rows)
            {
                sumatoria += Convert.ToInt32(row.Cells["Precio"].Value);
            }

            return sumatoria;
        }                                                                  ////**** SUMAR INGREDIENTES

        public string FilaIngredientes()
        {
            string items = "(";
            foreach(DataGridViewRow row in dgIngredientes.Rows)
            {
                items += row.Cells["Ingrediente"].Value + ", ";
            }
            items += ")";
            return items;
        }
    }
}
