using ForumApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Responses;
namespace ForumApi.Domain.IServices
{
    public interface IStatus_Service
    {
        Task<IEnumerable<Status>> GetAllAsync();
        Task<Status> GetById(int id);
        Task<Status_Response> SaveAsync(Status status);
        Task<Status_Response> UpdateAsync(Status status);
        Task<Status_Response> DeleteAsync(int id);
    }
}