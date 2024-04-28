using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Services.Entities;
using SneakerShop.Web.Controllers.EntityController;
using System.Text;

namespace SneakerShop.Web.Controllers
{
    /// <summary>
    /// Контроллер товаров
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class GoodsController : ControllerBase, IEntityController
    {

        private readonly IGoodsService _GoodsService;

        public GoodsController(IGoodsService goodsService)
        {
            _GoodsService = goodsService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> Get([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _GoodsService.Get(baseParams));
        }

        [Authorize("Admin")]
        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetAll([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _GoodsService.GetAll(baseParams));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetActualEntities([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _GoodsService.GetActuals(baseParams));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetGoodsWithAnyDiscount([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _GoodsService.GetGoodsWithAnyDiscount(baseParams));
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Add([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _GoodsService.Add(postParams));
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Update([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _GoodsService.Update(postParams));
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Delete([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _GoodsService.Delete(postParams));
        }
    }
}