using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirApi.app.models.PokeApi
{
    internal class Habilidades
    {
        public Habilidad ability;
        public Boolean is_hidden;
        public int slot;

        public override string ToString()
        {
            return "Habilidad: " + ability + " | Oculta: " + is_hidden + " | Slot: " + slot;
        }
    }
}
