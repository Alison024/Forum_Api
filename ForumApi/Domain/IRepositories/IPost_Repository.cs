using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;
namespace ForumApi.Domain.IRepositories
{
    public interface IPost_Repository
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task AddAsync(Post post);
        void Update(Post post);
        Task<Post> FindByIdAsync(int id);
        void Delete(Post post);
    }
}