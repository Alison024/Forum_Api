using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;
namespace ForumApi.Domain.IRepositories
{
    public interface IAvatar_Images_Repository
    {
        Task<IEnumerable<Avatar_image>> GetAllAsync();
        Task AddAsync(Avatar_image img);
        void Update(Avatar_image img);
        Task<Avatar_image> FindByIdAsync(int id);
        void Delete(Avatar_image img);
    }
}