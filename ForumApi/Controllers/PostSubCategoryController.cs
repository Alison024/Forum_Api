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
        private readonly IPost_Service post_Service;
        private readonly IMapper mapper;
        public PostSubCategoryController(IPost_Service post_Service, IMapper mapper)
        {
            this.post_Service = post_Service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Post_Resource>> GetAllAsync(){
            var posts = await post_Service.GetAllAsync();
            var resource = mapper.Map<IEnumerable<Post>, IEnumerable<Post_Resource>>(posts);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Post_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post = mapper.Map<Post_Resource, Post>(resource);
            var result = await post_Service.SaveAsync(post);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var post_Resource = mapper.Map<Post, Post_Resource>(result.post);
            return Ok(post_Resource);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Post_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post = mapper.Map<Post_Resource, Post>(resource);
            var result = await post_Service.UpdateAsync(post);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var post_Resource = mapper.Map<Post, Post_Resource>(result.post);
            return Ok(post_Resource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await post_Service.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var post_Resource = mapper.Map<Post, Post_Resource>(result.post);
            return Ok(post_Resource);
        }
    }
}