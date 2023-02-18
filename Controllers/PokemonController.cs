using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Interfaces;
using WebApplication3.Models.Pokemon;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        

        public PokemonController(IPokemonRepository pokemonRepository  ) {
            _pokemonRepository = pokemonRepository;
       
        }


        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons= _pokemonRepository.GetPokemons();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }
    }
}
