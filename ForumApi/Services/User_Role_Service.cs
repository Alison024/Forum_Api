using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
namespace ForumApi.Services
{
    public class User_Role_Service : IUser_Role_Service
    {
        private readonly IUnit_Of_Work unit_Of_Work;
        private readonly IUser_Role_Repository user_Role_Repository;
        public User_Role_Service(IUnit_Of_Work unit_Of_Work,IUser_Role_Repository user_Role_Repository){
            this.unit_Of_Work = unit_Of_Work;
            this.user_Role_Repository = user_Role_Repository;
        }
        public async Task<User_Role_Response> DeleteAsync(User_role user_Role)
        {
            var isExist = await user_Role_Repository.FindByCompatibleKeyAsync(user_Role.User_Id ,user_Role.Role_Id);
            if(isExist == null)
                return new User_Role_Response("User-role doesn't exist!");

            try{
                user_Role_Repository.Delete(isExist);
                await unit_Of_Work.CompleteAsync();
                return new User_Role_Response(isExist);
            }
            catch(Exception ex){
                return new User_Role_Response($"Error with deleting user-role: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User_role>> GetAllAsync()
        {
            return await user_Role_Repository.GetAllAsync();
        }

        public async Task<IEnumerable<User_role>> GetRolesOfUser(int user_Id)
        {
            return await user_Role_Repository.GetByUserId(user_Id);
        }

        public async Task<IEnumerable<User_role>> GetUsersWithRole(int role_Id)
        {
            return await user_Role_Repository.GetByRoleId(role_Id);
        }

        public async Task<User_Role_Response> SaveAsync(User_role user_Role)
        {
            try{
                await user_Role_Repository.AddAsync(user_Role);
                await unit_Of_Work.CompleteAsync();
                return new User_Role_Response(user_Role);
            }
            catch(Exception ex){
                return new User_Role_Response($"Error while saving user role. Message:{ex.Message}");
            }
        }

        public async Task<User_Role_Response> UpdateAsync(User_role user_Role)
        {
            var isExist = await user_Role_Repository.FindByCompatibleKeyAsync(user_Role.User_Id,user_Role.Role_Id);
            if (isExist == null)
                return new User_Role_Response("User-role not found!");
            
            try
            {
                user_Role_Repository.Update(isExist);
                await unit_Of_Work.CompleteAsync();
                return new User_Role_Response(isExist);
            }
            catch (Exception ex)
            {
                return new User_Role_Response($"Error when updating user-role: {ex.Message}");
            }
        }
    }
}