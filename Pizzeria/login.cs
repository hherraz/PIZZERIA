﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public login(menu frm)
        {
            InitializeComponent();
            m_frm = frm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(user.Text=="DEMO" && pass.Text=="123")
            {
                m_frm.panel3.Visible = true;
                m_frm.label2.Text = "Usuario: "+user.Text;
                //menu mnu = new menu();
                //mnu.label2.Text = user.Text;
                //mnu.panel3.Visible = true;
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
            Application.Exit();
        }
    }
}
