using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;
namespace ForumApi.Domain.IRepositories
{
    public interface IPost_Type_Repository
    {
        Task<IEnumerable<Post_type>> GetAllAsync();
        Task AddAsync(Post_type post_Type);
        void Update(Post_type post_Type);
        Task<Post_type> FindByIdAsync(int id);
        void Delete(Post_type post_Type);
    }
}