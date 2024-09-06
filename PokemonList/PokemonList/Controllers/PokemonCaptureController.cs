using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonList.Data;
using PokemonList.Models;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PokemonCaptureController : ControllerBase
{
    private readonly AppDbContext _context;

    public PokemonCaptureController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("capture")]
    public async Task<IActionResult> Capture(int pokemonId, string pokemonName, int masterId)
    {
        var capturedPokemon = new CapturedPokemon
        {
            PokemonId = pokemonId,
            PokemonName = pokemonName,
            MasterId = masterId
        };

        _context.CapturedPokemons.Add(capturedPokemon);
        await _context.SaveChangesAsync();
        return Ok("Pokémon capturado com sucesso!");
    }

    [HttpGet("captured")]
    public async Task<IActionResult> ListCapturedPokemons()
    {
        var capturedPokemons = await _context.CapturedPokemons.ToListAsync();
        return Ok(capturedPokemons);
    }
}
