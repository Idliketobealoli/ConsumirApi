using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirApi.app.models.PokeApi
{
    public class Habilidades
    {
        public Habilidad ability;
        public bool is_hidden;
        public int slot;

        public Habilidades(Habilidad ability, bool is_hidden, int slot)
        {
            this.ability = ability;
            this.is_hidden = is_hidden;
            this.slot = slot;
        }

        public override string ToString()
        {
            return "Habilidad: " + ability + " | Oculta: " + is_hidden + " | Slot: " + slot;
        }
    }
}
