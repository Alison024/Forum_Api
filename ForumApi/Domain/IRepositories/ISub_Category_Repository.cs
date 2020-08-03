using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;
namespace ForumApi.Domain.IRepositories
{
    public interface ISub_Category_Repository
    {
        Task<IEnumerable<Sub_category>> GetAllAsync();
        Task AddAsync(Sub_category status);
        void Update(Sub_category status);
        Task<Status> FindByIdAsync(int id);
        void Delete(Sub_category status);
    }
}