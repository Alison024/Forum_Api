using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;
namespace ForumApi.Domain.IRepositories
{
    public interface IUser_Role_Repository
    {
        Task<IEnumerable<User_role>> GetAllAsync();
        Task AddAsync(User_role user_Role);
        void Update(User_role user_Role);
        Task<User_role> FindByCompatibleKeyAsync(int user_Id,int role_Id);
        Task<IEnumerable<User_role>> GetByUserId(int user_Id);
        Task<IEnumerable<User_role>> GetByRoleId(int role_Id);
        void Delete(User_role user_Role);
    }
}