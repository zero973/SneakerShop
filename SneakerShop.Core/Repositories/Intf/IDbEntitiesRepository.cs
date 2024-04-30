using SneakerShop.Core.Models.Entities.Intf;
using SneakerShop.Core.Models.Web;

namespace SneakerShop.Core.Repositories.Intf
{
    /// <summary>
    /// Интерфейс репозитория для работы с БД только с сущностями типа <see cref="IEntity"/> 
    /// и которые зарегистрированы в мапинге
    /// </summary>
    public interface IDbEntitiesRepository<T> where T : class, IEntity
    {

        /// <summary>
        /// Получить объект по <see cref="IEntity.Id"/>
        /// </summary>
        Task<T> Get(Guid id);

        /// <summary>
        /// Получить все сущности с фильтрами <paramref name="filters"/>
        /// </summary>
        IQueryable<T> GetAll(IList<ComplexFilter> filters);

        /// <summary>
        /// Добавить сущность
        /// </summary>
        Task<T> Add(T newEntity);

        /// <summary>
        /// Добавить диапазон сущностей
        /// </summary>
        Task AddRange(IEnumerable<T> newEntities);

        /// <summary>
        /// Изменить сущность
        /// </summary>
        Task<T> Update(T entity);

        /// <summary>
        /// Изменить диапазон сущностей
        /// </summary>
        Task UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// Сделать сущность не активной (<see cref="IEntity.IsActual"/> = false)
        /// </summary>
        Task<T> Delete(T entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        Task<T> Remove(T entity);

        /// <summary>
        /// Удалить диапазон сущностей
        /// </summary>
        Task RemoveRange(IEnumerable<T> entities);

    }
}