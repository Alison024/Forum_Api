using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;
namespace ForumApi.Domain.IRepositories
{
    public interface IRole_Repository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task AddAsync(Role role);
        void Update(Role role);
        Task<Role> FindByIdAsync(int id);
        void Delete(Role role);
    }
}