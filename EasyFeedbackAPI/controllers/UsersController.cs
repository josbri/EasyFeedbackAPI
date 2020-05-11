using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyFeedbackAPI.Extensions;
using EasyFeedbackAPI.models;
using EasyFeedbackAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyFeedbackAPI.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet("cognito/{cognito}")]
        public async Task<ActionResult<UserGetDTO>> GetByCognitoID(string cognitoID)
        {
            var userEntity = await _userService.FindByCognitoIdAsync(cognitoID);

            if(userEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserGetDTO>(userEntity));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UserGetDTO>> PutUser(int id, UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var user = _mapper.Map<User>(userDTO);
            var result = await _userService.UpdateAsync(id, user);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(_mapper.Map<UserGetDTO>(result.User));
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var userEntity = _mapper.Map<User>(userDTO);
            var result = await _userService.CreateAsync(userEntity);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(_mapper.Map<UserGetDTO>(result.User));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(_mapper.Map<UserGetDTO>(result.User));
        }

    }
}