using ConsumirApi.app.models.PokeApi;
using System.Net.Http.Json;

namespace ConsumirApi.app.models.consumo
{
    public class Consumidor
    {
        public static HashSet<Pokemon> Pokemons { get; set; }
        private static HttpClient Client = new();
        private static string Url = "https://pokeapi.co/api/v2/pokemon/";

        public Consumidor()
        {
            Pokemons = new();
        }

        public void Show()
        {
            Console.WriteLine($"*** --- Pokemons en total: {Pokemons.Count}");
            foreach ( var pokemon in Pokemons )
            {
                Console.WriteLine(pokemon.ToString());
            }
        }

        public void Show(string name)
        {
            var res = from pokemon in Pokemons
                      where pokemon.Name.ToLower() == name.ToLower()
                      select pokemon;
            Console.WriteLine(res.FirstOrDefault());
        }

        public async void Find(string name)
        {
            Pokemon? p = null;
            var response = await Client.GetAsync($"{Url}{name.ToLower()}");

            if (response.IsSuccessStatusCode)
            {
                p = await response.Content.ReadFromJsonAsync<Pokemon>();
            }

            if (p != null && p.Name != null)
            {
                Console.WriteLine(p.ToString());
                var pokemons = from pokemon in Pokemons
                               where pokemon.Name.ToLower() != p.Name.ToLower()
                               select pokemon;
                Pokemons = pokemons.ToHashSet();
                Pokemons.Add(p);
                Console.WriteLine("Pokemon added.");
            }
        }
    }
}
