using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;
namespace ForumApi.Domain.IRepositories
{
    public interface IUser_Info_Repository
    {
        Task<IEnumerable<User_info>> GetAllAsync();
        Task AddAsync(User_info status);
        void Update(User_info user_Info);
        Task<User_info> FindByIdAsync(int id);
        void Delete(User_info user_Info);
    }
}