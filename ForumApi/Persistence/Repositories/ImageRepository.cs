using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForumApi.Persistence.Repositories
{
    public class ImageRepository : BaseRepository,IImage_Repository
    {
        public ImageRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(Image img)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Image img)
        {
            throw new System.NotImplementedException();
        }

        public Task<Image> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Image>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Image img)
        {
            throw new System.NotImplementedException();
        }
    }
}