using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForumApi.Persistence.Repositories
{
    public class PostRepository : BaseRepository, IPost_Repository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(Post post)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Post post)
        {
            throw new System.NotImplementedException();
        }

        public Task<Post> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Post post)
        {
            throw new System.NotImplementedException();
        }
    }
}