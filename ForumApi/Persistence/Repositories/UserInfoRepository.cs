using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForumApi.Persistence.Repositories
{
    public class UserInfoRepository : BaseRepository, IUser_Info_Repository
    {
        public UserInfoRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(User_info status)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(User_info user_Info)
        {
            throw new System.NotImplementedException();
        }

        public Task<User_info> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User_info>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(User_info user_Info)
        {
            throw new System.NotImplementedException();
        }
    }
}