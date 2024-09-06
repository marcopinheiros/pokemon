using System.ComponentModel.DataAnnotations;

namespace PokemonList.Models
{
    public class Master
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [StringLength(11)]
        public string CPF { get; set; }
    }
}
