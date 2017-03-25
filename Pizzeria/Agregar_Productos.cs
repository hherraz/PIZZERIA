using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzeria
{
    public partial class Agregar_Productos : Form
    {
        public Agregar_Productos()
        {
            InitializeComponent();
        }

        Conexion conX = new Conexion();
        Imagenes imgX = new Imagenes();
        int sw = 0; //1=nuevo 2=modificar

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            sw = 1;

            btnGuardar.Visible = true;
            btnCargarFoto.Visible = true;
            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;
            txtMin.Enabled = true;
            txtMax.Enabled = true;
            Familia.Enabled = true;

            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;

            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtMin.Clear();
            txtMax.Clear();
            Familia.SelectedIndex = -1;
            pictureBox1.Image = null;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
            btnCargarFoto.Visible = false;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            txtMin.Enabled = false;
            txtMax.Enabled = false;
            Familia.Enabled = false;

            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnBorrar.Enabled = true;

            if (ValidaVacios() == 0)
            {
                //insert if nuevo
                if (sw == 1)
                {
                    conX.Abrir();
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        pictureBox1.Image.Save(ms, ImageFormat.Png);
                        byte[] imgArr = ms.ToArray();

                        MySqlCommand cmd = new MySqlCommand("INSERT INTO productos (Item, PrecioUnitario, Stock, Stock_minimo, Stock_Maximo, Familia, Imagen) VALUES (@txtnombre, @txtprecio, @Stock, @Stock_minimo, @Stock_Maximo, @Familia, @imagen)", conX.cn);
                        cmd.Parameters.AddWithValue("@txtnombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@txtprecio", Convert.ToInt32(txtPrecio.Text));
                        cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(txtStock.Text));
                        cmd.Parameters.AddWithValue("@Stock_minimo", Convert.ToInt32(txtMin.Text));
                        cmd.Parameters.AddWithValue("@Stock_Maximo", Convert.ToInt32(txtMax.Text));
                        cmd.Parameters.AddWithValue("@Familia", Convert.ToInt32(Familia.SelectedValue));
                        cmd.Parameters.AddWithValue("@imagen", imgArr);
                        cmd.ExecuteNonQuery();
                    }
                    catch(MySqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    conX.Cerrar();
                }
                //update if existente
                if (sw == 2)
                {
                    conX.Abrir();
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        pictureBox1.Image.Save(ms, ImageFormat.Png);
                        byte[] imgArr = ms.ToArray();

                        MySqlCommand cmd = new MySqlCommand("UPDATE productos SET Item=@txtNombre, PrecioUnitario=@txtPrecio, Stock=@Stock, Stock_minimo=@Stock_minimo, Stock_Maximo=@Stock_Maximo, Familia=@Familia, Imagen=@imagen WHERE IdProducto=@id;", conX.cn);
                        cmd.Parameters.AddWithValue("@txtnombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@txtprecio", Convert.ToInt32(txtPrecio.Text));
                        cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(txtStock.Text));
                        cmd.Parameters.AddWithValue("@Stock_minimo", Convert.ToInt32(txtMin.Text));
                        cmd.Parameters.AddWithValue("@Stock_Maximo", Convert.ToInt32(txtMax.Text));
                        cmd.Parameters.AddWithValue("@Familia", Convert.ToInt32(Familia.SelectedValue));
                        cmd.Parameters.AddWithValue("@imagen", imgArr);
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(IdGrid.Text));
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    conX.Cerrar();
                }
                sw = 0;
                txtNombre.Clear();
                txtPrecio.Clear();
                txtStock.Clear();
                txtMin.Clear();
                txtMax.Clear();
                Familia.SelectedIndex = -1;
                pictureBox1.Image = null;

                btnGuardar.Visible = false;
                btnCargarFoto.Visible = false;
                txtNombre.Enabled = false;
                txtPrecio.Enabled = false;
                txtStock.Enabled = false;
                txtMin.Enabled = false;
                txtMax.Enabled = false;
                Familia.Enabled = false;

                btnNuevo.Enabled = true;
                btnModificar.Enabled = true;
                btnBorrar.Enabled = true;

                FormateoIngredientes();
                PoblarIngredientes();
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            sw = 2;

            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;

            btnGuardar.Visible = true;
            btnCargarFoto.Visible = true;

            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;
            txtMin.Enabled = true;
            txtMax.Enabled = true;
            Familia.Enabled = true;
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //borrar
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CentrarPantalla()
        {
            this.Size = new Size(745, 460);
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        public void PoblarIngredientes()
        {
            conX.Abrir();
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter adap = new MySqlDataAdapter("SELECT * FROM Productos;", conX.cn);
                adap.Fill(ds, "productos");
                int x = 0;
                while (x < ds.Tables[0].Rows.Count)
                {
                    if (ds.Tables["productos"].Rows[x]["Imagen"] == DBNull.Value)
                    {
                        GridProductos.Rows.Add(ds.Tables["productos"].Rows[x]["IdProducto"].ToString(), ds.Tables["productos"].Rows[x]["Item"].ToString(), ds.Tables["productos"].Rows[x]["PrecioUnitario"].ToString(), ds.Tables["productos"].Rows[x]["Stock"].ToString(), ds.Tables["productos"].Rows[x]["Stock_minimo"].ToString(), ds.Tables["productos"].Rows[x]["Stock_Maximo"].ToString(), ds.Tables["productos"].Rows[x]["Familia"].ToString(), null);
                    }
                    else
                    {
                        byte[] imageBuffer = (byte[])ds.Tables["productos"].Rows[x]["Imagen"];
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);

                        GridProductos.Rows.Add(ds.Tables["productos"].Rows[x]["IdProducto"].ToString(), ds.Tables["productos"].Rows[x]["Item"].ToString(), ds.Tables["productos"].Rows[x]["PrecioUnitario"].ToString(), ds.Tables["productos"].Rows[x]["Stock"].ToString(), ds.Tables["productos"].Rows[x]["Stock_minimo"].ToString(), ds.Tables["productos"].Rows[x]["Stock_Maximo"].ToString(), ds.Tables["productos"].Rows[x]["Familia"].ToString(), Image.FromStream(ms));
                    }
                    x++;
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
        }
        public void FormateoIngredientes()
        {
            GridProductos.Columns.Clear();
            GridProductos.Rows.Clear();

            GridProductos.ReadOnly = true;
            GridProductos.AutoGenerateColumns = false;

            GridProductos.ColumnHeadersVisible = true;
            GridProductos.RowHeadersVisible = false;

            GridProductos.MultiSelect = false;
            GridProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridProductos.ColumnCount = 7;

            DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
            boton.HeaderText = "Seleccionar";
            boton.Name = "Seleccionar";
            boton.Text = "Seleccionar";
            boton.Tag = "Seleccionar";
            boton.UseColumnTextForButtonValue = true;

            DataGridViewImageColumn col = new DataGridViewImageColumn();
            col.HeaderText = "Imagen";
            col.Name = "Imagen";
            col.Tag = "Imagen";
            col.DefaultCellStyle.NullValue = imgX.resizeImage(Pizzeria.Properties.Resources.EMPTY, new Size(100, 100));

            GridProductos.Columns[0].Name = "Id";
            GridProductos.Columns[1].Name = "Nombre Ingrediente";
            GridProductos.Columns[2].Name = "Precio";
            GridProductos.Columns[3].Name = "Stock";
            GridProductos.Columns[4].Name = "Stock\nMinimo";
            GridProductos.Columns[5].Name = "Stock\nMaximo";
            GridProductos.Columns[6].Name = "Familia";
            GridProductos.Columns.Add(col);
            GridProductos.Columns.Add(boton);

            GridProductos.Columns[0].Width = 40;
            GridProductos.Columns[1].Width = 190;
            GridProductos.Columns[2].Width = 40;
            GridProductos.Columns[3].Width = 40;
            GridProductos.Columns[4].Width = 40;
            GridProductos.Columns[5].Width = 40;
            GridProductos.Columns[6].Width = 80;
            GridProductos.Columns[7].Width = 120;
            GridProductos.Columns[8].Width = 92;

            GridProductos.AllowUserToAddRows = false;
            GridProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            GridProductos.DefaultCellStyle.Font = new Font("Arial", 9);

        }

        private void Agregar_Ingredientes_Load(object sender, EventArgs e)
        {
            CentrarPantalla();
            FormateoIngredientes();
            PoblarIngredientes();
            PoblarFamilia();
        }

        public void PoblarFamilia()
        {
            conX.Abrir();
            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter("select * from familiasproductos;", conX.cn);
                adapt.Fill(dt);
                Familia.DataSource = dt;
                Familia.ValueMember = "IdFamilia";
                Familia.DisplayMember = "NombreFamilia";
                Familia.SelectedIndex = -1;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conX.Cerrar();
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Image image = imgX.resizeImage(Image.FromFile(dialog.FileName), new Size(120, 120));
                pictureBox1.Image = image;
            }
        }

        public int ValidaVacios()
        {
            if (txtNombre.TextLength == 0)
            {
                MessageBox.Show("ERROR - CAMPO NOMBRE VACIO.\nCORRIJALO E INTENTE DE NUEVO.");
                return 1;
            }
            else if (txtPrecio.TextLength == 0)
            {
                MessageBox.Show("ERROR - CAMPO PRECIO VACIO.\nCORRIJALO E INTENTE DE NUEVO.");
                return 1;
            }
            else if (txtStock.TextLength == 0)
            {
                MessageBox.Show("ERROR - CAMPO STOCK VACIO.\nCORRIJALO E INTENTE DE NUEVO.");
                return 1;
            }
            else if (txtMin.TextLength == 0)
            {
                MessageBox.Show("ERROR - CAMPO STOCK MINIMO VACIO.\nCORRIJALO E INTENTE DE NUEVO.");
                return 1;
            }
            else if (txtMax.TextLength == 0)
            {
                MessageBox.Show("ERROR - CAMPO STOCK MAXIMO VACIO.\nCORRIJALO E INTENTE DE NUEVO.");
                return 1;
            }
            else if (Familia.SelectedIndex == -1)
            {
                MessageBox.Show("ERROR - CAMPO FAMILIA VACIO.\nCORRIJALO E INTENTE DE NUEVO.");
                return 1;
            }
            else if (pictureBox1.Image==null)
            {
                MessageBox.Show("ERROR - NO SE HA CARGADO NINGUNA IMAGEN.\nCORRIJALO E INTENTE DE NUEVO.");
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void GridIngredientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdGrid.Text = Convert.ToString(GridProductos.CurrentRow.Cells[0].Value);
            txtNombre.Text= Convert.ToString(GridProductos.CurrentRow.Cells[1].Value);
            txtPrecio.Text= Convert.ToString(GridProductos.CurrentRow.Cells[2].Value);
            txtStock.Text = Convert.ToString(GridProductos.CurrentRow.Cells[3].Value); ;
            txtMin.Text = Convert.ToString(GridProductos.CurrentRow.Cells[4].Value); ;
            txtMax.Text = Convert.ToString(GridProductos.CurrentRow.Cells[5].Value); ;
            Familia.SelectedValue = Convert.ToString(GridProductos.CurrentRow.Cells[6].Value); ;
            pictureBox1.Image = CargarImagen(Convert.ToInt32(IdGrid.Text));
        }

        public Image CargarImagen(int Id)
        {
            using (MySqlConnection conn = conX.cn)
            {
                Image img;
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conX.Abrir();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Imagen FROM productos WHERE IdProducto = @Id";
                    cmd.Parameters.AddWithValue("@Id", Id);
                    

                    if (cmd.ExecuteScalar() != DBNull.Value)
                    {
                        byte[] imgArr = (byte[])cmd.ExecuteScalar();
                        imgArr = (byte[])cmd.ExecuteScalar();
                        using (var stream = new MemoryStream(imgArr))
                        {
                            img = Image.FromStream(stream);
                        }
                    }
                    else
                    {
                        conX.Cerrar();
                        return null;
                    }
                    conX.Cerrar();
                    return img;
                    }
                }
            }
        }
}
