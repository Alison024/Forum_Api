using ForumApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Responses;
namespace ForumApi.Domain.IServices
{
    public interface IPost_Service
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> GetById(int id);
        Task<Post_Response> SaveAsync(Post post);
        Task<Post_Response> UpdateAsync(Post post);
        Task<Post_Response> DeleteAsync(int id);
    }
}