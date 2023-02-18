using WebApplication3.Models.Pokemon;

namespace WebApplication3.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
    }
}
