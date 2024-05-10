using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakerShop.Core.ApplicationContext;
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
    [Authorize(Roles = Constants.CustomerUserRoleName)]
    public class OrdersController : ControllerBase, IEntityController
    {

        private readonly IOrdersService _OrdersService;

        public OrdersController(IOrdersService ordersService)
        {
            _OrdersService = ordersService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> MakeOrderFromBasket()
        {
            return new JsonResult(await _OrdersService.MakeOrderFromBasket());
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> Get([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _OrdersService.Get(baseParams));
        }
        
        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetAll([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _OrdersService.GetAll(baseParams));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = Constants.AdminUserRoleName)]
        public async Task<JsonResult> Add([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _OrdersService.Add(postParams));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = Constants.AdminUserRoleName)]
        public async Task<JsonResult> Update([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _OrdersService.Update(postParams));
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = Constants.AdminUserRoleName)]
        public async Task<JsonResult> Delete([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _OrdersService.Delete(postParams));
        }

    }
}