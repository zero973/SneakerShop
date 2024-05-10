using SneakerShop.Core.Models.Entities.Intf;
using SneakerShop.Core.Models.Web;

namespace SneakerShop.Core.Services
{
    /// <summary>
    /// Базовый интерфейс для сервисов, которые работают с сущностями
    /// </summary>
    public interface IEntityService<T> where T : class, IEntity
    {

        /// <summary>
        /// Получить элемент по заданному <see cref="IEntity.Id"/>
        /// </summary>
        /// <returns></returns>
        Task<Result<T>> Get(BaseListParams baseParams);

        /// <summary>
        /// Получить все элементы с пагинацией, сортировкой и фильтрацией
        /// </summary>
        /// <returns></returns>
        Task<Result<List<T>>> GetAll(BaseListParams baseParams);

        /// <summary>
        /// Добавить новую сущность
        /// </summary>
        Task<Result<T>> Add(BasePostParams postParams);

        /// <summary>
        /// Изменить сущность
        /// </summary>
        Task<Result<T>> Update(BasePostParams postParams);

        /// <summary>
        /// Удалить данные о сущности
        /// </summary>
        Task<Result<T>> Delete(BasePostParams postParams);

    }
}