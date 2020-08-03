using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;
namespace ForumApi.Domain.IRepositories
{
    public interface ICategory_Repository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category category);
        void Update(Category category);
        Task<Category> FindByIdAsync(int id);
        void Delete(Category category);
    }
}