using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ForumApi.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategory_Repository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Category category)
        {
            await context.Categories.AddAsync(category);
        }

        public void Delete(Category category)
        {
            context.Categories.Remove(category);
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public void Update(Category category)
        {
            context.Categories.Update(category);
        }
    }
}