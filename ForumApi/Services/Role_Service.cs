using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
namespace ForumApi.Services
{
    public class Role_Service : IRole_Service
    {
        private readonly IUnit_Of_Work unit_Of_Work;
        private readonly IRole_Repository role_Repository;
        public Role_Service(IUnit_Of_Work unit_Of_Work,IRole_Repository role_Repository){
            this.unit_Of_Work = unit_Of_Work;
            this.role_Repository = role_Repository;
        }
        public async Task<Role_Response> DeleteAsync(Role role)
        {
            var isExist = await role_Repository.FindByIdAsync(role.Id);
            if(isExist == null)
                return new Role_Response("Role doesn't exist!");

            try{
                role_Repository.Delete(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Role_Response(isExist);
            }
            catch(Exception ex){
                return new Role_Response($"Error with deleting role: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await role_Repository.GetAllAsync();
        }

        public async Task<Role> GetById(int id)
        {
            return await role_Repository.FindByIdAsync(id);
        }

        public async Task<Role_Response> SaveAsync(Role role)
        {
            try{
                await role_Repository.AddAsync(role);
                await unit_Of_Work.CompleteAsync();
                return new Role_Response(role);
            }
            catch(Exception ex){
                return new Role_Response($"Error while saving role. Message:{ex.Message}");
            }
        }

        public async Task<Role_Response> UpdateAsync(Role role)
        {
            var isExist = await role_Repository.FindByIdAsync(role.Id);
            if (isExist == null)
                return new Role_Response("Role not found!");
            try
            {
                role_Repository.Update(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Role_Response(isExist);
            }
            catch (Exception ex)
            {
                return new Role_Response($"Error when updating role: {ex.Message}");
            }
        }
    }
}