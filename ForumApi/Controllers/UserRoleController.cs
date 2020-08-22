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
    [Route("api/user-role")]
    public class UserRoleController: ControllerBase
    {
        private readonly IUser_Role_Service user_Role_Service;
        private readonly IMapper mapper;
        public UserRoleController(IUser_Role_Service user_Role_Service, IMapper mapper)
        {
            this.user_Role_Service = user_Role_Service;
            this.mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<User_Role_Resource>> GetAllAsync(){
            var user_Roles = await user_Role_Service.GetAllAsync();
            var resource = mapper.Map<IEnumerable<User_role>, IEnumerable<User_Role_Resource>>(user_Roles);
            return resource;
        }
        [Authorize]
        [HttpGet("GetRolesOfUser/{id}")]
        public async Task<IEnumerable<User_Role_Resource>> GetRolesOfUser(int id){
            var user_Roles = await user_Role_Service.GetRolesOfUser(id);
            var resource = mapper.Map<IEnumerable<User_role>, IEnumerable<User_Role_Resource>>(user_Roles);
            return resource;
        }
        [Authorize]
        [HttpGet("GetUsersWithRole/{id}")]
        public async Task<IEnumerable<User_Role_Resource>> GetUsersWithRole(int id){
            var user_Roles = await user_Role_Service.GetUsersWithRole(id);
            var resource = mapper.Map<IEnumerable<User_role>, IEnumerable<User_Role_Resource>>(user_Roles);
            return resource;
        }
        [Authorize(Roles="Admin")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] User_Role_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user_Role = mapper.Map<User_Role_Resource, User_role>(resource);
            var result = await user_Role_Service.SaveAsync(user_Role);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var user_Role_Resource = mapper.Map<User_role, User_Role_Resource>(result.user_Role);
            return Ok(user_Role_Resource);
        }

        /*[HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Post_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var post = mapper.Map<Post_Resource, Post>(resource);
            var result = await user_Role_Service.UpdateAsync(post);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var post_Resource = mapper.Map<Post, Post_Resource>(result.post);
            return Ok(post_Resource);
        }*/
        [Authorize(Roles="Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(User_Role_Resource resource)
        {
            var user_Role = mapper.Map<User_Role_Resource, User_role>(resource);
            var result = await user_Role_Service.DeleteAsync(user_Role);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var user_Role_Resource = mapper.Map<User_role, User_Role_Resource>(result.user_Role);
            return Ok(user_Role_Resource);
        }
    }
}