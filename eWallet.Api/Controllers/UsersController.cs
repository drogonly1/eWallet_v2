using eWallet.Services.Catalog.System.Users;
using eWallet.Services.Catalog.System.Users.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eWallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [EnableCors("AnotherPolicy")]
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var resultToken = await _userService.Authencate(request);
            string res = JsonConvert.SerializeObject(resultToken);
            return Ok(res);
        }

        [HttpPost("registry")]
        [AllowAnonymous]
        public async Task<ActionResult> Registry([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.Register(request);
            if (!result)
                return BadRequest("Register is unsuccesful.");
            else
                return Ok("10");
        }

        
    }
}
