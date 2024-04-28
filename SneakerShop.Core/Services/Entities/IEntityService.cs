using SneakerShop.Core.Models.Web;
using SneakerShop.DataAdapters.Contracts.Models.Entities;

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
        Task<Result> Get(BaseListParams baseParams);

        /// <summary>
        /// Получить все элементы с пагинацией, сортировкой и фильтрацией
        /// </summary>
        /// <returns></returns>
        Task<Result> GetAll(BaseListParams baseParams);

        /// <summary>
        /// Получить все актуальные элементы (<see cref="IEntity.IsActual"/> = true) с пагинацией, сортировкой и фильтрацией
        /// </summary>
        /// <returns></returns>
        Task<Result> GetActuals(BaseListParams baseParams);

        /// <summary>
        /// Добавить новую сущность
        /// </summary>
        Task<Result> Add(BasePostParams postParams);

        /// <summary>
        /// Изменить сущность
        /// </summary>
        Task<Result> Update(BasePostParams postParams);

        /// <summary>
        /// Удалить данные о сущности
        /// </summary>
        Task<Result> Delete(BasePostParams postParams);

    }
}