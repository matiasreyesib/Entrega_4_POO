using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3
{
    public class Celda
    {
        public Terreno tipo_terreno;
        public List<Bitmon> bitmons_celda = new List<Bitmon>();
        //public Bitmon bitmons_mapa;

        public Celda(int al)
        {
            Set_TipoTerreno(al);
            // Con esto obtenemos el tipo de terreno que tiene
            // tipo_terreno.get_tipo_terreno();
        }

        public void Set_TipoTerreno(int al)
        {
            if (al == 0)
            {
                tipo_terreno = new Acuatico();
            }
            if (al == 1)
            {
                tipo_terreno = new Desierto();
            }
            if (al == 2)
            {
                tipo_terreno = new Vegetacion();
            }
            if (al == 3)
            {
                tipo_terreno = new Nieve();
            }
            if (al == 4)
            {
                tipo_terreno = new Volcan();
            }
        }

        public void AgregarBitmon(Bitmon bitmon)
        {
            bitmons_celda.Add(bitmon);
        }
    }
}
