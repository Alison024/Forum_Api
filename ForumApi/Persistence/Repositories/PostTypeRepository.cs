using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForumApi.Persistence.Repositories
{
    public class PostTypeRepository : BaseRepository, IPost_Type_Repository
    {
        public PostTypeRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(Post_type post_Type)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Post_type post_Type)
        {
            throw new System.NotImplementedException();
        }

        public Task<Post_type> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Post_type>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Post_type post_Type)
        {
            throw new System.NotImplementedException();
        }
    }
}