using eWallet.Services.Catalog.System.Users;
using eWallet.Services.Catalog.System.Users.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eWallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApiAuthController : ControllerBase
    {
        public readonly ITestUserService _userService;
        public TestApiAuthController(ITestUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<TestApiAuth>
        [HttpGet("TAuth")]
        [AllowAnonymous]
        public async Task<ActionResult> TAuth()
        {
            LoginRequest request = new LoginRequest();
            request.UserName = "admin";
            request.Password = "123456";
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var resultToken = await _userService.TestAuth(request);
            if ((resultToken) == null)
                return BadRequest("0");
            else
                return Ok(resultToken);
        }
    }
}
