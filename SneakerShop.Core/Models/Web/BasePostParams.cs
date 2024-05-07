using SneakerShop.Core.Models.Entities.Intf;
using System.Text.Json;

namespace SneakerShop.Core.Models.Web
{
    /// <summary>
    /// Параметры для запросов вида Add, Update, Delete
    /// </summary>
    public class BasePostParams
    {

        /// <summary>
        /// Данные о сущности
        /// </summary>
        public dynamic Data { get; set; }

        public T ToEntity<T>() where T : class, IEntity
        {
            return JsonSerializer.Deserialize<T>(Data);
        }

    }
}