using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ForumApi.Persistence.Repositories
{
    public class AvatarImageRepository : BaseRepository, IAvatar_Images_Repository
    {
        public AvatarImageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Avatar_image img)
        {
            await context.Avatar_Images.AddAsync(img);
        }

        public void Delete(Avatar_image img)
        {
            context.Avatar_Images.Remove(img);
        }

        public async Task<Avatar_image> FindByIdAsync(int id)
        {
            return await context.Avatar_Images.FindAsync(id);
        }

        public async Task<IEnumerable<Avatar_image>> GetAllAsync()
        {
            return await context.Avatar_Images.ToListAsync();
        }

        public void Update(Avatar_image img)
        {
            context.Avatar_Images.Update(img);
        }
    }
}