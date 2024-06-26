﻿using Microsoft.AspNetCore.Mvc;
using SneakerShop.Web.Controllers.EntityController;
using SneakerShop.Core.Services;
using Microsoft.AspNetCore.Authorization;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.ApplicationContext;

namespace SneakerShop.Web.Controllers
{
    /// <summary>
    /// Контроллер корзины пользователя
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BasketController : ControllerBase, IEntityController
    {

        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService) 
        {
            _basketService = basketService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> Get([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _basketService.Get(baseParams));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetAll([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _basketService.GetAll(baseParams));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Add([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _basketService.Add(postParams));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Update([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _basketService.Update(postParams));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Delete([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _basketService.Delete(postParams));
        }

    }
}