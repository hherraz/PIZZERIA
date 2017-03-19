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
        /// 

        //public static List<string> dtUsuarios;
        //public static Label lbl_titulo;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            login log = new login();
            log.TopMost = true;
            log.ShowDialog();
            if (log.DialogResult == DialogResult.OK)
            {
                Application.Run(new menu());
            }
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
