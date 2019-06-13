﻿using System;
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
        List<Button> listaBotones;
        Button[,] matrizBotones;
        List<Bitmon> bithala = new List<Bitmon>();
        Mapa mapa = new Mapa(IntercambioDatos.filas, IntercambioDatos.columnas);

        public int nada = 0;
        int nt = 0;
        int nw = 0;
        int ng = 0;
        int ndor = 0;
        int ndot = 0;
        int ne = 0;
        int meses = 0;

        int ntf = 0;
        int nwf = 0;
        int ngf = 0;
        int ndorf = 0;
        int ndotf = 0;
        int nef = 0;
        int Dato;


        public Form1(int Dato)
        {
            Dato = Dato;
            //label13.Text = Convert.ToString(bithala.Count);
            InitializeComponent();
            matrizBotones = new Button[mapa.filas_mapa, mapa.columnas_mapa];
            listaBotones = new List<Button>();
            //label13.Text = Convert.ToString(bithala.Count);

           

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

                    // Bitmons en el mapa ponemos su foto
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
                    ///////////////////////
                    ///////////////////////
    ///////////////////////--------------Acciones------------------------------------------------------
    ///
    /// 
    ///---------------------------------pelear------------------------------------------------------
                    else if ((celda.bitmons_celda.Count > 1) && (celda.bitmons_celda.Count < 3))
                    {
                        if ((celda.bitmons_celda[0].Get_Especie() == "wetar" && celda.bitmons_celda[1].Get_Especie() == "dorvalo"))
                        {
                            ndor += 1;
                            bithala.Add(celda.bitmons_celda[0]);
                            celda.bitmons_celda.RemoveAt(0);
                        }
                        else if ((celda.bitmons_celda[0].Get_Especie() == "dorvalo" && celda.bitmons_celda[1].Get_Especie() == "wetar"))
                        {
                            ndor += 1;
                            bithala.Add(celda.bitmons_celda[1]);
                            celda.bitmons_celda.RemoveAt(1);
                        }
                        else
                        {
                            bithala.Add(celda.bitmons_celda[0]);
                            celda.bitmons_celda.RemoveAt(0);
                        }
                    }
                }
            }
        }



        /*
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void boton_reiniciar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }


        private void boton_salir_Click(object sender, EventArgs e)
        {
            DatosFinales dt = new DatosFinales(nt, nw, ng, ndor, ndot, ne, bithala.Count, Dato, mapa);
            dt.Show();
            
        }

        //-------------- mes de juego--------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            //label13.Text = Convert.ToString(bithala.Count);
            //label13.Refresh();
            nt = 0;
            nw = 0;
            ng = 0;
            ndor = 0;
            ndot = 0;
            ne = 0;
            meses += 1;
        

            if (meses%3 == 0)
            {
                Random ran = new Random();
                int ran1 =ran.Next(0, mapa.filas_mapa);
                int ran2 = ran.Next(0, mapa.columnas_mapa);

                Ent ent = new Ent(ran1, ran2, 10, 10);
                mapa.mapa[ran1, ran2].AgregarBitmon(ent);
                mapa.bitmons_mapa.Add(ent);


            }
            //List<Bitmon> bithala = new List<Bitmon>();
            // List<Bitmon> habitantes = new List<Bitmon>();

            // Recorremos cada celda para lograr el movimiento del bitmon, su reproduccion, las peleas, etc.
            for (int fila = 0; fila < mapa.filas_mapa; fila++)
            {
                for (int columna = 0; columna < mapa.columnas_mapa; columna++)
                {
                    Celda celda = mapa.mapa[fila, columna];
                    Terreno terreno = celda.tipo_terreno;
                    // Utilizamos el borrador para facilitar la accion de moverse del bitmon
                    List<Bitmon> Borrador_Bitmons_Celda = new List<Bitmon>();

                    //---------envejecen y mueren de viejos, se agregan al Bithala---------------------
                    foreach (Bitmon biti in celda.bitmons_celda)
                    {
                        int n = 0;
                        biti.ReducirPuntosDeVida(1);
                        if (biti.Get_TiempoDeVida() <= 0)
                        {
                            bithala.Add(biti);
                            mapa.mapa[fila, columna].bitmons_celda.RemoveAt(n);
                            n += 1;
                        }

                    }


                    //
                    //
                    // Para cuando hay 1 Bitmon en la lista de bitmons de la celda
                    //
                    //

                    if (celda.bitmons_celda.Count > 0 && celda.bitmons_celda.Count < 2)
                    {
                        ////////////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////////////
                        /// Aca el movimiento del wetar queda resringido solamente a a las celdas contiguas que tienen Agua
                        if (celda.bitmons_celda[0].Get_Especie() == "wetar")
                        {
                            nw += 1;
                            mapa.mapa[fila, columna].bitmons_celda[0].Moverse(mapa);
                            int posx_sig = mapa.mapa[fila, columna].bitmons_celda[0].Get_Posx();
                            int posy_sig = mapa.mapa[fila, columna].bitmons_celda[0].Get_Posy();

                            if (mapa.mapa[posx_sig, posy_sig].tipo_terreno.Get_Terreno() == "acuatico")
                            {
                                Borrador_Bitmons_Celda.Add(mapa.mapa[fila, columna].bitmons_celda[0]);
                                // matrizBotones[fila, columna].Text = "";
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
                                /*
                                Borrador_Bitmons_Celda[0].Moverse(mapa);
                                int posx = Borrador_Bitmons_Celda[0].Get_Posx();
                                int posy = Borrador_Bitmons_Celda[0].Get_Posy();
                                */
                                mapa.mapa[posx_sig, posy_sig].AgregarBitmon(Borrador_Bitmons_Celda[0]);
                                matrizBotones[posx_sig, posy_sig].BackgroundImage = Properties.Resources.fotowetar; //foto_wetar;
                                matrizBotones[posx_sig, posy_sig].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                                Borrador_Bitmons_Celda.RemoveAt(0);
                                //matrizBotones[posx, posy].Text = "wetar";
                            }
                            else
                            {
                                nada += 0;
                            }
                        }
                        ////////////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////////////
                        else if (celda.bitmons_celda[0].Get_Especie() == "dorvalo")
                        {
                            ndor += 1;
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
                        ////////////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////////////
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
                        ////////////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////////////
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
                        ////////////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////////////
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
                        ////////////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////////////
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
                    //
                    //
                    //
                    //
                    // Para cuando hay 2 Bitmon en la lista de bitmons de la celda
                    //
                    //
                    //
                    //
                    else if (celda.bitmons_celda.Count > 1 && celda.bitmons_celda.Count < 3)
                    {
                        if (celda.bitmons_celda[1].Get_Especie() == "taplan")
                        {
                            nt += 1;
                            
                        }
                        else if (celda.bitmons_celda[1].Get_Especie() == "wetar")
                        {
                            nw += 1;
                            
                        }
                        else if (celda.bitmons_celda[1].Get_Especie() == "gofue")
                        {
                            ng += 1;
                            
                        }
                        else if (celda.bitmons_celda[1].Get_Especie() == "dorvalo")
                        {
                            ndor += 1;
                            
                        }
                        else if (celda.bitmons_celda[1].Get_Especie() == "doti")
                        {
                            ndot += 1;
                            
                        }
                        else if (celda.bitmons_celda[1].Get_Especie() == "ent")
                        {
                            nt += 1;
                            
                        }
                        else
                        {
                            nada += 0;
                        }
                        mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                    }
                    //
                    //
                    //
                    //
                    // Para cuando hay 3 Bitmon en la lista de bitmons de la celda
                    //
                    //
                    //
                    //
                    else if (celda.bitmons_celda.Count > 2 && celda.bitmons_celda.Count < 4)
                    {
                        if (celda.bitmons_celda[2].Get_Especie() == "taplan")
                        {
                            nt += 1;
                        }
                        else if (celda.bitmons_celda[2].Get_Especie() == "wetar")
                        {
                            nw += 1;
                        }
                        else if (celda.bitmons_celda[2].Get_Especie() == "gofue")
                        {
                            ng += 1;
                        }
                        else if (celda.bitmons_celda[2].Get_Especie() == "dorvalo")
                        {
                            ndor += 1;
                        }
                        else if (celda.bitmons_celda[2].Get_Especie() == "doti")
                        {
                            ndot += 1;
                        }
                        else if (celda.bitmons_celda[2].Get_Especie() == "ent")
                        {
                            nt -= 1;
                        }
                        else
                        {
                            nada += 0;
                        }
                        mapa.mapa[fila, columna].bitmons_celda.RemoveAt(0);
                        mapa.mapa[fila, columna].bitmons_celda.RemoveAt(1);
                    }

                    //////////
                    //////////
                    /////////
                    /////////
                    //////
                    ///
                    //

                    else
                    {
                        nada += 0;
                    }
                }
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cant_taplan.Text = Convert.ToString(nt);
            cant_wetar.Text = Convert.ToString(nw);
            cant_gofue.Text = Convert.ToString(ng);
            cant_dorvalo.Text = Convert.ToString(ndor);
            cant_doti.Text = Convert.ToString(ndot);
            cant_ent.Text = Convert.ToString(ne);
        }
        

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
