using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForumApi.Persistence.Repositories
{
    public class RoleRepository : BaseRepository,IRole_Repository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(Role role)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Role role)
        {
            throw new System.NotImplementedException();
        }

        public Task<Role> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Role role)
        {
            throw new System.NotImplementedException();
        }
    }
}