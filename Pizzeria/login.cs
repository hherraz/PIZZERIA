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
    public partial class login : Form
    {
        private menu m_frm;
        public List<string> dtUsuarios;

        public login(menu frm)
        {
            InitializeComponent();
            m_frm = frm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios USR = new Usuarios();
            int Found = USR.ValidarUsuario(user.Text, pass.Text);

            if(Found==1)
            {
                dtUsuarios=USR.DatosUsuario(user.Text);
                m_frm.panel3.Visible = true;
                m_frm.label2.Text = "Usuario: "+ dtUsuarios[3].ToString();
                this.Close();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrectos!");
                user.Clear();
                pass.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int cerrando = Program.cerrar();

            if (cerrando == 1)
            {
                Environment.Exit(0);
            }

        }
    }
}
