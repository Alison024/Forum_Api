using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Domain.IRepositories;
using ForumApi.Domain.Responses;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
namespace ForumApi.Services
{
    public class Message_Service : IMessage_Service
    {
        private readonly IUnit_Of_Work unit_Of_Work;
        private readonly IMessage_Reposirtory message_Reposirtory;
        public Message_Service(IUnit_Of_Work unit_Of_Work,IMessage_Reposirtory message_Reposirtory){
            this.unit_Of_Work = unit_Of_Work;
            this.message_Reposirtory = message_Reposirtory;
        }
        public async Task<Message_Response> DeleteAsync(int id)
        {
            var isExist = await message_Reposirtory.FindByIdAsync(id);
            if(isExist == null)
                return new Message_Response("Message doesn't exist!");

            try{
                message_Reposirtory.Delete(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Message_Response(isExist);
            }
            catch(Exception ex){
                return new Message_Response($"Error with deleting message: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            return await message_Reposirtory.GetAllAsync();
        }

        public async Task<Message> GetById(int id)
        {
            return await message_Reposirtory.FindByIdAsync(id);
        }

        public async Task<Message_Response> SaveAsync(Message message)
        {
            try{
                await message_Reposirtory.AddAsync(message);
                await unit_Of_Work.CompleteAsync();
                return new Message_Response(message);
            }
            catch(Exception ex){
                return new Message_Response($"Error while saving message. Message:{ex.Message}");
            }
        }

        public async Task<Message_Response> UpdateAsync(Message message)
        {
            var isExist = await message_Reposirtory.FindByIdAsync(message.Id);
            if (isExist == null)
                return new Message_Response("Message not found!");
            
            try
            {
                message_Reposirtory.Update(isExist);
                await unit_Of_Work.CompleteAsync();
                return new Message_Response(isExist);
            }
            catch (Exception ex)
            {
                return new Message_Response($"Error when updating message: {ex.Message}");
            }
        }
    }
}