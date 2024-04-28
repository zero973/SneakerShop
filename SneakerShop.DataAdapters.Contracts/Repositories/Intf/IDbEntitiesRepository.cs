using SneakerShop.DataAdapters.Contracts.Models.Entities;

namespace SneakerShop.DataAdapters.Contracts.Repositories.Intf
{
    /// <summary>
    /// Интерфейс для репозитория БД
    /// </summary>
    public interface IDbEntitiesRepository
    {

        /// <summary>
        /// Получить все сущности
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQueryable<T> GetAll<T>() where T : class, IEntity;

        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newEntity"></param>
        /// <returns></returns>
        Task<object> Add<T>(T newEntity) where T : class, IEntity;

        /// <summary>
        /// Добавить диапазон сущностей
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newEntities"></param>
        /// <returns></returns>
        Task AddRange<T>(IEnumerable<T> newEntities) where T : class, IEntity;

        /// <summary>
        /// Изменить сущность
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<object> Update<T>(T entity) where T : class, IEntity;

        /// <summary>
        /// Изменить диапазон сущностей
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task UpdateRange<T>(IEnumerable<T> entities) where T : class, IEntity;

        /// <summary>
        /// Сделать сущность не активной (<see cref="IEntity.IsActual"/> = false)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<object> Delete<T>(T entity) where T : class, IEntity;

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<object> Remove<T>(T entity) where T : class, IEntity;

        /// <summary>
        /// Удалить диапазон сущностей
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task RemoveRange<T>(IEnumerable<T> entities) where T : class, IEntity;

    }
}