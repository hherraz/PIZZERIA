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

        Conexion conX = new Conexion();

        //// JUEGO DE VARIABLES DEL FORMULARIO
        int ancho = Screen.PrimaryScreen.Bounds.Width;
        int alto = Screen.PrimaryScreen.Bounds.Height;
        int PorteImagenes;

        int ItemEnCarrito = 0;                                                                          ////**** CONTROL DE ITEMS EN CARRITO

        public void CentrarForm()                                                                       ////**** CENTRAR FORMULARIO
        {
            this.Size = new Size(1008, 520);
            this.Location = new Point((ancho - this.Width) / 2, (alto - this.Height) / 2);
        }
        public void FormatoGrid()                                                                       ////**** DEFINIENDO PARAMETROS PARA LOS DATAGRIDS
        {
            PorteImagenes = 120;                //TAMANO DE LOS ICONOS
            
            //PRODUCTOS
            dgProductos.Rows.Clear();         //LIMPIAR FILAS
            dgProductos.Columns.Clear();      //LIMPIAR COLUMNAS
            dgProductos.AllowUserToAddRows = false;
            dgProductos.ColumnHeadersVisible = false;
            dgProductos.RowHeadersVisible = false;
            
            //CARRITO DE COMPRAS
            dgCarrito.Rows.Clear();
            dgCarrito.Columns.Clear();
            dgCarrito.ColumnHeadersVisible = false;
            dgCarrito.RowHeadersVisible = false;

            DataGridViewButtonColumn boton = new DataGridViewButtonColumn()
            {
                Text = "Borrar",
                HeaderText = "Borrar",
                ToolTipText = "Borrar",
                Name = "Borrar",
                UseColumnTextForButtonValue = true,
                Width = 50
            };
            dgCarrito.Columns.Add("Item", "Item");
            dgCarrito.Columns.Add("Precio", "Precio");
            dgCarrito.Columns.Add(boton);

            dgCarrito.Columns[0].Name = "Item";
            dgCarrito.Columns[1].Name = "Precio";
            dgCarrito.Columns[2].Name = "Borrar";

            dgCarrito.Columns[0].Width = 125;
            dgCarrito.Columns[1].Width = 50;
            dgCarrito.Columns[2].Width = 55;

        }
        private void AddProductos_Load(object sender, EventArgs e)                                      ////**** LANZADOR DEL FORMULARIO AL ABRIR
        {
            CentrarForm();
            FormatoGrid();
            CargaProductos();
            dgProductos.ClearSelection();
        }

        public void ActivarPedido()                                                                     ////**** ACTIVA O DESACTIVA EL BOTON PEDIDO
        {
            if (ItemEnCarrito != 0)
            {
                AgregarPizzaMenu.Visible = true;
                txtprecio.Text = Convert.ToString(CalcularPedido());
            }
            else
            {
                AgregarPizzaMenu.Visible = false;
                txtprecio.Clear();
            }
        }

        public int CalcularPedido()                                                                     ////**** CALCULAR PEDIDO
        {
            int PrecioPedido = 0;
            PrecioPedido = ActualizarSuma();

            return PrecioPedido;
        }

        public void EnviarPedido()                                                                      ////**** ENVIAR PEDIDO
        {
            ///HACER CORRER UN ROWS PARA AGREGAR 1 A UNO
            foreach (DataGridViewRow row in dgCarrito.Rows)
            {
                if (DatosCompartidos.Instance().NombreFormularioActivo == "ConsumoLocal")
                {
                    Application.OpenForms.OfType<ConsumoLocal>().First().GridConsumo.Rows.Add(1, row.Cells["Item"].Value, row.Cells["Precio"].Value, row.Cells["Precio"].Value);
                    Close();
                }

                if (DatosCompartidos.Instance().NombreFormularioActivo == "RetiroLocal")
                {
                    Application.OpenForms.OfType<RetiroLocal>().First().GridRetiro.Rows.Add(1, row.Cells["Item"].Value, row.Cells["Precio"].Value, row.Cells["Precio"].Value);
                    Close();
                }

                if (DatosCompartidos.Instance().NombreFormularioActivo == "Delivery")
                {
                    Application.OpenForms.OfType<Delivery>().First().GridDelivery.Rows.Add(1, row.Cells["Item"].Value, row.Cells["Precio"].Value, row.Cells["Precio"].Value);
                    Close();
                }

            }
            ///Seleccionada = FilaIngredientes();
        }

        public void CargaProductos()                                                                   ////**** CARGA TODOS DATOS EN GRID
        {
            dgProductos.Columns.Clear();
            dgProductos.Rows.Clear();

            #region CALCULO DE TOTAL DE REGISTROS / TOTALES DE COLUMNAS, FILAS, ETC

            // OBTENER EL TOTAL DE REGISTROS A MOSTRAR
            conX.Abrir();
            MySqlCommand Contar = new MySqlCommand("select count(*) from productos; ", conX.cn);
            int TotalRegistros = Convert.ToInt32(Contar.ExecuteScalar());
            conX.Cerrar();

            //CALCULO DEL TOTAL DE COLUMNAS CON MARGENES
            int TotalColumnas = (dgProductos.Width - 10) / (PorteImagenes + 10);

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
                dgProductos.Columns.Add(dataGridViewColumn);
                dgProductos.Columns[index].Width = PorteImagenes + 10;
            }

            //*** CREAR FILAS Y SETEO DEL ALTO DE CADA UNA
            for (int index = 0; index < TotalFilas; index++)
            {
                dgProductos.Rows.Add();
                dgProductos.Rows[index].Height = PorteImagenes + 10;
            }

            #endregion
            #region CONEXION A LA BASE DE DATOS Y POBLADO DE DATOS
            MySqlCommand cm = new MySqlCommand("select * from productos; ", conX.cn);                                // CONECTANDO DATOS DESDE MYSQL
            try
            {
                conX.Abrir();
                MySqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())                                                                                   //LISTOS PARA POBLAR EL IMAGELIST Y EL LISTVIEW
                {
                    dgProductos.CellBorderStyle = DataGridViewCellBorderStyle.None;                               // SETEO EL BORDE DE LA CELDA

                    // EMPAQUETAMOS IMAGEN YA CON EL TAMANO QUE QUEREMOS 80X80 Y LA AGREGAMOS A LA FILA DEL DATAGRID
                    Font fuente = new Font("Verdana", 8);                                                           //PREDETERMINO LA FUENTE Y EL TAMANO DEL TEXTO A GENERAR

                    //Image image = resizeImage(Image.FromFile(dr["RutaFoto"].ToString()), new Size(120, 120));       //RUTA DE LA IMAGEN DESDE LA BASE DATOS Y TAMANO
                    //Graphics g = Graphics.FromImage(image);                                                         //LA PASAMOS A OBJETO GRAFICO

                    /////CODIGO PARA LEER LAS FOTOS DESDE LA BASE DATOS
                    byte[] imgArr = (byte[])dr["Imagen"];
                    imgArr = (byte[])dr["Imagen"];
                    MemoryStream stream = new MemoryStream(imgArr);
                    Image image = ResizeImage(Image.FromStream(stream), new Size(120, 120));
                    /////CODIGO PARA LEER LAS FOTOS DESDE LA BASE DATOS

                    Graphics g = Graphics.FromImage(image);
                    g.FillRectangle(Brushes.Black, new Rectangle(0, 0, this.Width, 15));                            //DIBUJO EL RECTANGULO NEGRO CON GDI+
                    SizeF txtsize=TextRenderer.MeasureText(dr["Item"].ToString(), fuente);                           //CALCULO EL TAMANO GRAFICO DEL STRING PARA PODER CENTRAR EL TEXTO
                    g.DrawString(dr["Item"].ToString(), fuente, Brushes.White, new PointF((image.Width-txtsize.Width)/2, 0));   //ESCRIBO SOBRE EL RECTANGULO CON GDI+
                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].Value = image;                              //AGREGO LA IMAGEN MODIFICADA A LA FILA DEL GRIDVIEW
                    g.Dispose();                                                                                    //BOTO LA INFO DEL GDI+

                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].ToolTipText = dr["Item"].ToString();        // TOOLTIP GUARDA EL NOMBRE DEL ITEM
                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].Tag = dr["IdProducto"].ToString();                  // TAG GUARDA EL CODIGO DEL PRODUCTO

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
                            dgProductos.Rows[NumeroFila].Cells[NumeroColumna + index].Style = EstiloCelda;
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
        public void CargaProductosLiquidos()                                                           ////**** CARGA LIQUIDOS EN GRID
        {
            dgProductos.Columns.Clear();
            dgProductos.Rows.Clear();

            #region CALCULO DE TOTAL DE REGISTROS / TOTALES DE COLUMNAS, FILAS, ETC

            // OBTENER EL TOTAL DE REGISTROS A MOSTRAR
            conX.Abrir();
            MySqlCommand Contar = new MySqlCommand("select count(*) from productos where Familia=1; ", conX.cn);
            int TotalRegistros = Convert.ToInt32(Contar.ExecuteScalar());
            conX.Cerrar();

            //CALCULO DEL TOTAL DE COLUMNAS CON MARGENES
            int TotalColumnas = (dgProductos.Width - 10) / (PorteImagenes + 10);

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
                dgProductos.Columns.Add(dataGridViewColumn);
                dgProductos.Columns[index].Width = PorteImagenes + 10;
            }

            //*** CREAR FILAS Y SETEO DEL ALTO DE CADA UNA
            for (int index = 0; index < TotalFilas; index++)
            {
                dgProductos.Rows.Add();
                dgProductos.Rows[index].Height = PorteImagenes + 10;
            }

            #endregion
            #region CONEXION A LA BASE DE DATOS Y POBLADO DE DATOS
            MySqlCommand cm = new MySqlCommand("select * from productos where Familia=1; ", conX.cn);                                // CONECTANDO DATOS DESDE MYSQL
            try
            {
                conX.Abrir();
                MySqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())                                                                                   //LISTOS PARA POBLAR EL IMAGELIST Y EL LISTVIEW
                {
                    dgProductos.CellBorderStyle = DataGridViewCellBorderStyle.None;                               // SETEO EL BORDE DE LA CELDA

                    // EMPAQUETAMOS IMAGEN YA CON EL TAMANO QUE QUEREMOS 80X80 Y LA AGREGAMOS A LA FILA DEL DATAGRID
                    Font fuente = new Font("Verdana", 8);                                                           //PREDETERMINO LA FUENTE Y EL TAMANO DEL TEXTO A GENERAR

                    /////CODIGO PARA LEER LAS FOTOS DESDE LA BASE DATOS
                    byte[] imgArr = (byte[])dr["Imagen"];
                    imgArr = (byte[])dr["Imagen"];
                    MemoryStream stream = new MemoryStream(imgArr);
                    Image image = ResizeImage(Image.FromStream(stream), new Size(120, 120));
                    /////CODIGO PARA LEER LAS FOTOS DESDE LA BASE DATOS

                    //Image image = resizeImage(Image.FromFile(dr["RutaFoto"].ToString()), new Size(120, 120));       //RUTA DE LA IMAGEN DESDE LA BASE DATOS Y TAMANO

                    Graphics g = Graphics.FromImage(image);                                                         //LA PASAMOS A OBJETO GRAFICO
                    g.FillRectangle(Brushes.Black, new Rectangle(0, 0, this.Width, 15));                            //DIBUJO EL RECTANGULO NEGRO CON GDI+
                    SizeF txtsize = TextRenderer.MeasureText(dr["Item"].ToString(), fuente);                           //CALCULO EL TAMANO GRAFICO DEL STRING PARA PODER CENTRAR EL TEXTO
                    g.DrawString(dr["Item"].ToString(), fuente, Brushes.White, new PointF((image.Width - txtsize.Width) / 2, 0));   //ESCRIBO SOBRE EL RECTANGULO CON GDI+
                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].Value = image;                              //AGREGO LA IMAGEN MODIFICADA A LA FILA DEL GRIDVIEW
                    g.Dispose();                                                                                    //BOTO LA INFO DEL GDI+

                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].ToolTipText = dr["Item"].ToString();        // TOOLTIP GUARDA EL NOMBRE DEL ITEM
                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].Tag = dr["IdProducto"].ToString();                  // TAG GUARDA EL CODIGO DEL PRODUCTO

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
                            dgProductos.Rows[NumeroFila].Cells[NumeroColumna + index].Style = EstiloCelda;
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
        public void CargaProductosPostres()                                                            ////**** CARGA POSTRES EN GRID
        {
            dgProductos.Columns.Clear();
            dgProductos.Rows.Clear();

            #region CALCULO DE TOTAL DE REGISTROS / TOTALES DE COLUMNAS, FILAS, ETC

            // OBTENER EL TOTAL DE REGISTROS A MOSTRAR
            conX.Abrir();
            MySqlCommand Contar = new MySqlCommand("select count(*) from productos where Familia=2; ", conX.cn);
            int TotalRegistros = Convert.ToInt32(Contar.ExecuteScalar());
            conX.Cerrar();

            //CALCULO DEL TOTAL DE COLUMNAS CON MARGENES
            int TotalColumnas = (dgProductos.Width - 10) / (PorteImagenes + 10);

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
                dgProductos.Columns.Add(dataGridViewColumn);
                dgProductos.Columns[index].Width = PorteImagenes + 10;
            }

            //*** CREAR FILAS Y SETEO DEL ALTO DE CADA UNA
            for (int index = 0; index < TotalFilas; index++)
            {
                dgProductos.Rows.Add();
                dgProductos.Rows[index].Height = PorteImagenes + 10;
            }

            #endregion
            #region CONEXION A LA BASE DE DATOS Y POBLADO DE DATOS
            MySqlCommand cm = new MySqlCommand("select * from productos where Familia=2; ", conX.cn);                                // CONECTANDO DATOS DESDE MYSQL
            try
            {
                conX.Abrir();
                MySqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())                                                                                   //LISTOS PARA POBLAR EL IMAGELIST Y EL LISTVIEW
                {
                    dgProductos.CellBorderStyle = DataGridViewCellBorderStyle.None;                               // SETEO EL BORDE DE LA CELDA

                    // EMPAQUETAMOS IMAGEN YA CON EL TAMANO QUE QUEREMOS 80X80 Y LA AGREGAMOS A LA FILA DEL DATAGRID
                    Font fuente = new Font("Verdana", 8);                                                           //PREDETERMINO LA FUENTE Y EL TAMANO DEL TEXTO A GENERAR

                    /////CODIGO PARA LEER LAS FOTOS DESDE LA BASE DATOS
                    byte[] imgArr = (byte[])dr["Imagen"];
                    imgArr = (byte[])dr["Imagen"];
                    MemoryStream stream = new MemoryStream(imgArr);
                    Image image = ResizeImage(Image.FromStream(stream), new Size(120, 120));
                    /////CODIGO PARA LEER LAS FOTOS DESDE LA BASE DATOS

                    //Image image = resizeImage(Image.FromFile(dr["RutaFoto"].ToString()), new Size(120, 120));       //RUTA DE LA IMAGEN DESDE LA BASE DATOS Y TAMANO

                    Graphics g = Graphics.FromImage(image);                                                         //LA PASAMOS A OBJETO GRAFICO
                    g.FillRectangle(Brushes.Black, new Rectangle(0, 0, this.Width, 15));                            //DIBUJO EL RECTANGULO NEGRO CON GDI+
                    SizeF txtsize = TextRenderer.MeasureText(dr["Item"].ToString(), fuente);                           //CALCULO EL TAMANO GRAFICO DEL STRING PARA PODER CENTRAR EL TEXTO
                    g.DrawString(dr["Item"].ToString(), fuente, Brushes.White, new PointF((image.Width - txtsize.Width) / 2, 0));   //ESCRIBO SOBRE EL RECTANGULO CON GDI+
                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].Value = image;                              //AGREGO LA IMAGEN MODIFICADA A LA FILA DEL GRIDVIEW
                    g.Dispose();                                                                                    //BOTO LA INFO DEL GDI+

                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].ToolTipText = dr["Item"].ToString();        // TOOLTIP GUARDA EL NOMBRE DEL ITEM
                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].Tag = dr["IdProducto"].ToString();                  // TAG GUARDA EL CODIGO DEL PRODUCTO

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
                            dgProductos.Rows[NumeroFila].Cells[NumeroColumna + index].Style = EstiloCelda;
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
        public void CargaProductosAcomp()                                                              ////**** CARGA ACOMPANAMIENTOS EN GRID
        {
            dgProductos.Columns.Clear();
            dgProductos.Rows.Clear();

            #region CALCULO DE TOTAL DE REGISTROS / TOTALES DE COLUMNAS, FILAS, ETC

            // OBTENER EL TOTAL DE REGISTROS A MOSTRAR
            conX.Abrir();
            MySqlCommand Contar = new MySqlCommand("select count(*) from productos where Familia=4; ", conX.cn);
            int TotalRegistros = Convert.ToInt32(Contar.ExecuteScalar());
            conX.Cerrar();

            //CALCULO DEL TOTAL DE COLUMNAS CON MARGENES
            int TotalColumnas = (dgProductos.Width - 10) / (PorteImagenes + 10);

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
                dgProductos.Columns.Add(dataGridViewColumn);
                dgProductos.Columns[index].Width = PorteImagenes + 10;
            }

            //*** CREAR FILAS Y SETEO DEL ALTO DE CADA UNA
            for (int index = 0; index < TotalFilas; index++)
            {
                dgProductos.Rows.Add();
                dgProductos.Rows[index].Height = PorteImagenes + 10;
            }

            #endregion
            #region CONEXION A LA BASE DE DATOS Y POBLADO DE DATOS
            MySqlCommand cm = new MySqlCommand("select * from productos where Familia=4; ", conX.cn);                                // CONECTANDO DATOS DESDE MYSQL
            try
            {
                conX.Abrir();
                MySqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())                                                                                   //LISTOS PARA POBLAR EL IMAGELIST Y EL LISTVIEW
                {
                    dgProductos.CellBorderStyle = DataGridViewCellBorderStyle.None;                               // SETEO EL BORDE DE LA CELDA

                    // EMPAQUETAMOS IMAGEN YA CON EL TAMANO QUE QUEREMOS 80X80 Y LA AGREGAMOS A LA FILA DEL DATAGRID
                    Font fuente = new Font("Verdana", 8);                                                           //PREDETERMINO LA FUENTE Y EL TAMANO DEL TEXTO A GENERAR

                    /////CODIGO PARA LEER LAS FOTOS DESDE LA BASE DATOS
                    byte[] imgArr = (byte[])dr["Imagen"];
                    imgArr = (byte[])dr["Imagen"];
                    MemoryStream stream = new MemoryStream(imgArr);
                    Image image = ResizeImage(Image.FromStream(stream), new Size(120, 120));
                    /////CODIGO PARA LEER LAS FOTOS DESDE LA BASE DATOS

                    //Image image = resizeImage(Image.FromFile(dr["RutaFoto"].ToString()), new Size(120, 120));       //RUTA DE LA IMAGEN DESDE LA BASE DATOS Y TAMANO

                    Graphics g = Graphics.FromImage(image);                                                         //LA PASAMOS A OBJETO GRAFICO
                    g.FillRectangle(Brushes.Black, new Rectangle(0, 0, this.Width, 15));                            //DIBUJO EL RECTANGULO NEGRO CON GDI+
                    SizeF txtsize = TextRenderer.MeasureText(dr["Item"].ToString(), fuente);                           //CALCULO EL TAMANO GRAFICO DEL STRING PARA PODER CENTRAR EL TEXTO
                    g.DrawString(dr["Item"].ToString(), fuente, Brushes.White, new PointF((image.Width - txtsize.Width) / 2, 0));   //ESCRIBO SOBRE EL RECTANGULO CON GDI+
                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].Value = image;                              //AGREGO LA IMAGEN MODIFICADA A LA FILA DEL GRIDVIEW
                    g.Dispose();                                                                                    //BOTO LA INFO DEL GDI+

                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].ToolTipText = dr["Item"].ToString();        // TOOLTIP GUARDA EL NOMBRE DEL ITEM
                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].Tag = dr["IdProducto"].ToString();                  // TAG GUARDA EL CODIGO DEL PRODUCTO

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
                            dgProductos.Rows[NumeroFila].Cells[NumeroColumna + index].Style = EstiloCelda;
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
        public void CargaProductosOtros()                                                              ////**** CARGA OTROS EN GRID
        {
            dgProductos.Columns.Clear();
            dgProductos.Rows.Clear();

            #region CALCULO DE TOTAL DE REGISTROS / TOTALES DE COLUMNAS, FILAS, ETC

            // OBTENER EL TOTAL DE REGISTROS A MOSTRAR
            conX.Abrir();
            MySqlCommand Contar = new MySqlCommand("select count(*) from productos where Familia=3; ", conX.cn);
            int TotalRegistros = Convert.ToInt32(Contar.ExecuteScalar());
            conX.Cerrar();

            //CALCULO DEL TOTAL DE COLUMNAS CON MARGENES
            int TotalColumnas = (dgProductos.Width - 10) / (PorteImagenes + 10);

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
                dgProductos.Columns.Add(dataGridViewColumn);
                dgProductos.Columns[index].Width = PorteImagenes + 10;
            }

            //*** CREAR FILAS Y SETEO DEL ALTO DE CADA UNA
            for (int index = 0; index < TotalFilas; index++)
            {
                dgProductos.Rows.Add();
                dgProductos.Rows[index].Height = PorteImagenes + 10;
            }

            #endregion
            #region CONEXION A LA BASE DE DATOS Y POBLADO DE DATOS
            MySqlCommand cm = new MySqlCommand("select * from productos where Familia=3; ", conX.cn);                                // CONECTANDO DATOS DESDE MYSQL
            try
            {
                conX.Abrir();
                MySqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())                                                                                   //LISTOS PARA POBLAR EL IMAGELIST Y EL LISTVIEW
                {
                    dgProductos.CellBorderStyle = DataGridViewCellBorderStyle.None;                               // SETEO EL BORDE DE LA CELDA

                    // EMPAQUETAMOS IMAGEN YA CON EL TAMANO QUE QUEREMOS 80X80 Y LA AGREGAMOS A LA FILA DEL DATAGRID
                    Font fuente = new Font("Verdana", 8);                                                           //PREDETERMINO LA FUENTE Y EL TAMANO DEL TEXTO A GENERAR

                    /////CODIGO PARA LEER LAS FOTOS DESDE LA BASE DATOS
                    byte[] imgArr = (byte[])dr["Imagen"];
                    imgArr = (byte[])dr["Imagen"];
                    MemoryStream stream = new MemoryStream(imgArr);
                    Image image = ResizeImage(Image.FromStream(stream), new Size(120, 120));
                    /////CODIGO PARA LEER LAS FOTOS DESDE LA BASE DATOS

                    //Image image = resizeImage(Image.FromFile(dr["RutaFoto"].ToString()), new Size(120, 120));       //RUTA DE LA IMAGEN DESDE LA BASE DATOS Y TAMANO

                    Graphics g = Graphics.FromImage(image);                                                         //LA PASAMOS A OBJETO GRAFICO
                    g.FillRectangle(Brushes.Black, new Rectangle(0, 0, this.Width, 15));                            //DIBUJO EL RECTANGULO NEGRO CON GDI+
                    SizeF txtsize = TextRenderer.MeasureText(dr["Item"].ToString(), fuente);                           //CALCULO EL TAMANO GRAFICO DEL STRING PARA PODER CENTRAR EL TEXTO
                    g.DrawString(dr["Item"].ToString(), fuente, Brushes.White, new PointF((image.Width - txtsize.Width) / 2, 0));   //ESCRIBO SOBRE EL RECTANGULO CON GDI+
                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].Value = image;                              //AGREGO LA IMAGEN MODIFICADA A LA FILA DEL GRIDVIEW
                    g.Dispose();                                                                                    //BOTO LA INFO DEL GDI+

                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].ToolTipText = dr["Item"].ToString();        // TOOLTIP GUARDA EL NOMBRE DEL ITEM
                    dgProductos.Rows[NumeroFila].Cells[NumeroColumna].Tag = dr["IdProducto"].ToString();                  // TAG GUARDA EL CODIGO DEL PRODUCTO

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
                            dgProductos.Rows[NumeroFila].Cells[NumeroColumna + index].Style = EstiloCelda;
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

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)   ////**** LANZADOR DEL CLICK EN PIZZA DE LA CASA
        {
            conX.Abrir();
            try
            {
                MySqlCommand producto = new MySqlCommand("select PrecioUnitario from productos where idProducto=" + dgProductos[e.ColumnIndex, e.RowIndex].Tag.ToString() + ";", conX.cn);

                //agrega al grid de ingredientes nombre y precio
                dgCarrito.Rows.Add(dgProductos[e.ColumnIndex, e.RowIndex].ToolTipText.ToString(), Convert.ToString(producto.ExecuteScalar()));
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();

            ItemEnCarrito += 1;
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
            if (e.RowIndex == dgCarrito.NewRowIndex || e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == dgCarrito.Columns["Borrar"].Index)
            {
                dgCarrito.Rows.RemoveAt(e.RowIndex);
            }
            ActivarPedido();

        }     ////**** BORRAR INGREDIENTE
        public int ActualizarSuma()
        {
            int sumatoria = 0;

            foreach (DataGridViewRow row in dgCarrito.Rows)
            {
                sumatoria += Convert.ToInt32(row.Cells["Precio"].Value);
            }

            return sumatoria;
        }                                                                  ////**** SUMAR INGREDIENTES

        private void BtnLiquidos_Click(object sender, EventArgs e)
        {
            CargaProductosLiquidos();
        }

        private void BtnAcom_Click(object sender, EventArgs e)
        {
            CargaProductosAcomp();
        }

        private void BtnPostres_Click(object sender, EventArgs e)
        {
            CargaProductosPostres();
        }

        private void BtnOtros_Click(object sender, EventArgs e)
        {
            CargaProductosOtros();
        }

        private void BtnTodos_Click(object sender, EventArgs e)
        {
            CargaProductos();
        }
    }
}
