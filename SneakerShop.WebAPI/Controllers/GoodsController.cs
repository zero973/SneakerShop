using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakerShop.Core.ApplicationContext;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Services.Entities;
using SneakerShop.Web.Controllers.EntityController;

namespace SneakerShop.Web.Controllers
{
    /// <summary>
    /// Контроллер товаров
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class GoodsController : ControllerBase, IEntityController
    {

        private readonly IGoodsService _goodsService;

        public GoodsController(IGoodsService goodsService)
        {
            _goodsService = goodsService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> Get([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _goodsService.Get(baseParams));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetAll([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _goodsService.GetAll(baseParams));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetGoodsWithAnyDiscount([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _goodsService.GetGoodsWithAnyDiscount(baseParams));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = Constants.AdminUserRoleName)]
        public async Task<JsonResult> Add([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _goodsService.Add(postParams));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = Constants.AdminUserRoleName)]
        public async Task<JsonResult> Update([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _goodsService.Update(postParams));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = Constants.AdminUserRoleName)]
        public async Task<JsonResult> Delete([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _goodsService.Delete(postParams));
        }
    }
}