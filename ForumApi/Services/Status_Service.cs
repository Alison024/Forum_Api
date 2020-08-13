using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
namespace ForumApi.Services
{
    public class Status_Service : IStatus_Service
    {
        private readonly IUnit_Of_Work unit_Of_Work;
        private readonly IStatus_Repository status_Repository;
        public Status_Service(IUnit_Of_Work unit_Of_Work,IStatus_Repository status_Repository){
            this.unit_Of_Work = unit_Of_Work;
            this.status_Repository = status_Repository;
        }
        public async Task<Status_Response> DeleteAsync(int id)
        {
            var isExist = await status_Repository.FindByIdAsync(id);
            if(isExist == null)
                return new Status_Response("Status doesn't exist!");

            try{
                status_Repository.Delete(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Status_Response(isExist);
            }
            catch(Exception ex){
                return new Status_Response($"Error with deleting status: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            return await status_Repository.GetAllAsync();
        }

        public async Task<Status> GetById(int id)
        {
            return await status_Repository.FindByIdAsync(id);
        }

        public async Task<Status_Response> SaveAsync(Status status)
        {
            try{
                await status_Repository.AddAsync(status);
                await unit_Of_Work.CompleteAsync();
                return new Status_Response(status);
            }
            catch(Exception ex){
                return new Status_Response($"Error while saving status. Message:{ex.Message}");
            }
        }

        public async Task<Status_Response> UpdateAsync(Status status)
        {
            var isExist = await status_Repository.FindByIdAsync(status.Id);
            if (isExist == null)
                return new Status_Response("Status not found!");
            
            try
            {
                status_Repository.Update(status);
                await unit_Of_Work.CompleteAsync();
                return new Status_Response(status);
            }
            catch (Exception ex)
            {
                return new Status_Response($"Error when updating status: {ex.Message}");
            }
        }
    }
}