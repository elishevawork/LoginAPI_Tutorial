using LoginAPI_Tutorial.Interfaces;
using LoginAPI_Tutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI_Tutorial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _lodinService;
        private readonly IConfiguration _config;
        public LoginController(ILoginService loginService, IConfiguration config)
        {
            _lodinService = loginService;
            _config = config;
        }

        [HttpPost("RequestLogin")]
        public async Task<IActionResult> RequestLogin([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var otpInfo = await _lodinService.RequestLogin(loginRequest);
                if (otpInfo == null)
                    return Unauthorized();

                return Ok(otpInfo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }




    }
}
