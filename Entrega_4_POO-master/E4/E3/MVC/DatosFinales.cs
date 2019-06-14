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
        public DatosFinales(int nt, int nw, int ng, int ndor, int ndot, int ne, Mapa mapa)
        {
            InitializeComponent();
            label1.Text = Convert.ToString(nt);
            label2.Text = Convert.ToString(nw);
            label3.Text = Convert.ToString(ng);
            label4.Text = Convert.ToString(ndor);
            label5.Text = Convert.ToString(ndot);
            label6.Text = Convert.ToString(ne);

            label14.Text = Convert.ToString(mapa.bitmons_mapa_total.Count());
            label15.Text = Convert.ToString(mapa.bitmons_mapa_total.Count()- (nt +nw +ng +ndor +ndot +ne));
            //-------------vida total ------------------------------------
            int vta = 0;
            int vw = 0;
            int vg = 0;
            int vdor = 0;
            int vdot = 0;
            int ven = 0;
            //------------ cantidad de bitmons totales------------
            int cta = 0;
            int cw = 0;
            int cg = 0;
            int cdor = 0;
            int cdot = 0;
            int cen = 0;
            int n1 = 0;

            foreach (Bitmon bit in mapa.bitmons_mapa_total)
            {
                if (bit.Get_Especie() == "taplan")
                {
                    vta += bit.Get_esperanza();
                    cta += 1;
                }
                if (bit.Get_Especie() == "gofue")
                {
                    vg += bit.Get_esperanza();
                    cw += 1;
                }
                if (bit.Get_Especie() == "wetar")
                {
                    vw += bit.Get_esperanza();
                    cg += 1;
                }
                if (bit.Get_Especie() == "dorvalo")
                {
                    vdor += bit.Get_esperanza();
                    cdor += 1;
                }
                if (bit.Get_Especie() == "doti")
                {
                    vdot += bit.Get_esperanza();
                    cdot += 1;
                }
                if (bit.Get_Especie() == "ent")
                {
                    ven += bit.Get_esperanza();
                    cen += 1;
                }
            }
            try
            {
                label32.Text = Convert.ToString(vta / cta);
            }
            catch
            {
               label32.Text = "0";
            }
            try
            {
                label31.Text = Convert.ToString(vw / cw);
            }
            catch
            {
                label31.Text = "0";
            }
            try
            {
                label30.Text = Convert.ToString(vg / cg);
            }
            catch
            {
                label30.Text = "0";
            }
            try
            {
                label29.Text = Convert.ToString(vdor / cdor);
            }
            catch
            {
                label29.Text = "0";
            }
            try
            {
                label28.Text = Convert.ToString(vdot / cdot);
            }
            catch
            {
                label28.Text = "0";
            }
            try
            {
                label27.Text = Convert.ToString(ven /cen);
            }
            catch
            {
                label27.Text = "0";
            }
            try
            {
                label19.Text = Convert.ToString((vta + vw + vg + vdor + vdot + ven) / (cta + cw + cg + cdor + cdot + cen));
            }
            catch
            {
                label17.Text = "0";
            }


            string texto = "";
            if (nt == 0)
            {
                texto = texto + "Taplan";
            }
            if (nw == 0)
            {
                texto = texto + "  Wetar";
            }
            if (ng == 0)
            {
                texto = texto + "  Gofue";
            }
            if (ndor == 0)
            {
                texto = texto + "  Dorvalo";
            }
            if (ndot == 0)
            {
                texto = texto + "  Doti";
            }
            if (ne == 0)
            {
                texto = texto + "Ent";
            }
            label17.Text = texto;



        }

        //BOTON SALIR DE ESTADISTICAS
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hasta Luego!");
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

        private void DatosFinales_Load(object sender, EventArgs e)
        {

        }
        private void label32_Click(object sender, EventArgs e)
        {

        }
        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
