using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeCare_Api.Contracts;
using WeCare_Api.Modals;
using WeCare_Api.Services;

namespace WeCare_Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost(ApiRoute.Account.Create)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.RegisterAsync(registerModel);
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPost(ApiRoute.Account.Login)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.LoginAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
