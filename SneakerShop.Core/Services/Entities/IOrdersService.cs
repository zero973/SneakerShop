using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Models.Web;

namespace SneakerShop.Core.Services
{
    /// <summary>
    /// Интерфейс для работы с пользовательскими заказами
    /// </summary>
    public interface IOrdersService : IEntityService<Order>
    {

        /// <summary>
        /// Сформировать заказ из пользовательской корзины
        /// </summary>
        Task<Result> MakeOrderFromBasket();

    }
}