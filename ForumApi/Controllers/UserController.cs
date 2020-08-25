using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    [Route("api/users")]
    public class UserController: ControllerBase
    {
        private readonly IUser_Service userService;
        private readonly IMapper mapper;
        public UserController(IUser_Service userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<User_Resource>> GetAllAsync(){
            var users = await userService.GetAllAsync();
            var resource = mapper.Map<IEnumerable<User>, IEnumerable<User_Resource>>(users);
            return resource;
        }
        [HttpGet("getUserById/{id}")]
        public async Task<User_Resource> GetUserById(int id){
            var users = await userService.GetAllAsync();
            var user = users.SingleOrDefault(x=>x.Id==id);
            var resource = mapper.Map<User,User_Resource>(user);
            return resource;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Register_User_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = mapper.Map<Register_User_Resource, User>(resource);
            user.Password = Helper_MD5.GenerateMD5Hash(user.Password);
            var result = await userService.SaveAsync(user);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var userResource = mapper.Map<User, User_Resource>(result.user);
            return Ok(userResource);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] User_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = mapper.Map<User_Resource, User>(resource);
            var result = await userService.UpdateAsync(user);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var userResource = mapper.Map<User, User_Resource>(result.user);
            return Ok(userResource);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await userService.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var userResource = mapper.Map<User, User_Resource>(result.user);
            return Ok(userResource);
        }
    }
}