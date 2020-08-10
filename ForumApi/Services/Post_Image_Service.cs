using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
namespace ForumApi.Services
{
    public class Post_Image_Service : IPost_Image_Service
    {
        private readonly IUnit_Of_Work unit_Of_Work;
        private readonly IPost_Image_Repository post_Image_Repository;
        public Post_Image_Service(IUnit_Of_Work unit_Of_Work,IPost_Image_Repository post_Image_Repository){
            this.unit_Of_Work = unit_Of_Work;
            this.post_Image_Repository = post_Image_Repository;
        }
        public async Task<Post_Image_Response> DeleteAsync(Post_image post_Image)
        {
            var isExist = await post_Image_Repository.FindByCompatibleKeyAsync(post_Image.Post_Id,post_Image.Image_Id);
            if(isExist == null)
                return new Post_Image_Response("Post-image doesn't exist!");

            try{
                post_Image_Repository.Delete(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Post_Image_Response(isExist);
            }
            catch(Exception ex){
                return new Post_Image_Response($"Error with deleting post-image: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Post_image>> GetAllAsync()
        {
            return await post_Image_Repository.GetAllAsync();
        }

        public async Task<IEnumerable<Post_image>> GetImagesOfPost(int post_Id)
        {
            return await post_Image_Repository.GetByPostId(post_Id);
        }

        public async Task<Post_Image_Response> SaveAsync(Post_image post_Image)
        {
            try{
                await post_Image_Repository.AddAsync(post_Image);
                await unit_Of_Work.CompleteAsync();
                return new Post_Image_Response(post_Image);
            }
            catch(Exception ex){
                return new Post_Image_Response($"Error while saving post-image. Message:{ex.Message}");
            }
        }

        public async Task<Post_Image_Response> UpdateAsync(Post_image post_Image)
        {
            var isExist = await post_Image_Repository.FindByCompatibleKeyAsync(post_Image.Post_Id,post_Image.Image_Id);
            if (isExist == null)
                return new Post_Image_Response("Post-image not found!");
            try
            {
                post_Image_Repository.Update(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Post_Image_Response(isExist);
            }
            catch (Exception ex)
            {
                return new Post_Image_Response($"Error when updating post-image: {ex.Message}");
            }
        }
    }
}