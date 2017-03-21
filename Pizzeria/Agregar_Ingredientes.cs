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
    public partial class Agregar_Ingredientes : Form
    {
        public Agregar_Ingredientes()
        {
            InitializeComponent();
        }

        conexion conX = new conexion();
        Imagenes imgX = new Imagenes();
        int sw = 0; //1=nuevo 2=modificar

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            sw = 1;

            btnGuardar.Visible = true;
            btnCargarFoto.Visible = true;
            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;

            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;

            txtNombre.Clear();
            txtPrecio.Clear();
            pictureBox1.Image = null;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
            btnCargarFoto.Visible = false;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;

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

                        MySqlCommand cmd = new MySqlCommand("INSERT INTO ingredientes (NombreIngrediente, PrecioIngrediente, Imagen) VALUES (@txtnombre, @txtprecio, @imagen)", conX.cn);
                        cmd.Parameters.AddWithValue("@txtnombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@txtprecio", Convert.ToInt32(txtPrecio.Text));
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

                        MySqlCommand cmd = new MySqlCommand("UPDATE ingredientes SET NombreIngrediente=@txtNombre, PrecioIngrediente=@txtPrecio, Imagen=@imagen WHERE IdIngrediente=@id;", conX.cn);
                        cmd.Parameters.AddWithValue("@txtnombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@txtprecio", Convert.ToInt32(txtPrecio.Text));
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
                pictureBox1.Image = null;

                btnGuardar.Visible = false;
                btnCargarFoto.Visible = false;
                txtNombre.Enabled = false;
                txtPrecio.Enabled = false;

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
            this.Size = new Size(531, 460);
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        public void PoblarIngredientes()
        {
            conX.Abrir();
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter adap = new MySqlDataAdapter("SELECT IdIngrediente, NombreIngrediente, PrecioIngrediente, Imagen FROM ingredientes;", conX.cn);
                adap.Fill(ds, "Ingredientes");
                int x = 0;
                while (x < ds.Tables[0].Rows.Count)
                {
                    if (ds.Tables["Ingredientes"].Rows[x]["Imagen"].ToString() == "")
                    {
                        GridIngredientes.Rows.Add(ds.Tables["Ingredientes"].Rows[x]["IdIngrediente"].ToString(), ds.Tables["Ingredientes"].Rows[x]["NombreIngrediente"].ToString(), ds.Tables["Ingredientes"].Rows[x]["PrecioIngrediente"].ToString(), null);
                    }
                    else
                    {
                        byte[] imageBuffer = (byte[])ds.Tables["Ingredientes"].Rows[x]["Imagen"];
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);

                        GridIngredientes.Rows.Add(ds.Tables["Ingredientes"].Rows[x]["IdIngrediente"].ToString(), ds.Tables["Ingredientes"].Rows[x]["NombreIngrediente"].ToString(), ds.Tables["Ingredientes"].Rows[x]["PrecioIngrediente"].ToString(), Image.FromStream(ms));
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
            GridIngredientes.Columns.Clear();
            GridIngredientes.Rows.Clear();

            GridIngredientes.ReadOnly = true;
            GridIngredientes.AutoGenerateColumns = false;

            GridIngredientes.ColumnHeadersVisible = true;
            GridIngredientes.RowHeadersVisible = false;

            GridIngredientes.MultiSelect = false;
            GridIngredientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridIngredientes.ColumnCount = 3;

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

            GridIngredientes.Columns[0].Name = "Id";
            GridIngredientes.Columns[1].Name = "Nombre Ingrediente";
            GridIngredientes.Columns[2].Name = "Precio";
            GridIngredientes.Columns.Add(col);
            GridIngredientes.Columns.Add(boton);

            GridIngredientes.Columns[0].Width = 40;
            GridIngredientes.Columns[1].Width = 190;
            GridIngredientes.Columns[2].Width = 40;
            GridIngredientes.Columns[3].Width = 120;
            GridIngredientes.Columns[4].Width = 92;

            GridIngredientes.AllowUserToAddRows = false;
            GridIngredientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            GridIngredientes.DefaultCellStyle.Font = new Font("Arial", 9);

        }

        private void Agregar_Ingredientes_Load(object sender, EventArgs e)
        {
            CentrarPantalla();
            FormateoIngredientes();
            PoblarIngredientes();
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
            IdGrid.Text = Convert.ToString(GridIngredientes.CurrentRow.Cells[0].Value);
            
            txtNombre.Text= Convert.ToString(GridIngredientes.CurrentRow.Cells[1].Value);
            txtPrecio.Text= Convert.ToString(GridIngredientes.CurrentRow.Cells[2].Value);
            pictureBox1.Image = CargarImagen(Convert.ToInt32(IdGrid.Text));
        }

        public Image CargarImagen(int Id)
        {
            using (MySqlConnection conn = conX.cn)
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conX.Abrir();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Imagen FROM ingredientes WHERE IdIngrediente = @Id";
                    cmd.Parameters.AddWithValue("@Id", Id);

                    byte[] imgArr = (byte[])cmd.ExecuteScalar();
                    imgArr = (byte[])cmd.ExecuteScalar();

                    conX.Cerrar();

                    using (var stream = new MemoryStream(imgArr))
                    {
                        Image img = Image.FromStream(stream);
                        return img;
                    }
                }
            }
        }
    }
}
