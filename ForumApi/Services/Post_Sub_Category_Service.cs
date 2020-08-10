using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
namespace ForumApi.Services
{
    public class Post_Sub_Category_Service : IPost_Sub_Category_Service
    {
        private readonly IUnit_Of_Work unit_Of_Work;
        private readonly IPost_Sub_Category_Repository post_Sub_Category_Repository;
        public Post_Sub_Category_Service(IUnit_Of_Work unit_Of_Work,IPost_Sub_Category_Repository post_Sub_Category_Repository){
            this.unit_Of_Work = unit_Of_Work;
            this.post_Sub_Category_Repository = post_Sub_Category_Repository;
        }
        public async Task<Post_Sub_Category_Response> DeleteAsync(Post_sub_category post_Sub_Category)
        {
            var isExist = await post_Sub_Category_Repository.FindByCompatibleKeyAsync(post_Sub_Category.Post_Id ,post_Sub_Category.Sub_Category_Id);
            if(isExist == null)
                return new Post_Sub_Category_Response("Post-sub-category doesn't exist!");

            try{
                post_Sub_Category_Repository.Delete(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Post_Sub_Category_Response(isExist);
            }
            catch(Exception ex){
                return new Post_Sub_Category_Response($"Error with deleting post-sub-category: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Post_sub_category>> GetAllAsync()
        {
            return await post_Sub_Category_Repository.GetAllAsync();
        }

        public async Task<IEnumerable<Post_sub_category>> GetPostsWithSubCategory(int sub_Category_Id)
        {
            return await post_Sub_Category_Repository.GetBySubCategoryId(sub_Category_Id);
        }

        public async Task<IEnumerable<Post_sub_category>> GetSubCategoriesOfPost(int post_Id)
        {
            return await post_Sub_Category_Repository.GetByPostId(post_Id);
        }

        public async Task<Post_Sub_Category_Response> SaveAsync(Post_sub_category post_Sub_Category)
        {
            try{
                await post_Sub_Category_Repository.AddAsync(post_Sub_Category);
                await unit_Of_Work.CompleteAsync();
                return new Post_Sub_Category_Response(post_Sub_Category);
            }
            catch(Exception ex){
                return new Post_Sub_Category_Response($"Error while saving post-sub-category. Message:{ex.Message}");
            }
        }

        public async Task<Post_Sub_Category_Response> UpdateAsync(Post_sub_category post_Sub_Category)
        {
            var isExist = await post_Sub_Category_Repository.FindByCompatibleKeyAsync(post_Sub_Category.Post_Id,post_Sub_Category.Sub_Category_Id);
            if (isExist == null)
                return new Post_Sub_Category_Response("Post-sub-category not found!");
            
            try
            {
                post_Sub_Category_Repository.Update(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Post_Sub_Category_Response(isExist);
            }
            catch (Exception ex)
            {
                return new Post_Sub_Category_Response($"Error when updating post-sub-category: {ex.Message}");
            }
        }
    }
}