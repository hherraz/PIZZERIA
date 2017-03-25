using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzeria
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Usuarios USR = new Usuarios();
            int Found = USR.ValidarUsuario(user.Text, pass.Text);

            if(Found==1)
            {
                Console.WriteLine("USUARIO LOGEADO CORRECTAMENTE");
                DatosCompartidos.Instance().dtUsuarios= USR.DatosUsuario(user.Text);
                DatosCompartidos.Instance().Usuario= "Usuario: " + DatosCompartidos.Instance().dtUsuarios[3].ToString();

                //Program.dtUsuarios=USR.DatosUsuario(user.Text);
                //Program.lbl_titulo.Text = "Usuario: " + Program.dtUsuarios[3].ToString();

                //llamada del procedimiento almacenado
                USR.log(user.Text);
                this.Close();
                this.Dispose();
                this.DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrectos!");
                user.Clear();
                pass.Clear();
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {

            int cerrando = Program.cerrar();

            if (cerrando == 1)
            {
                Environment.Exit(0);
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            SplashScreen sp = new SplashScreen();
            sp.ShowDialog();
        }
    }
}
