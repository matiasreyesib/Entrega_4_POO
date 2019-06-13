using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3
{
    public abstract class Bitmon
    {
        Random rnd = new Random();
        protected int tiempoDeVida;
        protected int esperanzaVida;
        protected int puntosDeVida;
        protected int puntosDeAtaque;
        protected string especie;
        protected int cantidadDeHijos;
        protected int posx;
        protected int posy;


        public abstract int Get_TiempoDeVida();
        public abstract int Get_esperanza();
        // Desde aca meto los metodos de la entrega pasada
        public abstract Terreno CambioTerreno(int a);
        public abstract int Daño(Bitmon bitmon);
        // Para retornar la 'Especie' del bitmon
        public abstract string Get_Especie();
        // Retornamos el nombre de la especie vacio, para poder hacer que 
        // desaparezca el nombre del bitmon cuando se mueve
        public abstract string Get_Especie_Vacio();
        // Nos da la posision 'x' del Bitmon
        public abstract int Get_Posx();
        // Nos da la posision 'y' del Bitmon
        public abstract int Get_Posy();
        // Para ver cuando un bitmon muere
        public bool Muere()
        {
            if (tiempoDeVida == 0 || puntosDeVida == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Para aumentar la cantidad de hijos cuando se reproduce
        public void Reproducirse(Mapa mapa)
        {
            mapa.CrearBitmon_Reproduccion();
            cantidadDeHijos += 1;
        }
        // Reduce el tiempo de vida mientras pasan los meses
        public abstract void ReducirTiempoDeVida(int numero);
        // Reduce los puntos de vida por algun ataque
        public void ReducirPuntosDeVida(int ataque)
        {
            puntosDeVida -= ataque;
        }
        // La afinidad que tiene con el terreno
        public abstract void Moverse(Mapa mapa);
    }
}
