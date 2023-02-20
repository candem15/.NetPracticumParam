using Hafta4.Odev5_6_7.Dtos.AuthOperations;
using Hafta4.Odev5_6_7.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hafta4.Odev5_6_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        // POST api/Auth/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(LoginUserResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LoginAsync(LoginUserRequestDto user)
        {
            var result = authService.Login(user);

            return Ok(result);
        }

    }
}
