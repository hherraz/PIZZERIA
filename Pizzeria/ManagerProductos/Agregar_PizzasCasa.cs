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
    public partial class Agregar_PizzasCasa : Form
    {
        public Agregar_PizzasCasa()
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
            txtPrecioIndividual.Enabled = true;
            txtPrecioMediana.Enabled = true;
            txtPrecioFamiliar.Enabled = true;
            txtPrecioXL.Enabled = true;

            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;

            txtNombre.Clear();
            txtPrecioIndividual.Clear();
            txtPrecioMediana.Clear();
            txtPrecioFamiliar.Clear();
            txtPrecioXL.Clear();
            pictureBox1.Image = null;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
            btnCargarFoto.Visible = false;
            txtNombre.Enabled = false;
            txtPrecioIndividual.Enabled = false;
            txtPrecioMediana.Enabled = false;
            txtPrecioFamiliar.Enabled = false;
            txtPrecioXL.Enabled = false;
            txtDesc.Enabled = false;

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

                        MySqlCommand cmd = new MySqlCommand("INSERT INTO productos (Item, PrecioIndividual, PrecioMediana, PrecioFamiliar, PrecioXL, Detalle, Imagen) VALUES (@txtnombre, @txtprecio, @Stock, @Stock_minimo, @Stock_Maximo, @detalle, @imagen)", conX.cn);
                        cmd.Parameters.AddWithValue("@txtnombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@txtprecio", Convert.ToInt32(txtPrecioIndividual.Text));
                        cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(txtPrecioMediana.Text));
                        cmd.Parameters.AddWithValue("@Stock_minimo", Convert.ToInt32(txtPrecioFamiliar.Text));
                        cmd.Parameters.AddWithValue("@Stock_Maximo", Convert.ToInt32(txtPrecioXL.Text));
                        cmd.Parameters.AddWithValue("@detalle", txtDesc.Text);
                        cmd.Parameters.AddWithValue("@imagen", imgArr);
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
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

                        MySqlCommand cmd = new MySqlCommand("UPDATE pizzacasa SET Item=@txtNombre, PrecioIndividual=@txtPrecio, PrecioMediana=@Stock, PrecioFamiliar=@Stock_minimo, PrecioXL=@Stock_Maximo, Detalle=@desc, Imagen=@imagen WHERE id=@id;", conX.cn);
                        cmd.Parameters.AddWithValue("@txtnombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@txtprecio", Convert.ToInt32(txtPrecioIndividual.Text));
                        cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(txtPrecioMediana.Text));
                        cmd.Parameters.AddWithValue("@Stock_minimo", Convert.ToInt32(txtPrecioFamiliar.Text));
                        cmd.Parameters.AddWithValue("@Stock_Maximo", Convert.ToInt32(txtPrecioXL.Text));
                        cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
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
                txtPrecioIndividual.Clear();
                txtPrecioMediana.Clear();
                txtPrecioFamiliar.Clear();
                txtPrecioXL.Clear();
                txtDesc.Clear();
                pictureBox1.Image = null;

                btnGuardar.Visible = false;
                btnCargarFoto.Visible = false;
                txtNombre.Enabled = false;
                txtPrecioIndividual.Enabled = false;
                txtPrecioMediana.Enabled = false;
                txtPrecioFamiliar.Enabled = false;
                txtPrecioXL.Enabled = false;
                txtDesc.Enabled = false;

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
            txtPrecioIndividual.Enabled = true;
            txtPrecioMediana.Enabled = true;
            txtPrecioFamiliar.Enabled = true;
            txtPrecioXL.Enabled = true;
            txtDesc.Enabled = true;
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
            this.Size = new Size(709, 440);
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        public void PoblarIngredientes()
        {
            conX.Abrir();
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter adap = new MySqlDataAdapter("SELECT * FROM pizzacasa;", conX.cn);
                adap.Fill(ds, "pizzacasa");
                int x = 0;
                while (x < ds.Tables[0].Rows.Count)
                {
                    if (ds.Tables["pizzacasa"].Rows[x]["Imagen"] == DBNull.Value)
                    {
                        Gridpizzacasa.Rows.Add(ds.Tables["pizzacasa"].Rows[x]["Id"].ToString(), ds.Tables["pizzacasa"].Rows[x]["Item"].ToString(), ds.Tables["pizzacasa"].Rows[x]["PrecioIndividual"].ToString(), ds.Tables["pizzacasa"].Rows[x]["PrecioMediana"].ToString(), ds.Tables["pizzacasa"].Rows[x]["PrecioFamiliar"].ToString(), ds.Tables["pizzacasa"].Rows[x]["PrecioXL"].ToString(), null);
                    }
                    else
                    {
                        byte[] imageBuffer = (byte[])ds.Tables["pizzacasa"].Rows[x]["Imagen"];
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);

                        Gridpizzacasa.Rows.Add(ds.Tables["pizzacasa"].Rows[x]["Id"].ToString(), ds.Tables["pizzacasa"].Rows[x]["Item"].ToString(), ds.Tables["pizzacasa"].Rows[x]["PrecioIndividual"].ToString(), ds.Tables["pizzacasa"].Rows[x]["PrecioMediana"].ToString(), ds.Tables["pizzacasa"].Rows[x]["PrecioFamiliar"].ToString(), ds.Tables["pizzacasa"].Rows[x]["PrecioXL"].ToString(), Image.FromStream(ms));
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
            Gridpizzacasa.Columns.Clear();
            Gridpizzacasa.Rows.Clear();

            Gridpizzacasa.ReadOnly = true;
            Gridpizzacasa.AutoGenerateColumns = false;

            Gridpizzacasa.ColumnHeadersVisible = true;
            Gridpizzacasa.RowHeadersVisible = false;

            Gridpizzacasa.MultiSelect = false;
            Gridpizzacasa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Gridpizzacasa.ColumnCount = 6;

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

            Gridpizzacasa.Columns[0].Name = "Id";
            Gridpizzacasa.Columns[1].Name = "Nombre de la Pizza";
            Gridpizzacasa.Columns[2].Name = "Precio Individual";
            Gridpizzacasa.Columns[3].Name = "Precio Mediana";
            Gridpizzacasa.Columns[4].Name = "Precio Familiar";
            Gridpizzacasa.Columns[5].Name = "Precio XL";
            Gridpizzacasa.Columns.Add(col);
            Gridpizzacasa.Columns.Add(boton);

            Gridpizzacasa.Columns[0].Width = 30;
            Gridpizzacasa.Columns[1].Width = 150;
            Gridpizzacasa.Columns[2].Width = 50;
            Gridpizzacasa.Columns[3].Width = 50;
            Gridpizzacasa.Columns[4].Width = 50;
            Gridpizzacasa.Columns[5].Width = 50;
            Gridpizzacasa.Columns[6].Width = 120;
            Gridpizzacasa.Columns[7].Width = 92;

            Gridpizzacasa.AllowUserToAddRows = false;
            Gridpizzacasa.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            Gridpizzacasa.DefaultCellStyle.Font = new Font("Arial", 9);

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
            else if (txtPrecioIndividual.TextLength == 0)
            {
                MessageBox.Show("ERROR - CAMPO PRECIO VACIO.\nCORRIJALO E INTENTE DE NUEVO.");
                return 1;
            }
            else if (txtPrecioMediana.TextLength == 0)
            {
                MessageBox.Show("ERROR - CAMPO STOCK VACIO.\nCORRIJALO E INTENTE DE NUEVO.");
                return 1;
            }
            else if (txtPrecioFamiliar.TextLength == 0)
            {
                MessageBox.Show("ERROR - CAMPO STOCK MINIMO VACIO.\nCORRIJALO E INTENTE DE NUEVO.");
                return 1;
            }
            else if (txtPrecioXL.TextLength == 0)
            {
                MessageBox.Show("ERROR - CAMPO STOCK MAXIMO VACIO.\nCORRIJALO E INTENTE DE NUEVO.");
                return 1;
            }
            else if (pictureBox1.Image == null)
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
            IdGrid.Text = Convert.ToString(Gridpizzacasa.CurrentRow.Cells[0].Value);
            txtNombre.Text = Convert.ToString(Gridpizzacasa.CurrentRow.Cells[1].Value);
            txtPrecioIndividual.Text = Convert.ToString(Gridpizzacasa.CurrentRow.Cells[2].Value);
            txtPrecioMediana.Text = Convert.ToString(Gridpizzacasa.CurrentRow.Cells[3].Value);
            txtPrecioFamiliar.Text = Convert.ToString(Gridpizzacasa.CurrentRow.Cells[4].Value);
            txtPrecioXL.Text = Convert.ToString(Gridpizzacasa.CurrentRow.Cells[5].Value);
            txtDesc.Text = CargarDetalle(Convert.ToInt32(IdGrid.Text));
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
                    cmd.CommandText = "SELECT Imagen FROM pizzacasa WHERE id = @Id";
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

        public string CargarDetalle(int Id)
        {
            using (MySqlConnection conn = conX.cn)
            {
                string detalle;
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conX.Abrir();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Detalle FROM pizzacasa WHERE id = @Id";
                    cmd.Parameters.AddWithValue("@Id", Id);
                    detalle = Convert.ToString(cmd.ExecuteScalar());
                    conX.Cerrar();
                    return detalle;
                }
            }
        }
    }
}
