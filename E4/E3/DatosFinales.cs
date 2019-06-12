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
    public partial class DatosFinales : Form
    {
        //int Dato;
        public DatosFinales(int nt, int nw, int ng, int ndor, int ndot, int ne, int bithala, int Dato, Mapa mapa)
        {
            InitializeComponent();
            label1.Text = Convert.ToString(nt);
            label2.Text = Convert.ToString(nw);
            label3.Text = Convert.ToString(ng);
            label4.Text = Convert.ToString(ndor);
            label5.Text = Convert.ToString(ndot);
            label6.Text = Convert.ToString(ne);

            label14.Text = Convert.ToString(mapa.bitmons_mapa.Count());
            label15.Text = Convert.ToString(mapa.bitmons_mapa.Count() - nt - nw - ng - ndor - ndot - ne);



        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tus Bitmons acaban de morir de pena porque te vas, hasta nunca");
            FormCollection formulariosApp = Application.OpenForms;
            try
            {
                foreach (Form f in formulariosApp)
                {
                    f.Close();
                }
            }
            catch
            {
                Application.Exit();
                
            }
        }
    }
}
