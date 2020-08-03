using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;
namespace ForumApi.Domain.IRepositories
{
    public interface IStatus_Repository
    {
        Task<IEnumerable<Status>> GetAllAsync();
        Task AddAsync(Status status);
        void Update(Status status);
        Task<Status> FindByIdAsync(int id);
        void Delete(Status status);
    }
}