using ForumApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Responses;
namespace ForumApi.Domain.IServices
{
    public interface IUser_Role_Service
    {
        Task<IEnumerable<User_role>> GetAllAsync();
        Task<IEnumerable<User_role>> GetRolesOfUser(int user_Id);
        Task<IEnumerable<User_role>> GetUsersWithRole(int role_Id);
        Task<User_Role_Response> SaveAsync(User_role user_Role);
        Task<User_Role_Response> UpdateAsync(User_role user_Role);
        Task<User_Role_Response> DeleteAsync(User_role user_Role);
    }
}