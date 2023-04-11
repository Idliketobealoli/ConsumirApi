using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirApi.app.models.PokeApi
{
    public class Pokemon
    {
        public string name;
        public int base_experience;
        public List<Habilidades> abilities;

        public Pokemon(string name, int base_experience, List<Habilidades> abilities)
        {
            this.name = name;
            this.base_experience = base_experience;
            this.abilities = abilities;
        }

        public override string ToString()
        {
            return "Pokémon: " + name + " | Experiencia base: " + base_experience + " | Habilidades: " + abilities;
        }
    }
}
