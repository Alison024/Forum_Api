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
        Task<Post_image> FindByIdAsync(int id);
        void Delete(Post_image post_Image);
    }
}