using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
namespace ForumApi.Services
{
    public class Post_Type_Service : IPost_Type_Service
    {
        private readonly IUnit_Of_Work unit_Of_Work;
        private readonly IPost_Type_Repository post_Type_Repository;
        public Post_Type_Service(IUnit_Of_Work unit_Of_Work,IPost_Type_Repository post_Type_Repository){
            this.unit_Of_Work = unit_Of_Work;
            this.post_Type_Repository = post_Type_Repository;
        }
        public async Task<Post_Type_Response> DeleteAsync(Post_type post_Type)
        {
            var isExist = await post_Type_Repository.FindByIdAsync(post_Type.Id);
            if(isExist == null)
                return new Post_Type_Response("Post-type doesn't exist!");

            try{
                post_Type_Repository.Delete(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Post_Type_Response(isExist);
            }
            catch(Exception ex){
                return new Post_Type_Response($"Error with deleting post-type: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Post_type>> GetAllAsync()
        {
            return await post_Type_Repository.GetAllAsync();
        }

        public async Task<Post_type> GetById(int id)
        {
            return await post_Type_Repository.FindByIdAsync(id);
        }

        public async Task<Post_Type_Response> SaveAsync(Post_type post_Type)
        {
            try{
                await post_Type_Repository.AddAsync(post_Type);
                await unit_Of_Work.CompleteAsync();
                return new Post_Type_Response(post_Type);
            }
            catch(Exception ex){
                return new Post_Type_Response($"Error while saving post-type. Message:{ex.Message}");
            }
        }

        public async Task<Post_Type_Response> UpdateAsync(Post_type post_Type)
        {
            var isExist = await post_Type_Repository.FindByIdAsync(post_Type.Id);
            if (isExist == null)
                return new Post_Type_Response("Post type not found!");
            try
            {
                post_Type_Repository.Update(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Post_Type_Response(isExist);
            }
            catch (Exception ex)
            {
                return new Post_Type_Response($"Error when updating post type: {ex.Message}");
            }
        }
    }
}