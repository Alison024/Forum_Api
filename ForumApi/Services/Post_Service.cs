using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
namespace ForumApi.Services
{
    public class Post_Service : IPost_Service
    {
        private readonly IUnit_Of_Work unit_Of_Work;
        private readonly IPost_Repository post_Repository;
        public Post_Service(IUnit_Of_Work unit_Of_Work,IPost_Repository post_Repository){
            this.unit_Of_Work = unit_Of_Work;
            this.post_Repository = post_Repository;
        }
        public async Task<Post_Response> DeleteAsync(int id)
        {
           var isExist = await post_Repository.FindByIdAsync(id);
            if(isExist == null)
                return new Post_Response("Post doesn't exist!");

            try{
                post_Repository.Delete(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Post_Response(isExist);
            }
            catch(Exception ex){
                return new Post_Response($"Error with deleting post: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await post_Repository.GetAllAsync();
        }

        public async Task<Post> GetById(int id)
        {
            return await post_Repository.FindByIdAsync(id);
        }

        public async Task<Post_Response> SaveAsync(Post post)
        {
            try{
                
                await post_Repository.AddAsync(post);
                await unit_Of_Work.CompleteAsync();
                return new Post_Response(post);
            }
            catch(Exception ex){
                return new Post_Response($"Error while saving post. Message:{ex.Message}");
            }
        }

        public async Task<Post_Response> UpdateAsync(Post post)
        {
            var isExist = await post_Repository.FindByIdAsync(post.Id);
            if (isExist == null)
                return new Post_Response("Post not found!");
            try
            {
                post_Repository.Update(post);
                await unit_Of_Work.CompleteAsync();
                return new Post_Response(post);
            }
            catch (Exception ex)
            {
                return new Post_Response($"Error when updating post: {ex.Message}");
            }
        }
    }
}