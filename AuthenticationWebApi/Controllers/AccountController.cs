using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;

        public AccountController(JwtTokenHandler jwtTokenHandler)
            => this._jwtTokenHandler = jwtTokenHandler;

        [HttpPost]
        public ActionResult<AuthenticationResponse> Authenticate([FromBody] AuthenticationRequest request)
        {
            var response = this._jwtTokenHandler.GenerateJwtToken(request);
            if (response == null)
                return Unauthorized();
            return response;
        }
    }
}
