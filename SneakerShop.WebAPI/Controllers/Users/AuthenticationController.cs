using Microsoft.AspNetCore.Mvc;
using SneakerShop.Core.Models.Web.Auth;
using SneakerShop.Core.Services.Users;

namespace SneakerShop.WebAPI.Controllers.Users
{
    /// <summary>
    /// Контроллер для аутентификации и авторизации
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationService _AuthenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _AuthenticationService = authenticationService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetCurrentUser()
        {
            return new JsonResult(await _AuthenticationService.GetCurrentUser());
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> LogIn([FromBody] LoginModel data)
        {
            return new JsonResult(await _AuthenticationService.LogIn(data));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> SignUp([FromBody] RegistrationModel data)
        {
            return new JsonResult(await _AuthenticationService.SignUp(data));
        }

        [HttpPost]
        [Route("[action]")]
        public async new Task<JsonResult> SignOut()
        {
            await _AuthenticationService.SignOut();
            return new JsonResult(true);
        }

    }
}