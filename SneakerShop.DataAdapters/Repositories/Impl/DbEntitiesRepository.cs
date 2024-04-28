using AutoMapper;
using SneakerShop.DataAdapters.ApplicationContexts;
using SneakerShop.DataAdapters.Contracts.Models.Entities;
using SneakerShop.DataAdapters.Contracts.Repositories.Intf;
using SneakerShop.DataAdapters.Map;

namespace SneakerShop.DataAdapters.Repositories.Impl
{
    /// <summary>
    /// Реализация репозитория для работы с БД
    /// </summary>
    public class DbEntitiesRepository : IDbEntitiesRepository
    {

        private readonly ApplicationContext _Context;

        private readonly IMapper _Mapper;

        public DbEntitiesRepository(ApplicationContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public virtual IQueryable<T> GetAll<T>() where T : class, IEntity
        {
            var result = _Context.Set<T>().AsQueryable();
            var map = MapLinks.GetMap(typeof(T));
            return (IQueryable<T>) _Mapper.ProjectTo(result, map.DestinationType);
        }

        public virtual async Task<object> Add<T>(T newEntity) where T : class, IEntity
        {
            var map = MapLinks.GetMap(typeof(T));
            var entityForSave = _Mapper.Map(newEntity, map.SourceType, map.DestinationType);
            var entity = await _Context.AddAsync(entityForSave);
            await SaveChanges();
            return _Mapper.Map(entity.Entity, map.DestinationType, map.SourceType);
        }

        public virtual async Task AddRange<T>(IEnumerable<T> newEntities) where T : class, IEntity
        {
            var map = MapLinks.GetMap(typeof(T));
            var entitiesForSave = newEntities.Select(x => _Mapper.Map(x, map.SourceType, map.DestinationType));
            await _Context.AddRangeAsync(entitiesForSave);
            await SaveChanges();
        }

        public virtual async Task<object> Update<T>(T entity) where T : class, IEntity
        {
            var map = MapLinks.GetMap(typeof(T));
            var entityForSave = _Mapper.Map(entity, map.SourceType, map.DestinationType);
            _Context.Update(entityForSave);
            await SaveChanges();
            return entity;
        }

        public virtual async Task UpdateRange<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            var map = MapLinks.GetMap(typeof(T));
            var entitiesForSave = entities.Select(x => _Mapper.Map(x, map.SourceType, map.DestinationType));
            _Context.UpdateRange(entitiesForSave);
            await SaveChanges();
        }

        public virtual async Task<object> Delete<T>(T entity) where T : class, IEntity
        {
            var map = MapLinks.GetMap(typeof(T));
            entity.IsActual = false;

            var entityForSave = _Mapper.Map(entity, map.SourceType, map.DestinationType);
            _Context.Update(entityForSave);

            await SaveChanges();
            return entity;
        }

        public virtual async Task<object> Remove<T>(T entity) where T : class, IEntity
        {
            var map = MapLinks.GetMap(typeof(T));
            var entityToDelete = _Mapper.Map(entity, map.SourceType, map.DestinationType);

            _Context.Remove(entityToDelete);

            await SaveChanges();
            return entity;
        }

        public virtual async Task RemoveRange<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            var map = MapLinks.GetMap(typeof(T));
            var entitiesToDelete = entities.Select(x => _Mapper.Map(x, map.SourceType, map.DestinationType));

            _Context.RemoveRange(entitiesToDelete);

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