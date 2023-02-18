using WebApplication3.Data;
using WebApplication3.Interfaces;
using WebApplication3.Models.Pokemon;

namespace WebApplication3.Repository
{
    public class PokemonRepository: IPokemonRepository
    {
        private readonly FullStackDbContext _DbContext;
        public PokemonRepository(FullStackDbContext fullStackDbContext) {
            _DbContext = fullStackDbContext;
        }

        public ICollection<Pokemon> GetPokemons() 
        {
            return _DbContext.Pokemon.OrderBy(p => p.Id).ToList();
        }


    }
}
