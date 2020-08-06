using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForumApi.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategory_Repository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}