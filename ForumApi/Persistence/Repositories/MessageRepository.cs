using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ForumApi.Persistence.Repositories
{
    public class MessageRepository : BaseRepository, IMessage_Reposirtory
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Message mes)
        {
            await context.Messages.AddAsync(mes);
        }

        public void Delete(Message mes)
        {
            context.Messages.Remove(mes);
        }

        public async Task<Message> FindByIdAsync(int id)
        {
            return await context.Messages.FindAsync(id);
        }

        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            return await context.Messages.Include(x=>x.Status).ToListAsync();
        }

        public void Update(Message mes)
        {
            context.Messages.Update(mes);
        }
    }
}