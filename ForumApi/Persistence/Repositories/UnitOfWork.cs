using System.Threading.Tasks;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
namespace ForumApi.Persistence.Repositories
{
    public class UnitOfWork : BaseRepository, IUnit_Of_Work
    {
        public UnitOfWork(AppDbContext context) : base(context)
        {
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}