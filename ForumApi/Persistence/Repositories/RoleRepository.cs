using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ForumApi.Persistence.Repositories
{
    public class RoleRepository : BaseRepository,IRole_Repository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Role role)
        {
            await context.Roles.AddAsync(role);
        }

        public void Delete(Role role)
        {
            context.Roles.Remove(role);
        }

        public async Task<Role> FindByIdAsync(int id)
        {
            return await context.Roles.FindAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await context.Roles.ToListAsync();
        }

        public void Update(Role role)
        {
            context.Roles.Update(role);
        }
    }
}