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

        public Pokemon GetPokemon(int id)
        {
           return _DbContext.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
           return _DbContext.Pokemon.Where( p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _DbContext.Reviews.Where(p => p.Id == pokeId);
            if(review.Count()<=0)
                return 0;
            return ((decimal)review.Sum(r=>r.Rating)/review.Count() );
        }

        public ICollection<Pokemon> GetPokemons() 
        {
            return _DbContext.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int pokeId)
        {
           return _DbContext.Pokemon.Any(p=> p.Id == pokeId);
        }
    }
}
