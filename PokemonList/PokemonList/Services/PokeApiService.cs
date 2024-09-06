using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokemonList.Services
{
    public class PokeApiService
    {
        private readonly HttpClient _httpClient;
        

        public PokeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método para obter 10 Pokémon aleatórios
        public async Task<List<Pokemon>> GetRandomPokemonAsync(int count = 10)
        {
            var random = new Random();
            var pokemonTasks = new List<Task<Pokemon>>();

            // IDs aleatórios entre 1 e 1010
            var randomIds = Enumerable.Range(1, 1010)
                                      .OrderBy(x => random.Next())
                                      .Take(count);

            foreach (var id in randomIds)
            {
                pokemonTasks.Add(GetPokemonByIdAsync(id));
            }

            // Aguarda todas as requisições serem concluídas
            var pokemons = await Task.WhenAll(pokemonTasks);

            return pokemons.ToList();
        }

        // Método para buscar um Pokémon específico pelo ID
        public async Task<Pokemon> GetPokemonByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}/");
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Pokemon>(jsonResult);
            }
            return null;
        }
    }

    public class Pokemon
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public PokemonSprites Sprites { get; set; }
    }

    public class PokemonSprites
    {
        public string Front_Default { get; set; } // Imagem do Pokémon
    }
}
