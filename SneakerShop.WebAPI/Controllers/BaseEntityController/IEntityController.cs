using Microsoft.AspNetCore.Mvc;
using SneakerShop.Core.Models.Web;

namespace SneakerShop.Web.Controllers.EntityController
{
    /// <summary>
    /// Интерфейс для базового контроллера сущности <see cref="IEntity"/>
    /// </summary>
    public interface IEntityController
    {

        /// <summary>
        /// Получить сущность по <see cref="IEntity.Id"/>
        /// </summary>
        Task<JsonResult> Get(BaseListParams baseParams);

        /// <summary>
        /// Получить все сущности
        /// </summary>
        Task<JsonResult> GetAll(BaseListParams baseParams);

        /// <summary>
        /// Добавить сущность
        /// </summary>
        Task<JsonResult> Add(BasePostParams postParams);

        /// <summary>
        /// Изменить сущность
        /// </summary>
        Task<JsonResult> Update(BasePostParams postParams);

        /// <summary>
        /// Сделать сущность не активной (<see cref="IEntity.IsActual"/> = false)
        /// </summary>
        Task<JsonResult> Delete(BasePostParams postParams);

    }
}