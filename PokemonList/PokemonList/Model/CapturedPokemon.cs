using System.ComponentModel.DataAnnotations;

namespace PokemonList.Models
{
    public class CapturedPokemon
    {
        [Key]
        public int Id { get; set; }

        public string PokemonName { get; set; }
        public int PokemonId { get; set; }
        public int MasterId { get; set; }
    }
}
