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
using ForumApi.Domain.Responses;
using Microsoft.AspNetCore.Authorization;

namespace ForumApi.Controllers
{
    [Route("api/auth")]
    public class AuthorizationController:Controller
    {
        private readonly IAuth_Service auth_Service;
        private readonly IMapper mapper;
        public AuthorizationController(IAuth_Service auth_Service, IMapper mapper){
            this.auth_Service = auth_Service;
            this.mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Auth_User_Resource auth_User_Resource){
            var user = await auth_Service.Authenticate(auth_User_Resource.Email,auth_User_Resource.Password);
            var result = mapper.Map<User,User_Resource>(user);
            
            var response = new Response_Date
            {
                Success = result != null,
                Message = result != null ? "" : "Incorrect login or password",
                Data = result
            };

            return Ok(response);
        }

    }
}