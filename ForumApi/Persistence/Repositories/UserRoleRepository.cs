using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<User_role> FindByCompatibleKeyAsync(int user_Id,int role_Id)
        {
            return await context.User_Roles.SingleOrDefaultAsync(x=>x.User_Id==user_Id && x.Role_Id == role_Id);
        }

        public async Task<IEnumerable<User_role>> GetByUserId(int user_Id)
        {
            return await context.User_Roles.Where(x=>x.User_Id == user_Id).ToListAsync();
        }
        public async Task<IEnumerable<User_role>> GetByRoleId(int role_Id)
        {
            return await context.User_Roles.Where(x=>x.Role_Id == role_Id).ToListAsync();
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