using ForumApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Responses;
namespace ForumApi.Domain.IServices
{
    public interface IUser_Service
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetById(int id);
        Task<User_Response> SaveAsync(User user);
        Task<User_Response> UpdateAsync(User user);
        Task<User_Response> DeleteAsync(int id);
    }
}