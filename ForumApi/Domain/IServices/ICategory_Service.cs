using ForumApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Responses;
namespace ForumApi.Domain.IServices
{
    public interface ICategory_Service
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetById(int id);
        Task<Category_Response> SaveAsync(Category category);
        Task<Category_Response> UpdateAsync(Category category);
        Task<Category_Response> DeleteAsync(int id);
    }
}