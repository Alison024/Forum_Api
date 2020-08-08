using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ForumApi.Persistence.Repositories
{
    public class ImageRepository : BaseRepository,IImage_Repository
    {
        public ImageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Image img)
        {
            await context.Images.AddAsync(img);
        }

        public void Delete(Image img)
        {
            context.Images.Remove(img);
        }

        public async Task<Image> FindByIdAsync(int id)
        {
            return await context.Images.FindAsync(id);
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await context.Images.ToArrayAsync();
        }

        public void Update(Image img)
        {
            context.Images.Update(img);
        }
    }
}