using System.Text.Json.Serialization;

namespace ConsumirApi.app.models.PokeApi
{
    public class Habilidad
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonConstructor]
        public Habilidad()
        {
        }

        public Habilidad(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
