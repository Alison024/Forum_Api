using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<Post_sub_category> FindByCompatibleKeyAsync(int post_Id,int sub_Category_Id)
        {
            return await context.Post_Sub_Categories.SingleOrDefaultAsync(x=>x.Post_Id==post_Id && x.Sub_Category_Id==sub_Category_Id);
        }
        public async Task<IEnumerable<Post_sub_category>> GetByPostId(int post_Id)
        {
            return await context.Post_Sub_Categories.Where(x=>x.Post_Id == post_Id).ToListAsync();
        }
        public async Task<IEnumerable<Post_sub_category>> GetBySubCategoryId(int sub_Category_Id)
        {
            return await context.Post_Sub_Categories.Where(x=>x.Sub_Category_Id == sub_Category_Id).ToListAsync();
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