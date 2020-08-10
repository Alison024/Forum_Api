using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;
namespace ForumApi.Domain.IRepositories
{
    public interface IPost_Image_Repository
    {
        Task<IEnumerable<Post_image>> GetAllAsync();
        Task AddAsync(Post_image post_Image);
        void Update(Post_image post_Image);
        Task<Post_image> FindByCompatibleKeyAsync(int post_Id, int image_Id);
        Task<IEnumerable<Post_image>> GetByPostId(int post_Id);
        Task<IEnumerable<Post_image>> GetByImageId(int image_Id);
        void Delete(Post_image post_Image);
    }
}