using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;
namespace ForumApi.Domain.IRepositories
{
    public interface IPost_Sub_Category_Repository
    {
        Task<IEnumerable<Post_sub_category>> GetAllAsync();
        Task AddAsync(Post_sub_category post_Sub_Category);
        void Update(Post_sub_category post_Sub_Category);
        Task<Post_sub_category> FindByCompatibleKeyAsync(int post_Id,int sub_Category_Id);
        Task<IEnumerable<Post_sub_category>> GetByPostId(int post_Id);
        Task<IEnumerable<Post_sub_category>> GetBySubCategoryId(int sub_Category_Id);
        void Delete(Post_sub_category post_Sub_Category);
    }
}