using Microsoft.AspNetCore.Mvc;
using SneakerShop.Web.Controllers.EntityController;
using SneakerShop.Core.Services;
using Microsoft.AspNetCore.Authorization;
using SneakerShop.Core.Models.Web;

namespace SneakerShop.Web.Controllers
{
    /// <summary>
    /// Контроллер корзины пользователя
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Customer")]
    public class BasketController : ControllerBase, IEntityController
    {

        private readonly IBasketService _BasketService;

        public BasketController(IBasketService basketService) 
        {
            _BasketService = basketService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> Get([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _BasketService.Get(baseParams));
        }

        [Authorize("Admin")]
        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetAll([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _BasketService.GetAll(baseParams));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetActualEntities([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _BasketService.GetActuals(baseParams));
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Add([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _BasketService.Add(postParams));
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Update([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _BasketService.Update(postParams));
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Delete([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _BasketService.Delete(postParams));
        }

    }
}