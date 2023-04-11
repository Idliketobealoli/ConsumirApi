using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirApi.app.models.PokeApi
{
    public class Habilidad
    {
        public string name;

        public Habilidad(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return "Habilidad: " + name;
        }
    }

}
