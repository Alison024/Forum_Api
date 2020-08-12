using ForumApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Responses;
namespace ForumApi.Domain.IServices
{
    public interface IAvatar_Image_Service
    {
        Task<IEnumerable<Avatar_image>> GetAllAsync();
        Task<Avatar_image> GetById(int id);
        Task<Avatar_Image_Response> SaveAsync(Avatar_image avatar_Image);
        Task<Avatar_Image_Response> UpdateAsync(Avatar_image avatar_Image);
        Task<Avatar_Image_Response> DeleteAsync(int id);
    }
}