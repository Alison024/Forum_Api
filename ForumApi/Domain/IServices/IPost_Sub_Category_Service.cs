using ForumApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Responses;
namespace ForumApi.Domain.IServices
{
    public interface IPost_Sub_Category_Service
    {
        Task<IEnumerable<Post_sub_category>> GetAllAsync();
        Task<IEnumerable<Post_sub_category>> GetSubCategoriesOfPost(int post_Id);
        Task<IEnumerable<Post_sub_category>> GetPostsWithSubCategory(int sub_Category_Id);
        Task<Post_Sub_Category_Response> SaveAsync(Post_sub_category post_Sub_Category);
        Task<Post_Sub_Category_Response> UpdateAsync(Post_sub_category post_Sub_Category);
        Task<Post_Sub_Category_Response> DeleteAsync(Post_sub_category post_Sub_Category);
    }
}