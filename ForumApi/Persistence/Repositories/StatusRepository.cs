using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForumApi.Persistence.Repositories
{
    public class StatusRepository : BaseRepository, IStatus_Repository
    {
        public StatusRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(Status status)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Status status)
        {
            throw new System.NotImplementedException();
        }

        public Task<Status> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Status>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Status status)
        {
            throw new System.NotImplementedException();
        }
    }
}