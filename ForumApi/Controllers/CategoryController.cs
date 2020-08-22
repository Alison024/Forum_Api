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
    [Route("api/category")]
    public class CategoryController: ControllerBase
    {
        private readonly ICategory_Service category_Service;
        private readonly IMapper mapper;
        public CategoryController(ICategory_Service category_Service, IMapper mapper)
        {
            this.category_Service = category_Service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Category_Resource>> GetAllAsync(){
            var categories = await category_Service.GetAllAsync();
            var resource = mapper.Map<IEnumerable<Category>, IEnumerable<Category_Resource>>(categories);
            return resource;
        }
        [Authorize(Roles="Admin")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Category_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = mapper.Map<Category_Resource, Category>(resource);
            var result = await category_Service.SaveAsync(category);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var category_Resource = mapper.Map<Category, Category_Resource>(result.Category);
            return Ok(category_Resource);
        }
        [Authorize(Roles="Admin")]
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Category_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = mapper.Map<Category_Resource, Category>(resource);
            var result = await category_Service.UpdateAsync(category);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var category_Resource = mapper.Map<Category, Category_Resource>(result.Category);
            return Ok(category_Resource);
        }
        [Authorize(Roles="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await category_Service.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var category_Resource = mapper.Map<Category, Category_Resource>(result.Category);
            return Ok(category_Resource);
        }
    }
}