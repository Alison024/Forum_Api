using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ForumApi.Persistence.Repositories
{
    public class PostRepository : BaseRepository, IPost_Repository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Post post)
        {
            await context.Posts.AddAsync(post);
        }

        public void Delete(Post post)
        {
            context.Posts.Remove(post);
        }

        public async Task<Post> FindByIdAsync(int id)
        {
            return await context.Posts.FindAsync(id);
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await context.Posts.Include(x=>x.Post_Sub_Categories).ThenInclude(x=>x.Sub_Categories)
            .Include(x=>x.Post_Images).ThenInclude(x=>x.Image)
            .Include(x=>x.Post_Type).ToListAsync();
        }

        public void Update(Post post)
        {
            context.Posts.Update(post);
        }
    }
}