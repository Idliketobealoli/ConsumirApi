using System.Text.Json.Serialization;

namespace ConsumirApi.app.models.PokeApi
{
    public class Habilidades
    {
        [JsonPropertyName("ability")]
        public Habilidad Ability { get; set; }
        [JsonPropertyName("is_hidden")]
        public bool IsHidden { get; set; }
        [JsonPropertyName("slot")]
        public int Slot { get; set; }

        [JsonConstructor]
        public Habilidades()
        {
        }

        public Habilidades(Habilidad ability, bool is_hidden, int slot)
        {
            Ability = ability;
            IsHidden = is_hidden;
            Slot = slot;
        }

        public override string ToString()
        {
            return $"{Ability} | Oculta: {IsHidden} | Slot: {Slot}";
        }
    }
}
