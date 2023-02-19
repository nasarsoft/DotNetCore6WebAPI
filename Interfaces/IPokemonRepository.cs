using WebApplication3.Models.Pokemon;

namespace WebApplication3.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();

        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        decimal GetPokemonRating(int pokeId );
        bool PokemonExists(int pokeId);
    }
}
