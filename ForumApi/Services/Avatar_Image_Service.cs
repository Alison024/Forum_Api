using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace ForumApi.Services
{
    public class Avatar_Image_Service : IAvatar_Image_Service
    {
        private readonly IUnit_Of_Work unit_Of_Work;
        private readonly IAvatar_Images_Repository avatar_Images_Repository;
        public Avatar_Image_Service(IUnit_Of_Work unit_Of_Work, IAvatar_Images_Repository avatar_Images_Repository){
            this.unit_Of_Work = unit_Of_Work;
            this.avatar_Images_Repository = avatar_Images_Repository;
        }
        public async Task<Avatar_Image_Response> DeleteAsync(int id)
        {
            var isExist = await avatar_Images_Repository.FindByIdAsync(id);
            if(isExist == null)
                return new Avatar_Image_Response("Avatar image doesn't exist!");

            try{
                avatar_Images_Repository.Delete(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Avatar_Image_Response(isExist);
            }
            catch(Exception ex){
                return new Avatar_Image_Response($"Error with deleting avatar image: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Avatar_image>> GetAllAsync()
        {
            return await avatar_Images_Repository.GetAllAsync();
        }

        public async Task<Avatar_image> GetById(int id)
        {
            return await avatar_Images_Repository.FindByIdAsync(id);
        }

        public async Task<Avatar_Image_Response> SaveAsync(Avatar_image avatar_Image)
        {
            try{
                await avatar_Images_Repository.AddAsync(avatar_Image);
                await unit_Of_Work.CompleteAsync();
                return new Avatar_Image_Response(avatar_Image);
            }
            catch(Exception ex){
                return new Avatar_Image_Response($"Error while saving avatar image. Message:{ex.Message}");
            }
        }

        public async Task<Avatar_Image_Response> UpdateAsync(Avatar_image avatar_Image)
        {
            var existAvatarImage = await avatar_Images_Repository.FindByIdAsync(avatar_Image.Id);
            if (existAvatarImage == null)
                return new Avatar_Image_Response("Avatar image not found!");
            
            try
            {
                avatar_Images_Repository.Update(existAvatarImage);
                await unit_Of_Work.CompleteAsync();
                return new Avatar_Image_Response(existAvatarImage);
            }
            catch (Exception ex)
            {
                return new Avatar_Image_Response($"Error when updating avatar image: {ex.Message}");
            }
        }
    }
}