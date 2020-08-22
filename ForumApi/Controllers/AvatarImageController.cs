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
    [Route("api/avatar-image")]
    public class AvatarImageController: ControllerBase
    {
        private readonly IAvatar_Image_Service avatar_Image_Service;
        private readonly IMapper mapper;
        public AvatarImageController(IAvatar_Image_Service avatar_Image_Service, IMapper mapper)
        {
            this.avatar_Image_Service = avatar_Image_Service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Avatar_Image_Resource>> GetAllAsync(){
            var avatar_Images = await avatar_Image_Service.GetAllAsync();
            var resource = mapper.Map<IEnumerable<Avatar_image>, IEnumerable<Avatar_Image_Resource>>(avatar_Images);
            return resource;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Avatar_Image_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var avatar_Image = mapper.Map<Avatar_Image_Resource, Avatar_image>(resource);
            var result = await avatar_Image_Service.SaveAsync(avatar_Image);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var avatar_Image_Resource = mapper.Map<Avatar_image, Avatar_Image_Resource>(result.Avatar_Image);
            return Ok(avatar_Image_Resource);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Avatar_Image_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var avatar_Image = mapper.Map<Avatar_Image_Resource, Avatar_image>(resource);
            var result = await avatar_Image_Service.UpdateAsync(avatar_Image);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var avatar_Image_Resource = mapper.Map<Avatar_image, Avatar_Image_Resource>(result.Avatar_Image);
            return Ok(avatar_Image_Resource);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await avatar_Image_Service.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var avatar_Image_Resource = mapper.Map<Avatar_image, Avatar_Image_Resource>(result.Avatar_Image);
            return Ok(avatar_Image_Resource);
        }
    }
}