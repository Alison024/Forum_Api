using ForumApi.Persistence.Context;

namespace ForumApi.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext context;
        public BaseRepository(AppDbContext context){
            this.context = context;
        }
    }
}