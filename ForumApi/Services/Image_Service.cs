using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
namespace ForumApi.Services
{
    public class Image_Service : IImage_Service
    {
        private readonly IUnit_Of_Work unit_Of_Work;
        private readonly IImage_Repository image_Repository;
        public Image_Service(IUnit_Of_Work unit_Of_Work,IImage_Repository image_Repository){
            this.unit_Of_Work = unit_Of_Work;
            this.image_Repository = image_Repository;
        }
        public async Task<Image_Response> DeleteAsync(int id)
        {
            var isExist = await image_Repository.FindByIdAsync(id);
            if(isExist == null)
                return new Image_Response("Image doesn't exist!");

            try{
                image_Repository.Delete(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Image_Response(isExist);
            }
            catch(Exception ex){
                return new Image_Response($"Error with deleting image: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await image_Repository.GetAllAsync();
        }

        public async Task<Image> GetById(int id)
        {
            return await image_Repository.FindByIdAsync(id);
        }

        public async Task<Image_Response> SaveAsync(Image image)
        {
            try{
                await image_Repository.AddAsync(image);
                await unit_Of_Work.CompleteAsync();
                return new Image_Response(image);
            }
            catch(Exception ex){
                return new Image_Response($"Error while saving image. Message:{ex.Message}");
            }
        }

        public async Task<Image_Response> UpdateAsync(Image image)
        {
            var isExist = await image_Repository.FindByIdAsync(image.Id);
            if (isExist == null)
                return new Image_Response("Image not found!");
            
            try
            {
                image_Repository.Update(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Image_Response(isExist);
            }
            catch (Exception ex)
            {
                return new Image_Response($"Error when updating image: {ex.Message}");
            }
        }
    }
}