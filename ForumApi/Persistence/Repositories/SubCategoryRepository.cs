using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForumApi.Persistence.Repositories
{
    public class SubCategoryRepository : BaseRepository, ISub_Category_Repository
    {
        public SubCategoryRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(Sub_category status)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Sub_category status)
        {
            throw new System.NotImplementedException();
        }

        public Task<Status> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Sub_category>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Sub_category status)
        {
            throw new System.NotImplementedException();
        }
    }
}