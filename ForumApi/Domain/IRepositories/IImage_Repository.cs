using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;
namespace ForumApi.Domain.IRepositories
{
    public interface IImage_Repository
    {
        Task<IEnumerable<Image>> GetAllAsync();
        Task AddAsync(Image img);
        void Update(Image img);
        Task<Image> FindByIdAsync(int id);
        void Delete(Image img);
    }
}