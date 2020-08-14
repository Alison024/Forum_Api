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
    [Route("api/sub-category")]
    public class SubCategoryController: ControllerBase
    {
        private readonly ISub_Category_Service sub_Category_Service;
        private readonly IMapper mapper;
        public SubCategoryController(ISub_Category_Service sub_Category_Service, IMapper mapper)
        {
            this.sub_Category_Service = sub_Category_Service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Sub_Category_Resource>> GetAllAsync(){
            var sub_Categories = await sub_Category_Service.GetAllAsync();
            var resource = mapper.Map<IEnumerable<Sub_category>, IEnumerable<Sub_Category_Resource>>(sub_Categories);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Sub_Category_Resource resource)
        {
            /*if(resource.Titile == null){
                return BadRequest($"{resource.Id},{resource.Titile},{resource.Description},{resource.Category_Id}");
            }*/
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var sub_Categories = mapper.Map<Sub_Category_Resource, Sub_category>(resource);
            var result = await sub_Category_Service.SaveAsync(sub_Categories);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var sub_Category_Resource = mapper.Map<Sub_category, Sub_Category_Resource>(result.sub_Category);
            return Ok(sub_Category_Resource);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Sub_Category_Resource resource)
        {
            /*if(resource.Titile == null){
                return BadRequest($"{resource.Id},{resource.Titile},{resource.Description},{resource.Category_Id}");
            }*/
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var sub_Categories = mapper.Map<Sub_Category_Resource, Sub_category>(resource);
            var result = await sub_Category_Service.UpdateAsync(sub_Categories);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var sub_Category_Resource = mapper.Map<Sub_category, Sub_Category_Resource>(result.sub_Category);
            return Ok(sub_Category_Resource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await sub_Category_Service.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var sub_Category_Resource = mapper.Map<Sub_category, Sub_Category_Resource>(result.sub_Category);
            return Ok(sub_Category_Resource);
        }
    }
}