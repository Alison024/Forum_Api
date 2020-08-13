using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace ForumApi.Services
{
    public class Category_Service : ICategory_Service
    {
        private readonly IUnit_Of_Work unit_Of_Work;
        private readonly ICategory_Repository category_Repository;
        public Category_Service(IUnit_Of_Work unit_Of_Work,ICategory_Repository category_Repository){
            this.unit_Of_Work = unit_Of_Work;
            this.category_Repository = category_Repository;
        }
        public async Task<Category_Response> DeleteAsync(int id)
        {
            var isExist = await category_Repository.FindByIdAsync(id);
            if(isExist == null)
                return new Category_Response("Category doesn't exist!");

            try{
                category_Repository.Delete(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Category_Response(isExist);
            }
            catch(Exception ex){
                return new Category_Response($"Error with deleting category: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await category_Repository.GetAllAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await category_Repository.FindByIdAsync(id);
        }

        public async Task<Category_Response> SaveAsync(Category category)
        {
            try{
                await category_Repository.AddAsync(category);
                await unit_Of_Work.CompleteAsync();
                return new Category_Response(category);
            }
            catch(Exception ex){
                return new Category_Response($"Error while saving category. Message:{ex.Message}");
            }
        }

        public async Task<Category_Response> UpdateAsync(Category category)
        {
            var isExist = await category_Repository.FindByIdAsync(category.Id);
            if (isExist == null)
                return new Category_Response("Category not found!");
            
            try
            {
                category_Repository.Update(category);
                await unit_Of_Work.CompleteAsync();
                return new Category_Response(category);
            }
            catch (Exception ex)
            {
                return new Category_Response($"Error when updating category: {ex.Message}");
            }
        }
    }
}