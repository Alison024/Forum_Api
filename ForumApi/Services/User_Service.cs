using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
namespace ForumApi.Services
{
    public class User_Service : IUser_Service
    {
        private readonly IUnit_Of_Work unit_Of_Work;
        private readonly IUser_Repository user_Repository;
        public User_Service(IUnit_Of_Work unit_Of_Work,IUser_Repository user_Repository){
            this.unit_Of_Work = unit_Of_Work;
            this.user_Repository = user_Repository;
        }
        
        public async Task<User_Response> DeleteAsync(int id)
        {
            var isExist = await user_Repository.FindByIdAsync(id);
            if(isExist == null)
                return new User_Response("User doesn't exist!");

            try{
                user_Repository.Delete(isExist);
                await unit_Of_Work.CompleteAsync();
                return new User_Response(isExist);
            }
            catch(Exception ex){
                return new User_Response($"Error with deleting user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await user_Repository.GetAllAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await user_Repository.FindByIdAsync(id);
        }

        public async Task<User_Response> SaveAsync(User user)
        {
            try{
                await user_Repository.AddAsync(user);
                await unit_Of_Work.CompleteAsync();
                return new User_Response(user);
            }
            catch(Exception ex){
                return new User_Response($"Error while saving user. Message:{ex.Message}");
            }
        }

        public async Task<User_Response> UpdateAsync(User user)
        {
            var isExist = await user_Repository.FindByIdAsync(user.Id);
            if (isExist == null)
                return new User_Response("User not found!");
            
            try
            {
                //------------------------------
                isExist = user;
                user_Repository.Update(isExist);
                //------------------------------
                //user_Repository.Update(user);
                await unit_Of_Work.CompleteAsync();
                return new User_Response(user);
            }
            catch (Exception ex)
            {
                return new User_Response($"Error when updating user: {ex.Message}");
            }
        }
    }
}