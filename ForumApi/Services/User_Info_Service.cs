using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
namespace ForumApi.Services
{
    public class User_Info_Service : IUser_Info_Service
    {
        private readonly IUnit_Of_Work unit_Of_Work;
        private readonly IUser_Info_Repository user_Info_Repository;
        public User_Info_Service(IUnit_Of_Work unit_Of_Work,IUser_Info_Repository user_Info_Repository){
            this.unit_Of_Work = unit_Of_Work;
            this.user_Info_Repository = user_Info_Repository;
        }
        public async Task<User_Info_Response> DeleteAsync(int id)
        {
            var isExist = await user_Info_Repository.FindByIdAsync(id);
            if(isExist == null)
                return new User_Info_Response("User info doesn't exist!");

            try{
                user_Info_Repository.Delete(isExist);
                await unit_Of_Work.CompleteAsync();
                return new User_Info_Response(isExist);
            }
            catch(Exception ex){
                return new User_Info_Response($"Error with deleting user info: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User_info>> GetAllAsync()
        {
            return await user_Info_Repository.GetAllAsync();
        }

        public async Task<User_info> GetById(int id)
        {
            return await user_Info_Repository.FindByIdAsync(id);
        }

        public async Task<User_Info_Response> SaveAsync(User_info user_Info)
        {
            try{
                await user_Info_Repository.AddAsync(user_Info);
                await unit_Of_Work.CompleteAsync();
                return new User_Info_Response(user_Info);
            }
            catch(Exception ex){
                return new User_Info_Response($"Error while saving user info. Message:{ex.Message}");
            }
        }

        public async Task<User_Info_Response> UpdateAsync(User_info user_Info)
        {
            var isExist = await user_Info_Repository.FindByIdAsync(user_Info.Id);
            if (isExist == null)
                return new User_Info_Response("User info not found!");
            try
            {
                user_Info_Repository.Update(isExist);
                await unit_Of_Work.CompleteAsync();
                return new User_Info_Response(isExist);
            }
            catch (Exception ex)
            {
                return new User_Info_Response($"Error when updating user info: {ex.Message}");
            }
        }
    }
}