using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzeria
{
    class Imagenes
    {
        conexion conX = new conexion();

        public Image CargarImagen()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                return Image.FromFile(dialog.FileName);
            }
            else
            {
                return null;
            }
        }

        public void GuardarImagenMySql(string BaseDatos, int Id, Image img)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                MySqlCommand cmd = new MySqlCommand("INSERT INTO @Base VALUES (@image) WHERE id=@id;",conX.cn);
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@Base", BaseDatos);
                cmd.Parameters.AddWithValue("@image", ms.GetBuffer());

                conX.Abrir();
                cmd.ExecuteNonQuery();
                conX.Cerrar();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Image resizeImage(Image imgToResize, Size size)                                   ////**** CAMBIA EL TAMANO DE LA IMAGEN
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
    }
}
