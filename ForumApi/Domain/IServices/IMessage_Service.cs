using ForumApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Responses;
namespace ForumApi.Domain.IServices
{
    public interface IMessage_Service
    {
        Task<IEnumerable<Message>> GetAllAsync();
        Task<Message> GetById(int id);
        Task<Message_Response> SaveAsync(Message message);
        Task<Message_Response> UpdateAsync(Message message);
        Task<Message_Response> DeleteAsync(int id);
    }
}