using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace E3
{
    public partial class Form1 : Form
    {
        public event Action OnCambio;

        List<Button> listaBotones;
        Button[,] matrizBotones;
        public Mapa mapa = new Mapa(IntercambioDatos.filas, IntercambioDatos.columnas);
        

        public int nada = 0;
        int nt = IntercambioDatos.numero_taplan;
        int nw = IntercambioDatos.numero_wetar;
        int ng = IntercambioDatos.numero_gofue;
        int ndor = IntercambioDatos.numero_dorvalo;
        int ndot = IntercambioDatos.numero_doti;
        int ne = IntercambioDatos.numero_ent;
        int meses = 0;
        int n_bithalla=0;


        public Form1()
        {
            InitializeComponent();
            matrizBotones = new Button[mapa.filas_mapa, mapa.columnas_mapa];
            listaBotones = new List<Button>();
            
            for (int fila = 0; fila < mapa.filas_mapa; fila++)
            {
                for (int columna = 0; columna < mapa.columnas_mapa; columna++)
                {
                    Random random = new Random();
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0, 0, 0, 0);
                    button.Padding = new Padding(0, 0, 0, 0);
                    button.FlatStyle = FlatStyle.Popup;
                    button.FlatAppearance.BorderSize = 0;
                    button.Enabled = false;
                    tableLayoutPanel1.Controls.Add(button, columna, fila);
                    matrizBotones[fila, columna] = button;
                    listaBotones.Add(button);

                    Celda celda = mapa.mapa[fila, columna];
                    Terreno terreno = celda.tipo_terreno;

                    // Terrenos en el mapa
                    if (terreno.Get_Terreno() == "acuatico")
                    {
                        matrizBotones[fila, columna].BackColor = Color.Blue;
                        matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotoagua;
                        matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

                    }
                    else if (terreno.Get_Terreno() == "desierto")
                    {
                        matrizBotones[fila, columna].BackColor = Color.SandyBrown;
                        matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotodesierto;
                        matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                    else if (terreno.Get_Terreno() == "vegetacion")
                    {
                        matrizBotones[fila, columna].BackColor = Color.GreenYellow;
                        matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fototierra;
                        matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                    else if (terreno.Get_Terreno() == "nieve")
                    {
                        matrizBotones[fila, columna].BackColor = Color.White;
                        matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotonieve;
                        matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                    else if (terreno.Get_Terreno() == "volcan")
                    {
                        matrizBotones[fila, columna].BackColor = Color.DarkRed;
                        matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotolava;
                        matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                    else
                    {
                        matrizBotones[fila, columna].BackColor = Color.Black;
                    }

                    // Bitmons en el mapa ponemos su foto (un biton por celda)
                    if ((celda.bitmons_celda.Count > 0) && (celda.bitmons_celda.Count < 2))
                    {
                        if (celda.bitmons_celda[0].Get_Especie() == "wetar")
                        {
                            // matrizBotones[fila, columna].BackgroundImage = foto_1;
                            //matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].Text = "wetar";
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = Properties.Resources.fotowetar;
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        }
                        else if (celda.bitmons_celda[0].Get_Especie() == "dorvalo")
                        {
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = Properties.Resources.fotodorvalo;
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        }
                        else if (celda.bitmons_celda[0].Get_Especie() == "doti")
                        {
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = Properties.Resources.fotodoti;
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        }
                        else if (celda.bitmons_celda[0].Get_Especie() == "ent")
                        {
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = Properties.Resources.fotoent;
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        }
                        else if (celda.bitmons_celda[0].Get_Especie() == "gofue")
                        {
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = Properties.Resources.fotogofue;
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        }
                        else if (celda.bitmons_celda[0].Get_Especie() == "taplan")
                        {
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImage = Properties.Resources.fototaplan;
                            matrizBotones[celda.bitmons_celda[0].Get_Posx(), celda.bitmons_celda[0].Get_Posy()].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        }
                        else
                        {
                            nada += 0;
                        }
                    }
                    // Cuando al inicio hay dos bitmons en una celda
                    else if ((celda.bitmons_celda.Count > 1) && (celda.bitmons_celda.Count < 3))
                    {
                        if ((celda.bitmons_celda[0].Get_Especie() == "wetar" && celda.bitmons_celda[1].Get_Especie() == "taplan") || (celda.bitmons_celda[0].Get_Especie() == "taplan" && celda.bitmons_celda[1].Get_Especie() == "wetar"))
                        {
                            mapa.CrearBitmon_Reproduccion();
                        }
                        else if ((celda.bitmons_celda[0].Get_Especie() == "ent" && celda.bitmons_celda[1].Get_Especie() == "taplan") || (celda.bitmons_celda[0].Get_Especie() == "taplan" && celda.bitmons_celda[1].Get_Especie() == "ent"))
                        {
                            mapa.CrearBitmon_Reproduccion();
                        }
                        else if ((celda.bitmons_celda[0].Get_Especie() == "doti" && celda.bitmons_celda[1].Get_Especie() == "taplan") || (celda.bitmons_celda[0].Get_Especie() == "taplan" && celda.bitmons_celda[1].Get_Especie() == "doti"))
                        {
                            mapa.CrearBitmon_Reproduccion();
                        }
                        else if ((celda.bitmons_celda[0].Get_Especie() == "wetar" && celda.bitmons_celda[1].Get_Especie() == "doti") || (celda.bitmons_celda[0].Get_Especie() == "doti" && celda.bitmons_celda[1].Get_Especie() == "wetar"))
                        {
                            mapa.CrearBitmon_Reproduccion();
                        }
                        else if ((celda.bitmons_celda[0].Get_Especie() == "doti" && celda.bitmons_celda[1].Get_Especie() == "ent") || (celda.bitmons_celda[0].Get_Especie() == "ent" && celda.bitmons_celda[1].Get_Especie() == "doti"))
                        {
                            mapa.CrearBitmon_Reproduccion();
                        }
                        else if ((celda.bitmons_celda[0].Get_Especie() == "dorvalo" && celda.bitmons_celda[1].Get_Especie() == "gofue") || (celda.bitmons_celda[0].Get_Especie() == "gofue" && celda.bitmons_celda[1].Get_Especie() == "dorvalo"))
                        {
                            mapa.CrearBitmon_Reproduccion();
                        }
                        else
                        {
                            mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                            mapa.bithalla.Add(celda.bitmons_celda[0]);
                            for (int i = 0; i < mapa.bitmons_mapa.Count; i++)
                            {
                                if (mapa.bitmons_mapa[i].Get_Especie() == celda.bitmons_celda[0].Get_Especie())
                                {
                                    mapa.bitmons_mapa.RemoveAt(i);
                                }
                            }
                        }
                    }
                }
            }
        }
        
        ////////////////////////BOTON REINICIAR////////////////////////
        private void boton_reiniciar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }


        /////////////////////////BOTON SALIR//////////////////////////
        private void boton_salir_Click(object sender, EventArgs e)
        {
            DatosFinales dt = new DatosFinales(nt, nw, ng, ndor, ndot, ne, mapa);
            dt.Show();
        }
        

        ////////////////////////BOTON MES SIMULACION////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            meses += 1;
            // con esto aparecen los ent cada tres meses
            if (meses%3 == 0)
            {
                mapa.CrearBitmon_Ent();
            }

            // Recorremos cada celda para lograr el movimiento del bitmon, su reproduccion, las peleas, etc.
            for (int fila = 0; fila < mapa.filas_mapa; fila++)
            {
                for (int columna = 0; columna < mapa.columnas_mapa; columna++)
                {
                    Celda celda = mapa.mapa[fila, columna];
                    Terreno terreno = celda.tipo_terreno;
                    List<Bitmon> Borrador_Bitmons_Celda = new List<Bitmon>();
                    // Utilizamos el borrador para facilitar la accion de moverse del bitmon
                    
                    //---------Envejecen y mueren de viejos, se agregan al Bithala---------------------
                    for (int i = 0; i < celda.bitmons_celda.Count; i++)
                    {
                        celda.bitmons_celda[i].ReducirTiempoDeVida(1);
                        if (celda.bitmons_celda[i].Get_TiempoDeVida() <= 0)
                        {
                            mapa.bithalla.Add(celda.bitmons_celda[i]);
                        }
                    }

                    // Para cuando hay 1 Bitmon en la lista de bitmons de la celda
                    if (celda.bitmons_celda.Count > 0 && celda.bitmons_celda.Count < 2)
                    {
                        /// Aca el movimiento del wetar queda resringido solamente a a las celdas contiguas que tienen Agua
                        if (celda.bitmons_celda[0].Get_Especie() == "wetar")
                        {
                            mapa.mapa[fila, columna].bitmons_celda[0].Moverse(mapa);
                            int posx_sig = mapa.mapa[fila, columna].bitmons_celda[0].Get_Posx();
                            int posy_sig = mapa.mapa[fila, columna].bitmons_celda[0].Get_Posy();

                            if (mapa.mapa[posx_sig, posy_sig].tipo_terreno.Get_Terreno() == "acuatico")
                            {
                                Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                                matrizBotones[fila, columna].BackgroundImage = null;
                                if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                                {
                                    matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotoagua; //foto_agua;
                                    matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                }
                                else
                                {
                                    nada += 0;
                                }
                                mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                                mapa.mapa[posx_sig, posy_sig].AgregarBitmon(Borrador_Bitmons_Celda[0]);
                                matrizBotones[posx_sig, posy_sig].BackgroundImage = Properties.Resources.fotowetar; //foto_wetar;
                                matrizBotones[posx_sig, posy_sig].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                                Borrador_Bitmons_Celda.RemoveAt(0);
                            }
                            else
                            {
                                nada += 0;
                            }
                        }
                        else if (celda.bitmons_celda[0].Get_Especie() == "dorvalo")
                        {
                            Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                            matrizBotones[fila, columna].BackgroundImage = null;
                            // Esto se utiliza para dejar la imagen del terreno que estaba antes de que se moviera el bitmon de ese lugar
                            if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotoagua; //foto_agua;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotodesierto; //foto_desierto;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotonieve; //foto_nieve;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fototierra; //foto_tierra;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "volcan")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotolava; //foto_lava;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else
                            {
                                nada += 0;
                            }
                            mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                            Borrador_Bitmons_Celda[0].Moverse(mapa);
                            int posx = Borrador_Bitmons_Celda[0].Get_Posx();
                            int posy = Borrador_Bitmons_Celda[0].Get_Posy();
                            mapa.mapa[posx, posy].AgregarBitmon(Borrador_Bitmons_Celda[0]);
                            matrizBotones[posx, posy].BackgroundImage = Properties.Resources.fotodorvalo;//foto_dorvalo;
                            matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            Borrador_Bitmons_Celda.RemoveAt(0);
                        }
                        else if (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "doti")
                        {
                            ndot += 1;
                            Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                            matrizBotones[fila, columna].BackgroundImage = null;
                            // Esto se utiliza para dejar la imagen del terreno que estaba antes de que se moviera el bitmon de ese lugar
                            if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotoagua; //foto_agua;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotodesierto; //foto_desierto;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotonieve; //foto_nieve;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fototierra; //foto_tierra;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "volcan")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotolava; //foto_lava;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else
                            {
                                nada += 0;
                            }
                            mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                            Borrador_Bitmons_Celda[0].Moverse(mapa);
                            int posx = Borrador_Bitmons_Celda[0].Get_Posx();
                            int posy = Borrador_Bitmons_Celda[0].Get_Posy();
                            mapa.mapa[posx, posy].AgregarBitmon(Borrador_Bitmons_Celda[0]);
                            matrizBotones[posx, posy].BackgroundImage = Properties.Resources.fotodoti; //foto_doti;
                            matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            Borrador_Bitmons_Celda.RemoveAt(0);
                        }
                        else if (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "ent")
                        {
                            ne += 1;
                            Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                            matrizBotones[fila, columna].BackgroundImage = null;
                            // Como los Ents no son capaces de moverse, no nos preocupamos de hacer lo que hicimos antes
                            mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                            Borrador_Bitmons_Celda[0].Moverse(mapa);
                            int posx = Borrador_Bitmons_Celda[0].Get_Posx();
                            int posy = Borrador_Bitmons_Celda[0].Get_Posy();
                            mapa.mapa[posx, posy].AgregarBitmon(Borrador_Bitmons_Celda[0]);
                            matrizBotones[posx, posy].BackgroundImage = Properties.Resources.fotoent; //foto_ent;
                            matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            Borrador_Bitmons_Celda.RemoveAt(0);
                        }
                        else if (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "gofue")
                        {
                            ng += 1;
                            Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                            matrizBotones[fila, columna].BackgroundImage = null;
                            // Esto se utiliza para dejar la imagen del terreno que estaba antes de que se moviera el bitmon de ese lugar
                            // Ademas aca se cambia de terreno, si es vegetacion a desertico y si es nieve a agua
                            if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotoagua; //foto_agua;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotodesierto; //foto_desierto;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                            {
                                mapa.mapa[fila, columna].tipo_terreno = mapa.mapa[fila, columna].bitmons_celda[0].CambioTerreno(2);
                                matrizBotones[fila, columna].BackColor = Color.Blue;
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotoagua; //foto_agua;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                            {
                                mapa.mapa[fila, columna].tipo_terreno = mapa.mapa[fila, columna].bitmons_celda[0].CambioTerreno(1);
                                matrizBotones[fila, columna].BackColor = Color.SandyBrown;
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotodesierto; //foto_desierto;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "volcan")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotolava; //foto_lava;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else
                            {
                                nada += 0;
                            }
                            mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                            Borrador_Bitmons_Celda[0].Moverse(mapa);
                            int posx = Borrador_Bitmons_Celda[0].Get_Posx();
                            int posy = Borrador_Bitmons_Celda[0].Get_Posy();
                            mapa.mapa[posx, posy].AgregarBitmon(Borrador_Bitmons_Celda[0]);
                            matrizBotones[posx, posy].BackgroundImage = Properties.Resources.fotogofue; //foto_gofue;
                            matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            Borrador_Bitmons_Celda.RemoveAt(0);
                        }
                        else if (mapa.mapa[fila, columna].bitmons_celda[0].Get_Especie() == "taplan")
                        {
                            nt += 1;
                            Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                            matrizBotones[fila, columna].BackgroundImage = null;
                            // Esto se utiliza para dejar la imagen del terreno que estaba antes de que se moviera el bitmon de ese lugar
                            // Ademas aca se cambia de terreno, se ies desertico a vegetacion
                            if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotoagua; //foto_agua;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                            {
                                mapa.mapa[fila, columna].tipo_terreno = mapa.mapa[fila, columna].bitmons_celda[0].CambioTerreno(1);
                                matrizBotones[fila, columna].BackColor = Color.GreenYellow;
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fototierra; //foto_tierra;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotonieve; //foto_nieve;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fototierra; //foto_tierra;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else if (mapa.mapa[fila, columna].tipo_terreno.Get_Terreno() == "volcan")
                            {
                                matrizBotones[fila, columna].BackgroundImage = Properties.Resources.fotolava; //foto_lava;
                                matrizBotones[fila, columna].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            }
                            else
                            {
                                nada += 0;
                            }
                            mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                            Borrador_Bitmons_Celda[0].Moverse(mapa);
                            int posx = Borrador_Bitmons_Celda[0].Get_Posx();
                            int posy = Borrador_Bitmons_Celda[0].Get_Posy();
                            mapa.mapa[posx, posy].AgregarBitmon(Borrador_Bitmons_Celda[0]);
                            matrizBotones[posx, posy].BackgroundImage = Properties.Resources.fototaplan; //foto_taplan;
                            matrizBotones[posx, posy].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                            Borrador_Bitmons_Celda.RemoveAt(0);
                        }
                        else
                        {
                            nada += 0;
                        }
                    }

                    // Para cuando hay 2 Bitmon en la lista de bitmons de la celda
                    else if (celda.bitmons_celda.Count > 1 && celda.bitmons_celda.Count < 3)
                    {
                        if ((celda.bitmons_celda[0].Get_Especie()=="wetar" && celda.bitmons_celda[1].Get_Especie()=="taplan") || (celda.bitmons_celda[0].Get_Especie() == "taplan" && celda.bitmons_celda[1].Get_Especie() == "wetar"))
                        {
                            mapa.CrearBitmon_Reproduccion();
                        }
                        else if ((celda.bitmons_celda[0].Get_Especie() == "ent" && celda.bitmons_celda[1].Get_Especie() == "taplan") || (celda.bitmons_celda[0].Get_Especie() == "taplan" && celda.bitmons_celda[1].Get_Especie() == "ent"))
                        {
                            mapa.CrearBitmon_Reproduccion();
                        }
                        else if ((celda.bitmons_celda[0].Get_Especie() == "doti" && celda.bitmons_celda[1].Get_Especie() == "taplan") || (celda.bitmons_celda[0].Get_Especie() == "taplan" && celda.bitmons_celda[1].Get_Especie() == "doti"))
                        {
                            mapa.CrearBitmon_Reproduccion();
                        }
                        else if ((celda.bitmons_celda[0].Get_Especie() == "wetar" && celda.bitmons_celda[1].Get_Especie() == "doti") || (celda.bitmons_celda[0].Get_Especie() == "doti" && celda.bitmons_celda[1].Get_Especie() == "wetar"))
                        {
                            mapa.CrearBitmon_Reproduccion();
                        }
                        else if ((celda.bitmons_celda[0].Get_Especie() == "doti" && celda.bitmons_celda[1].Get_Especie() == "ent") || (celda.bitmons_celda[0].Get_Especie() == "ent" && celda.bitmons_celda[1].Get_Especie() == "doti"))
                        {
                            mapa.CrearBitmon_Reproduccion();
                        }
                        else if ((celda.bitmons_celda[0].Get_Especie() == "dorvalo" && celda.bitmons_celda[1].Get_Especie() == "gofue") || (celda.bitmons_celda[0].Get_Especie() == "gofue" && celda.bitmons_celda[1].Get_Especie() == "dorvalo"))
                        {
                            mapa.CrearBitmon_Reproduccion();
                        }
                        else
                        {
                            mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                            mapa.bithalla.Add(celda.bitmons_celda[0]);
                            for (int i=0; i < mapa.bitmons_mapa.Count; i++)
                            {
                                if (mapa.bitmons_mapa[i].Get_Especie() == celda.bitmons_celda[0].Get_Especie())
                                {
                                    mapa.bitmons_mapa.RemoveAt(i);
                                }
                            }
                        }
                    }

                    // Para cuando hay 3 Bitmon en la lista de bitmons de la celda
                    else if (celda.bitmons_celda.Count > 2 && celda.bitmons_celda.Count < 4)
                    {
                        mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                        /*
                        mapa.bithalla.Add(celda.bitmons_celda[0]);
                        for (int i = 0; i < mapa.bitmons_mapa.Count; i++)
                        {
                            if (mapa.bitmons_mapa[i].Get_Especie() == celda.bitmons_celda[0].Get_Especie())
                            {
                                mapa.bitmons_mapa.RemoveAt(i);
                            }
                        }
                        */
                        mapa.mapa[fila, columna].bitmons_celda.RemoveAt(1);
                        /*
                        mapa.bithalla.Add(celda.bitmons_celda[1]);
                        for (int i = 0; i < mapa.bitmons_mapa.Count; i++)
                        {
                            if (mapa.bitmons_mapa[i].Get_Especie() == celda.bitmons_celda[1].Get_Especie())
                            {
                                mapa.bitmons_mapa.RemoveAt(i);
                            }
                        }
                        */
                    }
                    else
                    {
                        nada += 0;
                    }
                }
            }
            int n_taplan = 0;
            int n_wetar = 0;
            int n_gofue = 0;
            int n_dorvalo = 0;
            int n_doti = 0;
            int n_ent = 0;

            foreach (Bitmon b in mapa.bitmons_mapa)
            {
                if (b.Get_Especie() == "taplan")
                {
                    n_taplan += 1;
                }
                else if (b.Get_Especie() == "wetar")
                {
                    n_wetar += 1;
                }
                else if (b.Get_Especie() == "gofue")
                {
                    n_gofue += 1;
                }
                else if (b.Get_Especie() == "dorvalo")
                {
                    n_dorvalo += 1;
                }
                else if (b.Get_Especie() == "doti")
                {
                    n_doti += 1;
                }
                else if (b.Get_Especie() == "ent")
                {
                    n_ent += 1;
                }
            }
            nt = n_taplan;
            nw = n_wetar;
            ng = n_gofue;
            ndor = n_dorvalo;
            ndot =n_doti;
            ne = n_ent;
        }

        
        // cambiar a mvc
        private void button2_Click(object sender, EventArgs e)
        {
            int n_taplan = 0;
            int n_wetar = 0;
            int n_gofue = 0;
            int n_dorvalo = 0;
            int n_doti = 0;
            int n_ent = 0;

            for (int i = 0; i < mapa.bitmons_mapa.Count; i++)
            {
                if (mapa.bitmons_mapa[i].Get_Especie() == "taplan")
                {
                    n_taplan += 1;
                }
                else if (mapa.bitmons_mapa[i].Get_Especie() == "wetar")
                {
                    n_wetar += 1;
                }
                else if (mapa.bitmons_mapa[i].Get_Especie() == "gofue")
                {
                    n_gofue += 1;
                }
                else if (mapa.bitmons_mapa[i].Get_Especie() == "dorvalo")
                {
                    n_dorvalo += 1;
                }
                else if (mapa.bitmons_mapa[i].Get_Especie() == "doti")
                {
                    n_doti += 1;
                }
                else if (mapa.bitmons_mapa[i].Get_Especie() == "ent")
                {
                    n_ent += 1;
                }
            }
            cant_taplan.Text = Convert.ToString(n_taplan);
            cant_wetar.Text = Convert.ToString(n_wetar);
            cant_gofue.Text = Convert.ToString(n_gofue);
            cant_dorvalo.Text = Convert.ToString(n_dorvalo);
            cant_doti.Text = Convert.ToString(n_doti);
            cant_ent.Text = Convert.ToString(n_ent);
        }
        
        
        private void label13_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
