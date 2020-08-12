using ForumApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Responses;
namespace ForumApi.Domain.IServices
{
    public interface ISub_Category_Service
    {
        Task<IEnumerable<Sub_category>> GetAllAsync();
        Task<Sub_category> GetById(int id);
        Task<Sub_Category_Response> SaveAsync(Sub_category sub_Category);
        Task<Sub_Category_Response> UpdateAsync(Sub_category sub_Category);
        Task<Sub_Category_Response> DeleteAsync(int id);
    }
}