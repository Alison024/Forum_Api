using ForumApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Responses;
namespace ForumApi.Domain.IServices
{
    public interface IImage_Service
    {
        Task<IEnumerable<Image>> GetAllAsync();
        Task<Image> GetById(int id);
        Task<Image_Response> SaveAsync(Image image);
        Task<Image_Response> UpdateAsync(Image image);
        Task<Image_Response> DeleteAsync(Image image);
    }
}