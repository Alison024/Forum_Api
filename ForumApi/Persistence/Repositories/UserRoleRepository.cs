using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForumApi.Persistence.Repositories
{
    public class UserRoleRepository : BaseRepository, IUser_Role_Repository
    {
        public UserRoleRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(User_role user_Role)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(User_role user_Role)
        {
            throw new System.NotImplementedException();
        }

        public Task<User_role> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User_role>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(User_role user_Role)
        {
            throw new System.NotImplementedException();
        }
    }
}