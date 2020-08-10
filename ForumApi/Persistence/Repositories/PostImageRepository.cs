using System.IO.Compression;
using System.Runtime.CompilerServices;
using ForumApi.Domain.Models;
using ForumApi.Domain.IRepositories;
using ForumApi.Persistence.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace ForumApi.Persistence.Repositories
{
    public class PostImageRepository : BaseRepository, IPost_Image_Repository
    {
        public PostImageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Post_image post_Image)
        {
            await context.Post_Images.AddAsync(post_Image);
        }

        public void Delete(Post_image post_Image)
        {
            context.Post_Images.Remove(post_Image);
        }

        public async Task<Post_image> FindByCompatibleKeyAsync(int post_Id,int image_Id)
        {
            return await context.Post_Images.SingleOrDefaultAsync(x=>x.Post_Id==post_Id && x.Image_Id == image_Id);
        }
        public async Task<IEnumerable<Post_image>> GetByPostId(int post_Id)
        {
            return await context.Post_Images.Where(x=>x.Post_Id == post_Id).ToListAsync();
        }
        public async Task<IEnumerable<Post_image>> GetByImageId(int image_Id)
        {
            return await context.Post_Images.Where(x=>x.Image_Id == image_Id).ToListAsync();
        }
        public async Task<IEnumerable<Post_image>> GetAllAsync()
        {
            return await context.Post_Images.ToListAsync();
        }

        public void Update(Post_image post_Image)
        {
            context.Post_Images.Update(post_Image);
        }
    }
} 