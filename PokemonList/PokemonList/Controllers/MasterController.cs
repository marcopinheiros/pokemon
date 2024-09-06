using Microsoft.AspNetCore.Mvc;
using PokemonList.Data;
using PokemonList.Models;
using System.Threading.Tasks;

namespace PokemonList.Controllers
{
    public class MasterController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MasterController(AppDbContext context)
        {
            _context = context;
        }

        

        [HttpPost("master")]
        public async Task<IActionResult> Create(int id, string name,int age, string cpf)
        {
            var master = new Master
            {
                Id = id,
                Name = name,
                Age = age,
                CPF = cpf
            };

            _context.Masters.Add(master);
            await _context.SaveChangesAsync();
            return Ok("Mestre pokemon regitsrado com sucesso!!!");
        }

    }
}
