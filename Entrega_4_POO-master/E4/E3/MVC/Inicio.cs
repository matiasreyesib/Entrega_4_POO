using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E3
{
    public partial class Inicio : Form
    {
        public event Action OnSalir;
        public event Action OnDatosIniciales;

        public Inicio()
        {
            InitializeComponent();
        }

        private void boton_iniciar_Click(object sender, EventArgs e)
        {
            if (OnDatosIniciales != null)
            {
                OnDatosIniciales();
            }
        }

        private void boton_salir_Click(object sender, EventArgs e)
        {
            if (OnSalir != null)
            {
                OnSalir();
            }
        }
        
        public void Salir_Juego()
        {
            Application.Exit();
        }
        
        public void Reiniciar_Juego()
        {
            Application.Restart();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
