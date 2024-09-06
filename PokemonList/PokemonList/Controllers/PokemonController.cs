using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonList.Services;

namespace PokemonList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly PokeApiService _pokeApiService;

        public PokemonController(PokeApiService pokeApiService)
        {
            _pokeApiService = pokeApiService;
        }

        
        [HttpGet("random")]
        public async Task<IActionResult> GetRandomPokemon()
        {
            var randomPokemons = await _pokeApiService.GetRandomPokemonAsync();
            return Ok(randomPokemons);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pokemon = await _pokeApiService.GetPokemonByIdAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            return Ok(pokemon);
        }

       
    }
}
