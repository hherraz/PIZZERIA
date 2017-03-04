using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzeria
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static int cerrar()
        {
            DialogResult result = MessageBox.Show("Esta Seguro que desea salir de la Aplicación?", "Salir", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                return 1; //cerrar la aplicacion
            }
            else
            {
                return 0; //no hacer nada
            }
        }
    }
}
