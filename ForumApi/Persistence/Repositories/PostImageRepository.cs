using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ForumApi.Persistence.Repositories
{
    public class PostImageRepository : BaseRepository, IPost_Image_Repository
    {
        public PostImageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Post_image post_Image)
        {
            await context.Post_Images.AddAsync(post_Image);
        }

        public void Delete(Post_image post_Image)
        {
            context.Post_Images.Remove(post_Image);
        }

        public async Task<Post_image> FindByIdAsync(int id)
        {
            return await context.Post_Images.FindAsync(id);
        }

        public async Task<IEnumerable<Post_image>> GetAllAsync()
        {
            return await context.Post_Images.ToListAsync();
        }

        public void Update(Post_image post_Image)
        {
            context.Post_Images.Update(post_Image);
        }
    }
}