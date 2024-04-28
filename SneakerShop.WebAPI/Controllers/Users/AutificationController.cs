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
    public class AutificationController : ControllerBase
    {

        private readonly IAutificationService _AutificationService;

        public AutificationController(IAutificationService autificationService)
        {
            _AutificationService = autificationService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetCurrentUser()
        {
            return new JsonResult(await _AutificationService.GetCurrentUser());
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> LogIn([FromBody] LoginModel data)
        {
            return new JsonResult(await _AutificationService.LogIn(data));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> SignUp([FromBody] RegistrationModel data)
        {
            return new JsonResult(await _AutificationService.SignUp(data));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> SignOut()
        {
            await _AutificationService.SignOut();
            return new JsonResult(true);
        }

    }
}