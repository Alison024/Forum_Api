using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ForumApi.Persistence.Repositories
{
    public class SubCategoryRepository : BaseRepository, ISub_Category_Repository
    {
        public SubCategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Sub_category sub_Category)
        {
            await context.Sub_Categories.AddAsync(sub_Category);
        }

        public void Delete(Sub_category sub_Category)
        {
            context.Sub_Categories.Remove(sub_Category);
        }

        public async Task<Sub_category> FindByIdAsync(int id)
        {
            return await context.Sub_Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Sub_category>> GetAllAsync()
        {
            return await context.Sub_Categories.Include(x=>x.Category_Id).ToListAsync();
        }

        public void Update(Sub_category sub_Category)
        {
            context.Sub_Categories.Update(sub_Category);
        }
    }
}