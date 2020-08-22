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
using Microsoft.AspNetCore.Authorization;

namespace ForumApi.Controllers
{
    [ApiController]
    [Route("api/post-image")]
    public class PostImageController: ControllerBase
    {
        private readonly IPost_Image_Service post_Image_Service;
        private readonly IMapper mapper;
        public PostImageController(IPost_Image_Service post_Image_Service, IMapper mapper)
        {
            this.post_Image_Service = post_Image_Service;
            this.mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<Post_Image_Resource>> GetAllAsync(){
            var post_Images = await post_Image_Service.GetAllAsync();
            var resource = mapper.Map<IEnumerable<Post_image>, IEnumerable<Post_Image_Resource>>(post_Images);
            return resource;
        }
        [Authorize]
        [HttpGet("GetByPostId/{id}")]
        public async Task<IEnumerable<Post_Image_Resource>> GetAllAsync2(int id){
            var images = await post_Image_Service.GetImagesOfPost(id);
            var resource = mapper.Map<IEnumerable<Post_image>, IEnumerable<Post_Image_Resource>>(images);
            return resource;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Post_Image_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post_Image = mapper.Map<Post_Image_Resource, Post_image>(resource);
            var result = await post_Image_Service.SaveAsync(post_Image);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var post_Image_Resource = mapper.Map<Post_image, Post_Image_Resource>(result.post_Image);
            return Ok(post_Image_Resource);
        }

        /*[HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Post_Image_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post_Image = mapper.Map<Post_Image_Resource, Post_image>(resource);
            var result = await post_Image_Service.UpdateAsync(post_Image);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var post_Image_Resource = mapper.Map<Post_image, Post_Image_Resource>(result.post_Image);
            return Ok(post_Image_Resource);
        }*/
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] Post_Image_Resource resource)
        {
            var post_Image = mapper.Map<Post_Image_Resource, Post_image>(resource);
            var result = await post_Image_Service.DeleteAsync(post_Image);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var post_Image_Resource = mapper.Map<Post_image, Post_Image_Resource>(result.post_Image);
            return Ok(post_Image_Resource);
        }
    }
}