using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakerShop.Core.ApplicationContext;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Services.Entities;
using SneakerShop.Web.Controllers.EntityController;

namespace SneakerShop.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер типов товаров
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class GoodTypesController : ControllerBase, IEntityController
    {

        private readonly IGoodTypesService _GoodTypesService;

        public GoodTypesController(IGoodTypesService goodTypesService)
        {
            _GoodTypesService = goodTypesService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> Get([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _GoodTypesService.Get(baseParams));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetAll([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _GoodTypesService.GetAll(baseParams));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Constants.AdminUserRoleName)]
        public async Task<JsonResult> Add([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _GoodTypesService.Add(postParams));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Constants.AdminUserRoleName)]
        public async Task<JsonResult> Update([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _GoodTypesService.Update(postParams));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Constants.AdminUserRoleName)]
        public async Task<JsonResult> Delete([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _GoodTypesService.Delete(postParams));
        }

    }
}