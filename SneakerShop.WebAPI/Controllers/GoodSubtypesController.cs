using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class GoodSubtypesController : ControllerBase, IEntityController
    {

        private readonly IGoodSubtypesService _GoodSubtypesService;

        public GoodSubtypesController(IGoodSubtypesService goodSubtypesService)
        {
            _GoodSubtypesService = goodSubtypesService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> Get([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _GoodSubtypesService.Get(baseParams));
        }

        [Authorize("Admin")]
        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetAll([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _GoodSubtypesService.GetAll(baseParams));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> GetActualEntities([FromQuery] BaseListParams baseParams)
        {
            return new JsonResult(await _GoodSubtypesService.GetActuals(baseParams));
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Add([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _GoodSubtypesService.Add(postParams));
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Update([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _GoodSubtypesService.Update(postParams));
        }

        [Authorize("Admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<JsonResult> Delete([FromBody] BasePostParams postParams)
        {
            return new JsonResult(await _GoodSubtypesService.Delete(postParams));
        }

    }
}