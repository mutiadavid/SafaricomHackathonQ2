using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafaricomHackathonQ2.Logic.Requests;
using SafaricomHackathonQ2.Logic.Services.Contracts;

namespace SafaricomHackathonQ2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService; 
        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Creating user - one be buying credit
        /// </summary>
        /// <param name="createuserRequest"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest createuserRequest)
        {
            var result = await _userService.CreateUserAsync(createuserRequest);
            return Ok(result);
        }
    }
}