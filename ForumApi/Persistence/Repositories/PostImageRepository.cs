using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForumApi.Persistence.Repositories
{
    public class PostImageRepository : BaseRepository, IPost_Image_Repository
    {
        public PostImageRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(Post_image post_Image)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Post_image post_Image)
        {
            throw new System.NotImplementedException();
        }

        public Task<Post_image> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Post_image>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Post_image post_Image)
        {
            throw new System.NotImplementedException();
        }
    }
}