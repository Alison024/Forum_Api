using ForumApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Responses;
namespace ForumApi.Domain.IServices
{
    public interface IRole_Service
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetById(int id);
        Task<Role_Response> SaveAsync(Role role);
        Task<Role_Response> UpdateAsync(Role role);
        Task<Role_Response> DeleteAsync(int id);
    }
}