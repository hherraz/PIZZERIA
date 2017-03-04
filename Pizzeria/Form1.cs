using System;
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
    public partial class Form1 : Form
    {
        public int contador=0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            BackColor = Color.Gray;
            TransparencyKey = Color.Gray;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Hide();
            this.Close();
            this.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            menu mnu = new menu();
            mnu.ShowDialog();
            mnu.Dispose();
        }
    }
}
