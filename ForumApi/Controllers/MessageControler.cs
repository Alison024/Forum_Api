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
    [Route("api/message")]
    public class MessageControler: ControllerBase
    {
        private readonly IMessage_Service message_Service;
        private readonly IMapper mapper;
        public MessageControler(IMessage_Service message_Service, IMapper mapper)
        {
            this.message_Service = message_Service;
            this.mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<Message_Resource>> GetAllAsync(){
            var messages = await message_Service.GetAllAsync();
            var resource = mapper.Map<IEnumerable<Message>, IEnumerable<Message_Resource>>(messages);
            return resource;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Message_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var message = mapper.Map<Message_Resource, Message>(resource);
            var result = await message_Service.SaveAsync(message);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var message_Resource = mapper.Map<Message, Message_Resource>(result.message);
            return Ok(message_Resource);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Message_Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var message = mapper.Map<Message_Resource, Message>(resource);
            var result = await message_Service.UpdateAsync(message);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var message_Resource = mapper.Map<Message, Message_Resource>(result.message);
            return Ok(message_Resource);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await message_Service.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var message_Resource = mapper.Map<Message, Message_Resource>(result.message);
            return Ok(message_Resource);
        }
    }
}