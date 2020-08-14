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
    [Route("api/post-type")]
    public class PostTypeController: ControllerBase
    {
        private readonly IPost_Type_Service post_Type_Service;
        private readonly IMapper mapper;
        public PostTypeController(IPost_Type_Service post_Type_Service, IMapper mapper)
        {
            this.post_Type_Service = post_Type_Service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Post_Type_Resource>> GetAllAsync(){
            var posts = await post_Type_Service.GetAllAsync();
            var resource = mapper.Map<IEnumerable<Post_type>, IEnumerable<Post_Type_Resource>>(posts);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Post_Type_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post_Type = mapper.Map<Post_Type_Resource, Post_type>(resource);
            var result = await post_Type_Service.SaveAsync(post_Type);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var post_Type_Resource = mapper.Map<Post_type, Post_Type_Resource>(result.post_Type);
            return Ok(post_Type_Resource);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Post_Type_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post_Type = mapper.Map<Post_Type_Resource, Post_type>(resource);
            var result = await post_Type_Service.UpdateAsync(post_Type);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var post_Type_Resource = mapper.Map<Post_type, Post_Type_Resource>(result.post_Type);
            return Ok(post_Type_Resource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await post_Type_Service.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var post_Type_Resource = mapper.Map<Post_type, Post_Type_Resource>(result.post_Type);
            return Ok(post_Type_Resource);
        }
    }
}