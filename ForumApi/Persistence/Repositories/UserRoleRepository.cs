using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ForumApi.Persistence.Repositories
{
    public class UserRoleRepository : BaseRepository, IUser_Role_Repository
    {
        public UserRoleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(User_role user_Role)
        {
            await context.User_Roles.AddAsync(user_Role);
        }

        public void Delete(User_role user_Role)
        {
            context.User_Roles.Remove(user_Role);
        }

        public async Task<User_role> FindByIdAsync(int id)
        {
            return await context.User_Roles.FindAsync(id);
        }

        public async Task<IEnumerable<User_role>> GetAllAsync()
        {
            return await context.User_Roles.ToListAsync();
        }

        public void Update(User_role user_Role)
        {
            context.User_Roles.Update(user_Role);
        }
    }
}