using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3
{
    public class Mapa
    {
        public int filas_mapa;
        public int columnas_mapa;
        public Celda[,] mapa;
        public List<Bitmon> bitmons_mapa = new List<Bitmon>();
        public List<Bitmon> bithalla = new List<Bitmon>();
        public List<Bitmon> bitmons_mapa_total = new List<Bitmon>();
        Random random = new Random();
        int bitmonsIniciales = IntercambioDatos.bitmonsIniciales;



        public Mapa(int filas_mapa, int columnas_mapa)
        {
            this.filas_mapa = filas_mapa;
            this.columnas_mapa = columnas_mapa;
            mapa = new Celda[filas_mapa, columnas_mapa];
            CreacionMapa();

            // en su constructor hago que se inicie el mapa
            // al iniciarce el mapa se crea un mapa de celdas, las cuales tienen un tipo de terreno asociado
            // hago que se creen los bitmons
        }

        // Metodo para crear el Mapa
        public void CreacionMapa()
        {
            for (int fila = 0; fila < filas_mapa; fila++)
            {
                for (int columna = 0; columna < columnas_mapa; columna++)
                {
                    int al = random.Next(0, 5);
                    mapa[fila, columna] = new Celda(al);
                    
                }
            }
            CrearBitmon(bitmonsIniciales);
        }

 //---------------------- Metodo para crear los Bitmons en el Mapa----------------------
        public void CrearBitmon(int bitmonsIniciales)
        {
            int contador = 0;

            while (contador < bitmonsIniciales)
            {
                int fila = random.Next(filas_mapa);
                int columna = random.Next(columnas_mapa);
                int al_bit = random.Next(6);
                int tiempoDeVida = random.Next(1,10);

                if (al_bit == 0)
                {
                    if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                    {
                        Wetar bitmon = new Wetar(fila, columna, tiempoDeVida, tiempoDeVida);
                        mapa[fila, columna].AgregarBitmon(bitmon);
                        bitmons_mapa.Add(bitmon);
                        bitmons_mapa_total.Add(bitmon);
                        ;
                        IntercambioDatos.numero_wetar += 1;
                        contador += 1;
                    }
                    else
                    {
                        contador += 0;
                    }
                }
                else if (al_bit == 1)
                {
                    Dorvalo bitmon = new Dorvalo(fila, columna, tiempoDeVida, tiempoDeVida);
                    mapa[fila, columna].AgregarBitmon(bitmon);
                    bitmons_mapa.Add(bitmon);
                    bitmons_mapa_total.Add(bitmon);
                    IntercambioDatos.numero_dorvalo += 1;
                    contador +=1;
                }
                else if (al_bit == 2)
                {
                    Doti bitmon = new Doti(fila, columna, tiempoDeVida, tiempoDeVida);
                    mapa[fila, columna].AgregarBitmon(bitmon);
                    bitmons_mapa.Add(bitmon);
                    bitmons_mapa_total.Add(bitmon);
                    IntercambioDatos.numero_doti += 1;
                    contador += 1;
                }
                else if (al_bit == 3)
                {
                    if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                    {
                        Ent bitmon = new Ent(fila, columna, tiempoDeVida, tiempoDeVida);
                        mapa[fila, columna].AgregarBitmon(bitmon);
                        bitmons_mapa.Add(bitmon);
                        bitmons_mapa_total.Add(bitmon);
                        IntercambioDatos.numero_ent += 1;
                        contador += 1;
                    }
                    else if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                    {
                        Ent bitmon = new Ent(fila, columna, tiempoDeVida, tiempoDeVida);
                        mapa[fila, columna].AgregarBitmon(bitmon);
                        bitmons_mapa.Add(bitmon);
                        bitmons_mapa_total.Add(bitmon);
                        IntercambioDatos.numero_ent += 1;
                        contador += 1;
                    }
                    else if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                    {
                        Ent bitmon = new Ent(fila, columna, tiempoDeVida, tiempoDeVida);
                        mapa[fila, columna].AgregarBitmon(bitmon);
                        bitmons_mapa.Add(bitmon);
                        bitmons_mapa_total.Add(bitmon);
                        IntercambioDatos.numero_ent += 1;
                        contador += 1;
                    }
                    else
                    {
                        contador += 0;
                    }
                    
                }
                else if (al_bit == 4)
                {
                    Gofue bitmon = new Gofue(fila, columna, tiempoDeVida, tiempoDeVida);
                    mapa[fila, columna].AgregarBitmon(bitmon);
                    bitmons_mapa.Add(bitmon);
                    bitmons_mapa_total.Add(bitmon);
                    IntercambioDatos.numero_gofue += 1;
                    contador += 1;
                }
                else if (al_bit == 5)
                {
                    Taplan bitmon = new Taplan(fila, columna, tiempoDeVida, tiempoDeVida);
                    mapa[fila, columna].AgregarBitmon(bitmon);
                    bitmons_mapa.Add(bitmon);
                    bitmons_mapa_total.Add(bitmon);
                    IntercambioDatos.numero_taplan += 1;
                    contador += 1;
                }
                else
                {
                    contador += 0;
                }
            }
        }

        public void CrearBitmon_Reproduccion()
        {
            int fila = random.Next(filas_mapa);
            int columna = random.Next(columnas_mapa);
            int al_bit = random.Next(6);
            int tiempoDeVida = random.Next(1, 10);

            if (al_bit == 0)
            {
                if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "acuatico")
                {
                    Wetar bitmon = new Wetar(fila, columna, tiempoDeVida, tiempoDeVida);
                    mapa[fila, columna].AgregarBitmon(bitmon);
                    bitmons_mapa.Add(bitmon);
                    bitmons_mapa_total.Add(bitmon);
                }
            }
            else if (al_bit == 1)
            {
                Dorvalo bitmon = new Dorvalo(fila, columna, tiempoDeVida, tiempoDeVida);
                mapa[fila, columna].AgregarBitmon(bitmon);
                bitmons_mapa.Add(bitmon);
                bitmons_mapa_total.Add(bitmon);
            }
            else if (al_bit == 2)
            {
                Doti bitmon = new Doti(fila, columna, tiempoDeVida, tiempoDeVida);
                mapa[fila, columna].AgregarBitmon(bitmon);
                bitmons_mapa.Add(bitmon);
                bitmons_mapa_total.Add(bitmon);
            }
            else if (al_bit == 3)
            {
                if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
                {
                    Ent bitmon = new Ent(fila, columna, tiempoDeVida, tiempoDeVida);
                    mapa[fila, columna].AgregarBitmon(bitmon);
                    bitmons_mapa.Add(bitmon);
                    bitmons_mapa_total.Add(bitmon);
                }
                else if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
                {
                    Ent bitmon = new Ent(fila, columna, tiempoDeVida, tiempoDeVida);
                    mapa[fila, columna].AgregarBitmon(bitmon);
                    bitmons_mapa.Add(bitmon);
                    bitmons_mapa_total.Add(bitmon);
                }
                else if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
                {
                    Ent bitmon = new Ent(fila, columna, tiempoDeVida, tiempoDeVida);
                    mapa[fila, columna].AgregarBitmon(bitmon);
                    bitmons_mapa.Add(bitmon);
                    bitmons_mapa_total.Add(bitmon);
                }

            }
            else if (al_bit == 4)
            {
                Gofue bitmon = new Gofue(fila, columna, tiempoDeVida, tiempoDeVida);
                mapa[fila, columna].AgregarBitmon(bitmon);
                bitmons_mapa.Add(bitmon);
                bitmons_mapa_total.Add(bitmon);
            }
            else if (al_bit == 5)
            {
                Taplan bitmon = new Taplan(fila, columna, tiempoDeVida, tiempoDeVida);
                mapa[fila, columna].AgregarBitmon(bitmon);
                bitmons_mapa.Add(bitmon);
                bitmons_mapa_total.Add(bitmon);
            }
        }
        
        public void CrearBitmon_Ent()
        {
            int fila = random.Next(filas_mapa);
            int columna = random.Next(columnas_mapa);
            int tiempoDeVida = random.Next(1, 10);

            if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "vegetacion")
            {
                Ent bitmon = new Ent(fila, columna, tiempoDeVida, tiempoDeVida);
                mapa[fila, columna].AgregarBitmon(bitmon);
                bitmons_mapa.Add(bitmon);
                bitmons_mapa_total.Add(bitmon);
            }
            else if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "desierto")
            {
                Ent bitmon = new Ent(fila, columna, tiempoDeVida, tiempoDeVida);
                mapa[fila, columna].AgregarBitmon(bitmon);
                bitmons_mapa.Add(bitmon);
                bitmons_mapa_total.Add(bitmon);
            }
            else if (mapa[fila, columna].tipo_terreno.Get_Terreno() == "nieve")
            {
                Ent bitmon = new Ent(fila, columna, tiempoDeVida, tiempoDeVida);
                mapa[fila, columna].AgregarBitmon(bitmon);
                bitmons_mapa.Add(bitmon);
                bitmons_mapa_total.Add(bitmon);
            }
        }
    }
}
