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
    [Route("api/user-info")]
    public class UserInfoController: ControllerBase
    {
        private readonly IUser_Info_Service user_Info_Service;
        private readonly IMapper mapper;
        public UserInfoController(IUser_Info_Service user_Info_Service, IMapper mapper)
        {
            this.user_Info_Service = user_Info_Service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<User_Info_Resource>> GetAllAsync(){
            var user_Infos = await user_Info_Service.GetAllAsync();
            var resource = mapper.Map<IEnumerable<User_info>, IEnumerable<User_Info_Resource>>(user_Infos);
            return resource;
        }
        [Authorize(Roles="Admin")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] User_Info_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user_Info = mapper.Map<User_Info_Resource, User_info>(resource);
            var result = await user_Info_Service.SaveAsync(user_Info);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var user_Info_Resource = mapper.Map<User_info, User_Info_Resource>(result.user_Info);
            return Ok(user_Info_Resource);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] User_Info_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user_Info = mapper.Map<User_Info_Resource, User_info>(resource);
            var result = await user_Info_Service.UpdateAsync(user_Info);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var user_Info_Resource = mapper.Map<User_info, User_Info_Resource>(result.user_Info);
            return Ok(user_Info_Resource);
        }
        [Authorize(Roles="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await user_Info_Service.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var user_Info_Resource = mapper.Map<User_info, User_Info_Resource>(result.user_Info);
            return Ok(user_Info_Resource);
        }
    }
}