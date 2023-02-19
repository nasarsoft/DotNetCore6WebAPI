using WebApplication3.Data;
using WebApplication3.Interfaces;
using WebApplication3.Models.Pokemon;

namespace WebApplication3.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FullStackDbContext _DbContext;

        public CategoryRepository(FullStackDbContext fullStackDbContext)
        {
            _DbContext = fullStackDbContext;
        }
        public bool CategoryExists(int id)
        {
             return _DbContext.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
             return _DbContext.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _DbContext.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
             return _DbContext.PokemonCategories.Where(e=>e.CategoryId == categoryId).Select(e => e.Pokemon).ToList();
        }
    }
}
