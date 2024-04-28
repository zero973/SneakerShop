using Microsoft.AspNetCore.Mvc;
using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Models.Web;
using System.Text.Json;

namespace SneakerShop.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {

        private List<Good> Goods;
        private List<BasketElement> Basket;

        public HomeController()
        {
            
        }

        #region ВЫНЕСТИ В БАСКЕТ КОНТРОЛЛЕР

        [HttpGet]
        [Route("[action]")]
        public JsonResult GetMainMenuGoods([FromQuery] BaseListParams prms)
        {
            var result = new Result(true, Goods, prms.ToString());
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("[action]")]
        public JsonResult GetUserBasket([FromQuery] BaseListParams prms)
        {
            var result = new Result(true, Basket, prms.ToString());
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> DeleteUserBasketElement([FromBody] dynamic prms)
        {
            var basketElement = await JsonSerializer.DeserializeAsync<BasketElement>(prms);
            var elementId = Guid.Parse(prms.Body.id);
            // тут мы должны получить Id удаляемого элемента из корзины
            Basket.RemoveAll(x => x.Id == elementId);

            var result = new Result(true, null, "Операция выполнена !");
            return new JsonResult(result);
        }

        #endregion

    }
}