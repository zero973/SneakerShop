using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Services;
using SneakerShop.Web.Controllers.EntityController;

namespace SneakerShop.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер заказов пользователя
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Customer")]
    public class OrdersController : ControllerBase, IEntityController
    {
        private readonly IOrdersService _OrdersService;

        public OrdersController(IOrdersService ordersService)
        {
            _OrdersService = ordersService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> Get([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _OrdersService.Get(baseParams));
        }
        
        [Authorize("Admin")]
        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetAll([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _OrdersService.GetAll(baseParams));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetActualEntities([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _OrdersService.GetActuals(baseParams));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> MakeOrderFromBasket()
        {
            return new JsonResult(await _OrdersService.MakeOrderFromBasket());
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Add([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _OrdersService.Add(postParams));
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Update([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _OrdersService.Update(postParams));
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Delete([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _OrdersService.Delete(postParams));
        }
    }
}