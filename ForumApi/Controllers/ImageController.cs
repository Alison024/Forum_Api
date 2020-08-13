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
    [Route("api/image")]
    public class ImageController: ControllerBase
    {
        private readonly IImage_Service image_Service;
        private readonly IMapper mapper;
        public ImageController(IImage_Service image_Service, IMapper mapper)
        {
            this.image_Service = image_Service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Image_Resource>> GetAllAsync(){
            var images = await image_Service.GetAllAsync();
            var resource = mapper.Map<IEnumerable<Image>, IEnumerable<Image_Resource>>(images);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Image_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var image = mapper.Map<Image_Resource, Image>(resource);
            var result = await image_Service.SaveAsync(image);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var image_Resource = mapper.Map<Image, Image_Resource>(result.Image);
            return Ok(image_Resource);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Image_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var image = mapper.Map<Image_Resource, Image>(resource);
            var result = await image_Service.UpdateAsync(image);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var image_Resource = mapper.Map<Image, Image_Resource>(result.Image);
            return Ok(image_Resource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await image_Service.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var image_Resource = mapper.Map<Image, Image_Resource>(result.Image);
            return Ok(image_Resource);
        }
    }
}