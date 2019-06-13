using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;
using Models;

namespace E3
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Inicio inicio = new Inicio();
            Form1 form1 = new Form1();
            Modelo modelo = new Modelo();
            Controlador controlador = new Controlador(inicio, form1, modelo);
            Application.Run(inicio);
        }
    }
}
