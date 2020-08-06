using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForumApi.Persistence.Repositories
{
    public class PostSubCategoryRepository : BaseRepository, IPost_Sub_Category_Repository
    {
        public PostSubCategoryRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(Post_sub_category post_Sub_Category)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Post_sub_category post_Sub_Category)
        {
            throw new System.NotImplementedException();
        }

        public Task<Post_sub_category> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Post_sub_category>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Post_sub_category post_Sub_Category)
        {
            throw new System.NotImplementedException();
        }
    }
}