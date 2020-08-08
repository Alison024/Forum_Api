using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ForumApi.Persistence.Repositories
{
    public class PostTypeRepository : BaseRepository, IPost_Type_Repository
    {
        public PostTypeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Post_type post_Type)
        {
            await context.Post_Types.AddAsync(post_Type);
        }

        public void Delete(Post_type post_Type)
        {
            context.Post_Types.Remove(post_Type);
        }

        public async Task<Post_type> FindByIdAsync(int id)
        {
            return await context.Post_Types.FindAsync(id);
        }

        public async Task<IEnumerable<Post_type>> GetAllAsync()
        {
            return await context.Post_Types.ToListAsync();
        }

        public void Update(Post_type post_Type)
        {
            context.Post_Types.Update(post_Type);
        }
    }
}