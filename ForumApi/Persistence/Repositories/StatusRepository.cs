using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ForumApi.Persistence.Repositories
{
    public class StatusRepository : BaseRepository, IStatus_Repository
    {
        public StatusRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Status status)
        {
            await context.Statuses.AddAsync(status);
        }

        public void Delete(Status status)
        {
            context.Statuses.Remove(status);
        }

        public async Task<Status> FindByIdAsync(int id)
        {
            return await context.Statuses.FindAsync(id);
        }

        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            return await context.Statuses.ToListAsync();
        }

        public void Update(Status status)
        {
            context.Statuses.Update(status);
        }
    }
}