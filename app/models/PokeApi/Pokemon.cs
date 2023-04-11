using System.Text.Json.Serialization;

namespace ConsumirApi.app.models.PokeApi
{
    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("base_experience")]
        public int BaseExperience { get; set; }
        [JsonPropertyName("abilities")]
        public List<Habilidades> Abilities { get; set; }

        [JsonConstructor]
        public Pokemon()
        {
        }

        public Pokemon(string name, int base_experience, List<Habilidades> abilities)
        {
            Name = name;
            BaseExperience = base_experience;
            Abilities = abilities;
        }

        public override string ToString()
        {
            var tostring = "Pokémon: " + Name + 
                "\nExperiencia base: " + BaseExperience +
                "\nHabilidades: \n[\n";

            if ( Abilities != null )
            {
                foreach (var item in Abilities)
                {
                    tostring += $"   {item}\n";
                }
            }
            tostring += "]";
            return tostring;
        }
    }
}
