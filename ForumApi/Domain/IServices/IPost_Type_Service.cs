using ForumApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Responses;
namespace ForumApi.Domain.IServices
{
    public interface IPost_Type_Service
    {
        Task<IEnumerable<Post_type>> GetAllAsync();
        Task<Post_type> GetById(int id);
        Task<Post_Type_Response> SaveAsync(Post_type post_Type);
        Task<Post_Type_Response> UpdateAsync(Post_type post_Type);
        Task<Post_Type_Response> DeleteAsync(int id);
    }
}