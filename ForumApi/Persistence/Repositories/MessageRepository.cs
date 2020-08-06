using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForumApi.Persistence.Repositories
{
    public class MessageRepository : BaseRepository, IMessage_Reposirtory
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(Message mes)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Message mes)
        {
            throw new System.NotImplementedException();
        }

        public Task<Message> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Message>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Message mes)
        {
            throw new System.NotImplementedException();
        }
    }
}