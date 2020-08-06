using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;
namespace ForumApi.Domain.IRepositories
{
    public interface IUser_Repository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        void Update(User user);
        Task<User> FindByIdAsync(int id);
        void Delete(User user);
    }
}