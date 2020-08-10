using ForumApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Responses;
namespace ForumApi.Domain.IServices
{
    public interface IUser_Info_Service
    {
        Task<IEnumerable<User_info>> GetAllAsync();
        Task<User_info> GetById(int id);
        Task<User_Info_Response> SaveAsync(User_info user_Info);
        Task<User_Info_Response> UpdateAsync(User_info user_Info);
        Task<User_Info_Response> DeleteAsync(User_info user_Info);
    }
}