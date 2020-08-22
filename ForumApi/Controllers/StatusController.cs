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
    [Route("api/status")]
    public class StatusController: ControllerBase
    {
        private readonly IStatus_Service status_Service;
        private readonly IMapper mapper;
        public StatusController(IStatus_Service status_Service, IMapper mapper)
        {
            this.status_Service = status_Service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Status_Resource>> GetAllAsync(){
            var statuses = await status_Service.GetAllAsync();
            var resource = mapper.Map<IEnumerable<Status>, IEnumerable<Status_Resource>>(statuses);
            return resource;
        }
        [Authorize(Roles="Admin")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Status_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var status = mapper.Map<Status_Resource, Status>(resource);
            var result = await status_Service.SaveAsync(status);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var status_Resource = mapper.Map<Status, Status_Resource>(result.status);
            return Ok(status_Resource);
        }
        [Authorize(Roles="Admin")]
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Status_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var status = mapper.Map<Status_Resource, Status>(resource);
            var result = await status_Service.UpdateAsync(status);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var status_Resource = mapper.Map<Status, Status_Resource>(result.status);
            return Ok(status_Resource);
        }
        [Authorize(Roles="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await status_Service.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var status_Resource = mapper.Map<Status, Status_Resource>(result.status);
            return Ok(status_Resource);
        }
    }
}