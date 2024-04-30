using AutoMapper;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Entities.Intf;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Repositories.Intf;
using SneakerShop.DataAdapters.ApplicationContexts;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    /// <summary>
    /// Реализация репозитория для работы с БД только с сущностями типа <see cref="IEntity"/> 
    /// и которые зарегистрированы в мапинге
    /// </summary>
    /// <typeparam name="T">Тип для веба</typeparam>
    /// <typeparam name="U">Тип в БД</typeparam>
    public abstract class BaseDbEntitiesRepository<T, U> : IDbEntitiesRepository<T>
        where T : class, IEntity
        where U : class, IEntity
    {

        private readonly ApplicationContext _Context;

        private readonly IMapper _Mapper;

        public BaseDbEntitiesRepository(ApplicationContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public virtual async Task<T> Get(Guid id)
        {
            var result = await _Context.Set<U>().FindAsync(id);
            return _Mapper.Map<T>(result);
        }

        public virtual IQueryable<T> GetAll(IList<ComplexFilter> filters) 
        {
            var result = _Context.Set<U>().AsQueryable();

            if (filters != null && filters.Any())
                result = result.WithFilters(filters);

            return _Mapper.ProjectTo<T>(result);
        }

        public virtual async Task<T> Add(T newEntity) 
        {
            var entityForSave = _Mapper.Map<U>(newEntity);
            await _Context.Set<U>().AddAsync(entityForSave);
            await SaveChanges();
            return newEntity;
        }

        public virtual async Task AddRange(IEnumerable<T> newEntities) 
        {
            var entitiesForSave = newEntities.Select(_Mapper.Map<U>);
            await _Context.Set<U>().AddRangeAsync(entitiesForSave);
            await SaveChanges();
        }

        public virtual async Task<T> Update(T entity) 
        {
            var entityForSave = _Mapper.Map<U>(entity);
            _Context.Set<U>().Update(entityForSave);
            await SaveChanges();
            return entity;
        }

        public virtual async Task UpdateRange(IEnumerable<T> entities) 
        {
            var entitiesForSave = entities.Select(_Mapper.Map<U>);
            _Context.Set<U>().UpdateRange(entitiesForSave);
            await SaveChanges();
        }

        public virtual async Task<T> Delete(T entity) 
        {
            entity.IsActual = false;

            var entityForSave = _Mapper.Map<U>(entity);
            _Context.Set<U>().Update(entityForSave);

            await SaveChanges();
            return entity;
        }

        public virtual async Task<T> Remove(T entity) 
        {
            var entityToDelete = _Mapper.Map<U>(entity);

            _Context.Set<U>().Remove(entityToDelete);

            await SaveChanges();
            return entity;
        }

        public virtual async Task RemoveRange(IEnumerable<T> entities) 
        {
            var entitiesToDelete = entities.Select(_Mapper.Map<U>);

            _Context.Set<U>().RemoveRange(entitiesToDelete);

            await SaveChanges();
        }

        /// <summary>
        /// Сохраняет изменения в базу данных
        /// </summary>
        /// <returns>Возвращает кол-во добавленных/изменённых строк</returns>
        protected virtual async Task<int> SaveChanges()
        {
            return await _Context.SaveChangesAsync();
        }

    }
}