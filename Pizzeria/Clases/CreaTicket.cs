using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzeria
{
    // La clase "CreaTicket" tiene varios metodos para imprimir con diferentes formatos (izquierda, derecha, centrado, desripcion precio,etc), a
    // continuacion se muestra el metodo con ejemplo de parametro que acepta, longitud maxima y un ejemplo de como imprimira, esta clase esta 
    // basada en una impresora Epson de matriz de puntos con impresion maxima de 32 caracteres por renglon
    // METODO                                      MAX_LONG                        EJEMPLOS
    //--------------------------------------------------------------------------------------------------------------------------
    // TextoIzquierda("Empleado 1")                    32                      Empleado 1      
    // TextoDerecha("Caja 1")                          32                                                        Caja 1
    // TextoCentro("Ticket")                           32                                         Ticket   
    // TextoExtremos("Fecha 6/1/2011","Hora:13:25")     14 y 14                 Fecha 6/1/2011                Hora:13:25
    // EncabezadoVenta()                                n/a                     Articulo        Can    P.Unit    Importe
    // LineasGuion()                                    n/a                     ----------------------------------------
    // AgregaArticulo("Aspirina","2",45.25,90.5)        16,3,10,11              Aspirina          2    $45.25     $90.50
    // LineasTotales()                                  n/a                                                ----------
    // AgregaTotales("Subtotal",235.25)                 19 y 15                 Subtotal                         $235.25
    // LineasAsterisco()                                n/a                     ****************************************
    // LineasIgual()                                    n/a                     ========================================
    // CortaTicket()
    // AbreCajon()

    class CreaTicket
    {
        string ticket = "";
        string parte1, parte2;
        string impresora = "CAJA";                                   // nombre exacto de la impresora como esta en el panel de control
        int max, cort;

#region TICKETS DE COCINA
        public void TicketConsumoCocina(DataTable items, string pedido, string garzon, string mesa)
        {
            CreaTicket Ticket1 = new CreaTicket();

            Ticket1.AbreCajon();                                                            //abre el cajon
            Ticket1.TextoCentro("COMANDA COCINA");                                          // imprime en el centro "Venta mostrador"
            Ticket1.LineasAsterisco();                                                          // imprime una linea de guiones
            Ticket1.TextoExtremos("CONSUMO", "PEDIDO: "+ pedido.ToString());
            Ticket1.TextoExtremos(garzon, "MESA: " + mesa.ToString());
            Ticket1.LineasAsterisco();                                                          // imprime una linea de guiones
            Ticket1.EncabezadoVenta();                                                      // imprime encabezados
            Ticket1.LineasGuion();                                                          // imprime una linea de guiones
            foreach(DataRow row in items.Rows)
            {
                try
                {
                    Ticket1.AgregaArticuloCocina(Convert.ToString(row[1]), Convert.ToInt32(row[0]));                            //imprime una linea de descripcion
                    Ticket1.LineasGuion();                                                                                      // imprime una linea de guiones
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            Ticket1.TextoCentro(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            Ticket1.CortaTicket();                                                          // corta el ticket
        }
        public void TicketRetiroCocina(DataTable items, string pedido, string nombre, string telefono)
        {
            CreaTicket Ticket1 = new CreaTicket();

            Ticket1.AbreCajon();                                                            //abre el cajon
            Ticket1.TextoCentro("COMANDA COCINA");                                          // imprime en el centro "Venta mostrador"
            Ticket1.LineasAsterisco();                                                          // imprime una linea de guiones
            Ticket1.TextoExtremos("RETIRO", "PEDIDO: " + pedido.ToString());
            Ticket1.TextoCentro(nombre);
            Ticket1.TextoCentro("F: " + telefono);
            Ticket1.LineasAsterisco();                                                          // imprime una linea de guiones
            Ticket1.EncabezadoVenta();                                                      // imprime encabezados
            Ticket1.LineasGuion();                                                          // imprime una linea de guiones
            foreach (DataRow row in items.Rows)
            {
                try
                {
                    Ticket1.AgregaArticuloCocina(Convert.ToString(row[1]), Convert.ToInt32(row[0]));                            //imprime una linea de descripcion
                    Ticket1.LineasGuion();                                                                                      // imprime una linea de guiones
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            Ticket1.TextoCentro(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            Ticket1.CortaTicket();                                                          // corta el ticket
        }
        public void TicketDeliveryCocina(DataTable items, string pedido, string nombre, string telefono, string direccion, string referencia)
        {
            CreaTicket Ticket1 = new CreaTicket();

            Ticket1.AbreCajon();                                                            //abre el cajon
            Ticket1.TextoCentro("COMANDA COCINA");                                          // imprime en el centro "Venta mostrador"
            Ticket1.LineasAsterisco();                                                          // imprime una linea de guiones
            Ticket1.TextoExtremos("DELIVERY", "PEDIDO: " + pedido.ToString());
            Ticket1.LineasIgual();
            Ticket1.TextoCentro(nombre);
            Ticket1.TextoCentro("F: " + telefono);
            Ticket1.TextoCentro(direccion);
            Ticket1.TextoCentro(referencia);
            Ticket1.LineasAsterisco();                                                          // imprime una linea de guiones
            Ticket1.EncabezadoVenta();                                                      // imprime encabezados
            Ticket1.LineasGuion();                                                          // imprime una linea de guiones
            foreach (DataRow row in items.Rows)
            {
                try
                {
                    Ticket1.AgregaArticuloCocina(Convert.ToString(row[1]), Convert.ToInt32(row[0]));                            //imprime una linea de descripcion
                    Ticket1.LineasGuion();                                                                                      // imprime una linea de guiones
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            Ticket1.TextoCentro(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            Ticket1.CortaTicket();                                                          // corta el ticket
        }
        #endregion

        #region TICKETS DE VENTA
        public void TicketConsumo(DataTable items, string pedido, string garzon, string mesa, double total)
        {
            CreaTicket Ticket1 = new CreaTicket();

            Ticket1.AbreCajon();                                                            //abre el cajon
            Ticket1.TextoCentro("COMPROBANTE CAJA");                                          // imprime en el centro "Venta mostrador"
            Ticket1.LineasAsterisco();                                                          // imprime una linea de guiones
            Ticket1.TextoExtremos("CONSUMO", "PEDIDO: " + pedido.ToString());
            Ticket1.TextoExtremos(garzon, "MESA: " + mesa.ToString());
            Ticket1.LineasAsterisco();                                                          // imprime una linea de guiones
            Ticket1.EncabezadoVenta();                                                      // imprime encabezados
            foreach (DataRow row in items.Rows)
            {
                try
                {
                    Ticket1.LineasGuion();                                                                                      // imprime una linea de guiones
                    Ticket1.AgregaArticulo(Convert.ToString(row[1]), Convert.ToInt32(row[0]), Convert.ToDouble(row[2]), Convert.ToDouble(row[3]));                            //imprime una linea de descripcion
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            /// agregar total
            Ticket1.LineasTotales();
            Ticket1.AgregaTotales("Total", total);
            //Ticket1.LineasGuion();                                                                                      // imprime una linea de guiones
            Ticket1.TextoCentro("");
            Ticket1.TextoCentro(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            Ticket1.CortaTicket();                                                          // corta el ticket
        }
        public void TicketRetiro(DataTable items, string pedido, string nombre, string telefono, double total)
        {
            CreaTicket Ticket1 = new CreaTicket();

            Ticket1.AbreCajon();                                                            //abre el cajon
            Ticket1.TextoCentro("COMPROBANTE CAJA");                                          // imprime en el centro "Venta mostrador"
            Ticket1.LineasAsterisco();                                                          // imprime una linea de guiones
            Ticket1.TextoExtremos("RETIRO", "PEDIDO: " + pedido.ToString());
            Ticket1.TextoCentro(nombre);
            Ticket1.TextoCentro("F: " + telefono);
            Ticket1.LineasAsterisco();                                                          // imprime una linea de guiones
            Ticket1.EncabezadoVenta();                                                      // imprime encabezados
            Ticket1.LineasGuion();                                                          // imprime una linea de guiones
            foreach (DataRow row in items.Rows)
            {
                try
                {
                    Ticket1.LineasGuion();                                                                                      // imprime una linea de guiones
                    Ticket1.AgregaArticulo(Convert.ToString(row[1]), Convert.ToInt32(row[0]), Convert.ToDouble(row[2]), Convert.ToDouble(row[3]));                        //imprime una linea de descripcion
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            /// agregar total
            Ticket1.LineasTotales();
            Ticket1.AgregaTotales("Total", total);
            //Ticket1.LineasGuion();                                                                                      // imprime una linea de guiones
            Ticket1.TextoCentro("");
            Ticket1.TextoCentro(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            Ticket1.CortaTicket();                                                          // corta el ticket
        }
        public void TicketDelivery(DataTable items, string pedido, string nombre, string telefono, string direccion, string referencia, double total)
        {
            CreaTicket Ticket1 = new CreaTicket();

            Ticket1.AbreCajon();                                                            //abre el cajon
            Ticket1.TextoCentro("COMPROBANTE CAJA");                                          // imprime en el centro "Venta mostrador"
            Ticket1.LineasAsterisco();                                                          // imprime una linea de guiones
            Ticket1.TextoExtremos("DELIVERY", "PEDIDO: " + pedido.ToString());
            Ticket1.LineasIgual();
            Ticket1.TextoCentro(nombre);
            Ticket1.TextoCentro("F: " + telefono);
            Ticket1.TextoCentro(direccion);
            Ticket1.TextoCentro(referencia);
            Ticket1.LineasAsterisco();                                                          // imprime una linea de guiones
            Ticket1.EncabezadoVenta();                                                      // imprime encabezados
            foreach (DataRow row in items.Rows)
            {
                try
                {
                    Ticket1.LineasGuion();
                    Ticket1.AgregaArticulo(Convert.ToString(row[1]), Convert.ToInt32(row[0]), Convert.ToDouble(row[2]), Convert.ToDouble(row[3]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            /// agregar total
            Ticket1.LineasTotales();
            Ticket1.AgregaTotales("Total", total);
            //Ticket1.LineasGuion();                                                                                      // imprime una linea de guiones
            Ticket1.TextoCentro("");
            Ticket1.TextoCentro(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            Ticket1.CortaTicket();                                                         // corta el ticket
        }
        #endregion

        #region Clase para generar ticket
        public void LineasGuion()
        {
            ticket = "--------------------------------\n";   // agrega lineas separadoras -
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
        }
        public void LineasAsterisco()
        {
            ticket = "********************************\n";   // agrega lineas separadoras *
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
        }
        public void LineasIgual()
        {
            ticket = "================================\n";   // agrega lineas separadoras =
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
        }
        public void LineasTotales()
        {
            ticket = "                     -----------\n"; ;   // agrega lineas de total
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
        }
        public void EncabezadoVenta()
        {
            ticket = "Detalle:\n";   // agrega lineas de  encabezados
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void TextoIzquierda(string par1)                      // agrega texto a la izquierda
        {
            max = par1.Length;
            if (max > 32)                                            // **********
            {
                cort = max - 32;
                parte1 = par1.Remove(32, cort);                      // si es mayor que 32 caracteres, lo corta
            }
            else { parte1 = par1; }                                  // **********
            ticket = parte1 + "\n";
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void TextoDerecha(string par1)
        {
            ticket = "";
            max = par1.Length;
            if (max > 32)                                            // **********
            {
                cort = max - 32;
                parte1 = par1.Remove(32, cort);                      // si es mayor que 32 caracteres, lo corta
            }
            else { parte1 = par1; }                                  // **********
            max = 32 - par1.Length;                                  // obtiene la cantidad de espacios para llegar a 32
            for (int i = 0; i < max; i++)
            {
                ticket += " ";                                       // agrega espacios para alinear a la derecha
            }
            ticket += parte1 + "\n";                                 //Agrega el texto
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void TextoCentro(string par1)
        {
            ticket = "";
            max = par1.Length;
            if (max > 32)                                // **********
            {
                cort = max - 32;
                parte1 = par1.Remove(32, cort);          // si es mayor que 32 caracteres, lo corta
            }
            else { parte1 = par1; }                      // **********
            max = (int)(32 - parte1.Length) / 2;         // saca la cantidad de espacios libres y divide entre dos
            for (int i = 0; i < max; i++)                // **********
            {
                ticket += " ";                           // Agrega espacios antes del texto a centrar
            }                                            // **********
            ticket += parte1 + "\n";
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void TextoExtremos(string par1, string par2)
        {
            max = par1.Length;
            if (max > 14)                                // **********
            {
                cort = max - 14;
                parte1 = par1.Remove(14, cort);          // si par1 es mayor que 14 lo corta
            }
            else { parte1 = par1; }                      // **********
            ticket = parte1;                             // agrega el primer parametro
            max = par2.Length;
            if (max > 14)                                // **********
            {
                cort = max - 14;
                parte2 = par2.Remove(14, cort);          // si par2 es mayor que 14 lo corta
            }
            else { parte2 = par2; }
            max = 32 - (parte1.Length + parte2.Length);
            for (int i = 0; i < max; i++)                // **********
            {
                ticket += " ";                           // Agrega espacios para poner par2 al final
            }                                            // **********
            ticket += parte2 + "\n";                     // agrega el segundo parametro al final
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void AgregaTotales(string par1, double total)
        {
            max = par1.Length;
            if (max > 19)                                 // **********
            {
                cort = max - 19;
                parte1 = par1.Remove(19, cort);          // si es mayor que 19 lo corta
            }
            else { parte1 = par1; }                      // **********
            ticket = parte1;
            parte2 = total.ToString("c");
            max = 32 - (parte1.Length + parte2.Length);
            for (int i = 0; i < max; i++)                // **********
            {
                ticket += " ";                           // Agrega espacios para poner el valor de moneda al final
            }                                            // **********
            ticket += parte2 + "\n";
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void AgregaArticulo(string par1, int cant, double precio, double total)
        {
            par1 = Convert.ToString(cant) + " x " + par1;
            if (par1.ToString().Length != 0) // valida que el detalle no sea cero
            {
                max = par1.Length;
                if (max > 16)                                 // **********
                {
                    parte1 = WordWrap(par1, 32);
                }
                else
                {
                    parte1 = par1;
                }                                            // **********
                ticket = parte1;                             // agrega articulo
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
                TextoExtremos(Convert.ToString(precio), Convert.ToString(total));
            }
            else
            {
                MessageBox.Show("Valores fuera de rango");
                RawPrinterHelper.SendStringToPrinter(impresora, "Error, valor fuera de rango\n"); // imprime texto
            }
        }
        public void AgregaArticuloCocina(string par1, int cant)
        {
            par1 = Convert.ToString(cant) + " x " + par1;
            if (par1.ToString().Length !=0) // valida que el detalle no sea cero
            {
                max = par1.Length;
                if (max > 16)                                 // **********
                {
                    parte1 = WordWrap(par1,32);
                }
                else
                {
                    parte1 = par1;
                }                                            // **********
                ticket = parte1;                             // agrega articulo
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            else
            {
                MessageBox.Show("Valores fuera de rango");
                RawPrinterHelper.SendStringToPrinter(impresora, "Error, valor fuera de rango\n"); // imprime texto
            }
        }
        public void CortaTicket()
        {
            string avance = (char)0x1B + "d" + 7;                       // avanza 7 renglones
            RawPrinterHelper.SendStringToPrinter(impresora, avance);    // avanza
            //RawPrinterHelper.SendStringToPrinter(impresora, corte);     // corta
        }
        public void AbreCajon()
        {
            string cajon0 = (char)0x1B + "p" + (char)0x00 + (char)0x31 + (char)0x32;                    // caracteres de apertura cajon 0
            //string cajon1 = "\x1B" + "p" + "\x01" + "\x0F" + "\x96";                                  // caracteres de apertura cajon 1
            RawPrinterHelper.SendStringToPrinter(impresora, cajon0); // abre cajon0
            //RawPrinterHelper.SendStringToPrinter(impresora, cajon1); // abre cajon1
        }



        /// funcion weona para probar salto de linea
        protected const string _newline = "\r\n";

        public static string WordWrap(string the_string, int width)
        {
            int pos, next;
            StringBuilder sb = new StringBuilder();

            // Lucidity check
            if (width < 1)
                return the_string;

            // Parse each line of text
            for (pos = 0; pos < the_string.Length; pos = next)
            {
                // Find end of line
                int eol = the_string.IndexOf(_newline, pos);

                if (eol == -1)
                    next = eol = the_string.Length;
                else
                    next = eol + _newline.Length;

                // Copy this line of text, breaking into smaller lines as needed
                if (eol > pos)
                {
                    do
                    {
                        int len = eol - pos;

                        if (len > width)
                            len = BreakLine(the_string, pos, width);

                        sb.Append(the_string, pos, len);
                        sb.Append(_newline);

                        // Trim whitespace following break
                        pos += len;

                        while (pos < eol && Char.IsWhiteSpace(the_string[pos]))
                            pos++;

                    } while (eol > pos);
                }
                else sb.Append(_newline); // Empty line
            }

            return sb.ToString();
        }

        public static int BreakLine(string text, int pos, int max)
        {
            // Find last whitespace in line
            int i = max - 1;
            while (i >= 0 && !Char.IsWhiteSpace(text[pos + i]))
                i--;
            if (i < 0)
                return max; // No whitespace found; break at maximum length
                            // Find start of whitespace
            while (i >= 0 && Char.IsWhiteSpace(text[pos + i]))
                i--;
            // Return length of text before whitespace
            return i + 1;
        }
    }
#endregion

#region Clase para enviar a imprsora texto plano
    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
    #endregion


}




