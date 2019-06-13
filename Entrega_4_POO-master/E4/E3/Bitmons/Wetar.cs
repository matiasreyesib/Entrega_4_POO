using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3
{
    class Wetar : Bitmon
    {
        /*
        Random rnd = new Random();
        new int tiempoDeVida;
        new int puntosDeVida;
        new int puntosDeAtaque;
        new string especie;
        new int cantidadDeHijos;
        */
        Random rnd = new Random();
        new int tiempoDeVida;
        new int posx;
        new int posy;
        new int esperanzaVida;

        // Al constructor dedl bitmons le metemos los parametros de su ubicacion para que el bitmon los guarde
        public Wetar(int posx, int posy, int tiempoDeVida, int esperanzaVida)
        {
            this.posx = posx;
            this.posy = posy;
            this.tiempoDeVida = tiempoDeVida;
            this.esperanzaVida = esperanzaVida;
        }

        public override int Get_TiempoDeVida()
        {
            return tiempoDeVida;
        }

        public override int Get_esperanza()
        {
            return esperanzaVida;
        }
        // Reduce el tiempo de vida mientras pasan los meses
        public override void ReducirTiempoDeVida(int numero)
        {
            if (tiempoDeVida > 0)
            {
                tiempoDeVida -= numero;
            }
            else
            {
                tiempoDeVida = 0;
            }

        }

        public override Terreno CambioTerreno(int a)
        {
            return new Acuatico();
        }

        public override int Daño(Bitmon bitmon)
        {
            if (bitmon.Get_Especie() == "Gofue" || bitmon.Get_Especie() == "doti")
            {
                return puntosDeAtaque * 2;
            }
            else
            {
                return Convert.ToInt32(puntosDeAtaque * 0.5);
            }
        }


        public override string Get_Especie()
        {
            return especie = "wetar";
        }
        // Retornamos el nombre de la especie vacio, para poder hacer que 
        // desaparezca el nombre del bitmon cuando se mueve
        public override string Get_Especie_Vacio()
        {
            return especie = "";
        }
        // Nos da la posision 'x' e 'y' del bitmon
        public override int Get_Posx()
        {
            return posx;
        }
        public override int Get_Posy()
        {
            return posy;
        }

        // Se mueve en 'fila' y 'columna'
        public int Moverse_Fila()
        {
            posx += rnd.Next(-1, 2);
            return posx;
        }
        public int Moverse_Columna()
        {
            posy += rnd.Next(-1, 2);
            return posy;
        }

        public override void Moverse(Mapa mapa)
        {
            int x = posx;
            int y = posy;
            int mx = Moverse_Fila();
            int my = Moverse_Columna();

            if (mx > 0 && mx < mapa.filas_mapa & my > 0 && my < mapa.columnas_mapa)
            {
                posx = mx;
                posy = my;
            }
            else
            {
                if (x == 0 && y == 0)
                {
                    posx += 1;
                    posy += 1;
                }
                else if (x == mapa.filas_mapa-1 && y == 0)
                {
                    posx -= 1;
                    posy += 1;
                }
                else if (x == 0 && y == mapa.columnas_mapa-1)
                {
                    posx += 1;
                    posy -= 1;
                }
                else if (x == mapa.filas_mapa-1 && y == mapa.columnas_mapa-1)
                {
                    posx -= 1;
                    posy -= 1;
                }
                else if (x == 0 && y != 0 && y != mapa.columnas_mapa-1)
                {
                    posx += 1;
                }
                else if (x == mapa.filas_mapa-1 && y != 0 && y != mapa.columnas_mapa-1)
                {
                    posx -= 1;
                }
                else if (y == 0 && x != 0 && x != mapa.filas_mapa-1)
                {
                    posy += 1;
                }
                else if (y == mapa.columnas_mapa-1 && x != 0 && x != mapa.filas_mapa-1)
                {
                    posy -= 1;
                }

                else
                {
                    posx += 0;
                    posy += 0;
                }
            }
        }
    }
}
