using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ForumApi.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUser_Repository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user);
        }

        public void Delete(User user)
        {
            context.Users.Remove(user);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.Users.Include(x=>x.User_Roles).ThenInclude(x=>x.Role).Include(x=>x.User_Info).ToListAsync();
        }

        public void Update(User user)
        {
            context.Users.Update(user);
        }
    }
}