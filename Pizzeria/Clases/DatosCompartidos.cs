using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    public class DatosCompartidos
    {
        private static DatosCompartidos oInstance;
        
        protected DatosCompartidos()
        {

        }

        public static DatosCompartidos Instance()
        {
            if (oInstance == null)
            {
                oInstance = new DatosCompartidos();
            }
            return oInstance;
        }

        public string Usuario { get; set; }

        public List<string> dtUsuarios { get; set; }

        public string NombreFormularioActivo { get; set; }

        public int PagarPedido { get; set; }
        public int Pagado { get; set; }
        public int PagoInmediato { get; set; }

    }
}
