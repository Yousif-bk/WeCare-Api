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
        private readonly IAuthRespiratory _authRespiratory;

        public AuthController(IAuthRespiratory authRespiratory)
        {
            _authRespiratory = authRespiratory;
        }


        [HttpPost(ApiRoute.Account.Create)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authRespiratory.RegisterAsync(registerModel);
            if (!result.IsAuthenticated)
                return BadRequest(new BaseResponse(false, 400, result.Message));
            return Ok(result);
        }

        [HttpPost(ApiRoute.Account.Login)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authRespiratory.LoginAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(new BaseResponse(false, 400, result.Message));

            return Ok(result);
        }
    }
}
