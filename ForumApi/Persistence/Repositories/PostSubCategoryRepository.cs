using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ForumApi.Persistence.Repositories
{
    public class PostSubCategoryRepository : BaseRepository, IPost_Sub_Category_Repository
    {
        public PostSubCategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Post_sub_category post_Sub_Category)
        {
            await context.Post_Sub_Categories.AddAsync(post_Sub_Category);
        }

        public void Delete(Post_sub_category post_Sub_Category)
        {
            context.Post_Sub_Categories.Remove(post_Sub_Category);
        }

        public async Task<Post_sub_category> FindByIdAsync(int id)
        {
            return await context.Post_Sub_Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Post_sub_category>> GetAllAsync()
        {
            return await context.Post_Sub_Categories.ToListAsync();
        }

        public void Update(Post_sub_category post_Sub_Category)
        {
            context.Post_Sub_Categories.Update(post_Sub_Category);
        }
    }
}