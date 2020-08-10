using ForumApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Responses;
namespace ForumApi.Domain.IServices
{
    public interface IPost_Image_Service
    {
        Task<IEnumerable<Post_image>> GetAllAsync();
        Task<IEnumerable<Post_image>> GetImagesOfPost(int post_Id);
        Task<Post_Image_Response> SaveAsync(Post_image post_Image);
        Task<Post_Image_Response> UpdateAsync(Post_image post_Image);
        Task<Post_Image_Response> DeleteAsync(Post_image post_Image);
    }
}