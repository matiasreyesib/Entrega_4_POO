using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using E3;

namespace Controllers
{
    class Controlador
    {
        Inicio inicio;
        Form1 form1;
        DatosFinales datosFinales;
        Modelo modelo;

        public Controlador(Inicio inicio, Form1 form1, Modelo modelo)
        {
            this.inicio = inicio;
            this.form1 = form1;
            this.modelo = modelo;

            inicio.OnSalir += Salir;
            inicio.OnDatosIniciales += DatosIniciales;
        }
        
        ////////////// Para el Form Inicio //////////////
        public void Salir()
        {
            inicio.Salir_Juego();
        }

        public void DatosIniciales()
        {
            if (inicio.comboBox1 != null && inicio.comboBox2 != null && inicio.comboBox3 != null)
            {
                IntercambioDatos.filas = Convert.ToInt32(inicio.comboBox1.SelectedItem);
                IntercambioDatos.columnas = Convert.ToInt32(inicio.comboBox2.SelectedItem);
                IntercambioDatos.bitmonsIniciales = Convert.ToInt32(inicio.comboBox3.SelectedItem);
                int Dato = Convert.ToInt32(inicio.comboBox3.SelectedItem);
                Form1 Form1 = new Form1();
                Form1.Show();
                inicio.Hide();
            }
        }
        /////////////////////////////////////////////////
        ///
    }
}
