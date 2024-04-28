using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Models.Web;

namespace SneakerShop.Core.Services.Entities
{
    /// <summary>
    /// Сервис для работы с товарами
    /// </summary>
    public interface IGoodsService : IEntityService<Good>
    {

        /// <summary>
        /// Получить все товары со скидкой с заданными фильтрами <paramref name="baseParams"/>
        /// </summary>
        /// <returns></returns>
        Task<Result> GetGoodsWithAnyDiscount(BaseListParams baseParams);

    }
}