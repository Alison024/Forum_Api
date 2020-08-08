using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ForumApi.Persistence.Repositories
{
    public class UserInfoRepository : BaseRepository, IUser_Info_Repository
    {
        public UserInfoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(User_info user_Info)
        {
            await context.User_Info.AddAsync(user_Info);
        }

        public void Delete(User_info user_Info)
        {
            context.User_Info.Remove(user_Info);
        }

        public async Task<User_info> FindByIdAsync(int id)
        {
            return await context.User_Info.FindAsync(id);
        }

        public async Task<IEnumerable<User_info>> GetAllAsync()
        {
            return await context.User_Info.ToListAsync();
        }

        public void Update(User_info user_Info)
        {
            context.User_Info.Update(user_Info);
        }
    }
}