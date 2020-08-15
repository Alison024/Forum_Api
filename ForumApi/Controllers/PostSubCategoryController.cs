using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ForumApi.Extensions;
using ForumApi.Domain.Models;
using ForumApi.Domain.IServices;
using ForumApi.Resources;
using ForumApi.Helpers;
namespace ForumApi.Controllers
{
    [ApiController]
    [Route("api/post-sub-category")]
    public class PostSubCategoryController: ControllerBase
    {
        private readonly IPost_Sub_Category_Service post_Sub_Category_Service;
        private readonly IMapper mapper;
        public PostSubCategoryController(IPost_Sub_Category_Service post_Sub_Category_Service, IMapper mapper)
        {
            this.post_Sub_Category_Service = post_Sub_Category_Service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Post_Sub_Category_Resource>> GetAllAsync(){
            var posts = await post_Sub_Category_Service.GetAllAsync();
            var resource = mapper.Map<IEnumerable<Post_sub_category>, IEnumerable<Post_Sub_Category_Resource>>(posts);
            return resource;
        }
        [HttpGet("GetBySubCategoryId/{id}")]
        public async Task<IEnumerable<Post_Sub_Category_Resource>> GetBySubCategoryId(int id){
            var posts = await post_Sub_Category_Service.GetPostsWithSubCategory(id);
            var resource = mapper.Map<IEnumerable<Post_sub_category>, IEnumerable<Post_Sub_Category_Resource>>(posts);
            return resource;
        }
        [HttpGet("GetByPostId/{id}")]
        public async Task<IEnumerable<Post_Sub_Category_Resource>> GetByPostId(int id){
            var posts = await post_Sub_Category_Service.GetSubCategoriesOfPost(id);
            var resource = mapper.Map<IEnumerable<Post_sub_category>, IEnumerable<Post_Sub_Category_Resource>>(posts);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Post_Sub_Category_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post = mapper.Map<Post_Sub_Category_Resource, Post_sub_category>(resource);
            var result = await post_Sub_Category_Service.SaveAsync(post);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var post_Sub_Category_Resource = mapper.Map<Post_sub_category, Post_Sub_Category_Resource>(result.post_Sub_Category);
            return Ok(post_Sub_Category_Resource);
        }

        /*[HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Post_Sub_Category_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post = mapper.Map<Post_Sub_Category_Resource, Post_sub_category>(resource);
            var result = await post_Sub_Category_Service.UpdateAsync(post);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var post_Sub_Category_Resource = mapper.Map<Post_sub_category, Post_Sub_Category_Resource>(result.post_Sub_Category);
            return Ok(post_Sub_Category_Resource);
        }*/

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] Post_Sub_Category_Resource resource)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post = mapper.Map<Post_Sub_Category_Resource, Post_sub_category>(resource);
            var result = await post_Sub_Category_Service.DeleteAsync(post);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var post_Sub_Category_Resource = mapper.Map<Post_sub_category, Post_Sub_Category_Resource>(result.post_Sub_Category);
            return Ok(post_Sub_Category_Resource);
        }
    }
}