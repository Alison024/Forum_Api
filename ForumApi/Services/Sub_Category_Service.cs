using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
namespace ForumApi.Services
{
    public class Sub_Category_Service : ISub_Category_Service
    {
        private readonly IUnit_Of_Work unit_Of_Work;
        private readonly ISub_Category_Repository sub_Category_Repository;
        public Sub_Category_Service(IUnit_Of_Work unit_Of_Work,ISub_Category_Repository sub_Category_Repository){
            this.unit_Of_Work = unit_Of_Work;
            this.sub_Category_Repository = sub_Category_Repository;
        }
        public async Task<Sub_Category_Response> DeleteAsync(int id)
        {
            var isExist = await sub_Category_Repository.FindByIdAsync(id);
            if(isExist == null)
                return new Sub_Category_Response("Sub category doesn't exist!");

            try{
                sub_Category_Repository.Delete(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Sub_Category_Response(isExist);
            }
            catch(Exception ex){
                return new Sub_Category_Response($"Error with deleting sub category: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Sub_category>> GetAllAsync()
        {
            return await sub_Category_Repository.GetAllAsync();
        }

        public async Task<Sub_category> GetById(int id)
        {
            return await sub_Category_Repository.FindByIdAsync(id);
        }

        public async Task<Sub_Category_Response> SaveAsync(Sub_category sub_Category)
        {
            try{
                await sub_Category_Repository.AddAsync(sub_Category);
                await unit_Of_Work.CompleteAsync();
                return new Sub_Category_Response(sub_Category);
            }
            catch(Exception ex){
                return new Sub_Category_Response($"Error while saving sub category. Message:{ex.Message}");
            }
        }

        public async Task<Sub_Category_Response> UpdateAsync(Sub_category sub_Category)
        {
            var isExist = await sub_Category_Repository.FindByIdAsync(sub_Category.Id);
            if (isExist == null)
                return new Sub_Category_Response("Sub category not found!");
            
            try
            {
                sub_Category_Repository.Update(sub_Category);
                await unit_Of_Work.CompleteAsync();
                return new Sub_Category_Response(sub_Category);
            }
            catch (Exception ex)
            {
                return new Sub_Category_Response($"Error when updating sub category: {ex.Message}");
            }
        }
    }
}