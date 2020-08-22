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
    [Route("api/role")]
    public class RoleController: ControllerBase
    {
        private readonly IRole_Service role_Service;
        private readonly IMapper mapper;
        public RoleController(IRole_Service role_Service, IMapper mapper)
        {
            this.role_Service = role_Service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Role_Resource>> GetAllAsync(){
            var roles = await role_Service.GetAllAsync();
            var resource = mapper.Map<IEnumerable<Role>, IEnumerable<Role_Resource>>(roles);
            return resource;
        }
        [Authorize(Roles="Admin")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Role_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var role = mapper.Map<Role_Resource, Role>(resource);
            var result = await role_Service.SaveAsync(role);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var role_Resource = mapper.Map<Role, Role_Resource>(result.role);
            return Ok(role_Resource);
        }
        [Authorize(Roles="Admin")]
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Role_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var role = mapper.Map<Role_Resource, Role>(resource);
            var result = await role_Service.UpdateAsync(role);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var role_Resource = mapper.Map<Role, Role_Resource>(result.role);
            return Ok(role_Resource);
        }
        [Authorize(Roles="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await role_Service.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var role_Resource = mapper.Map<Role, Role_Resource>(result.role);
            return Ok(role_Resource);
        }
    }
}