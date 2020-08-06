using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForumApi.Persistence.Repositories
{
    public class AvatarImageRepository : BaseRepository, IAvatar_Images_Repository
    {
        public AvatarImageRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(Avatar_image img)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Avatar_image img)
        {
            throw new System.NotImplementedException();
        }

        public Task<Avatar_image> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Avatar_image>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Avatar_image img)
        {
            throw new System.NotImplementedException();
        }
    }
}