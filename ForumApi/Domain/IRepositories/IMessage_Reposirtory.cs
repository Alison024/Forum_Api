using System.Collections.Generic;
using System.Threading.Tasks;
using ForumApi.Domain.Models;
namespace ForumApi.Domain.IRepositories
{
    public interface IMessage_Reposirtory
    {
        Task<IEnumerable<Message>> GetAllAsync();
        Task AddAsync(Message mes);
        void Update(Message mes);
        Task<Message> FindByIdAsync(int id);
        void Delete(Message mes);
    }
}