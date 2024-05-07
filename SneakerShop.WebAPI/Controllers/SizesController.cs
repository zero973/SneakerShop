using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakerShop.Core.ApplicationContext;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Services.Entities;
using SneakerShop.Web.Controllers.EntityController;

namespace SneakerShop.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер размеров товаров
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SizesController : ControllerBase, IEntityController
    {

        private readonly ISizesService _SizesService;

        public SizesController(ISizesService ordersService)
        {
            _SizesService = ordersService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> Get([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _SizesService.Get(baseParams));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetAll([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _SizesService.GetAll(baseParams));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Constants.AdminUserRoleName)]
        public async Task<JsonResult> Add([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _SizesService.Add(postParams));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Constants.AdminUserRoleName)]
        public async Task<JsonResult> Update([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _SizesService.Update(postParams));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Constants.AdminUserRoleName)]
        public async Task<JsonResult> Delete([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _SizesService.Delete(postParams));
        }
    }
}