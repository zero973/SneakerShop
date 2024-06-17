using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Entities.Intf;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Repositories.Intf;
using SneakerShop.DAL.ApplicationContexts;

namespace SneakerShop.DAL.Repositories.Impl
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

        protected readonly ApplicationContext Context;

        protected readonly IMapper Mapper;

        protected BaseDbEntitiesRepository(ApplicationContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual async Task<T> Get(Guid id)
        {
            var result = await Context.Set<U>().SingleOrDefaultAsync(x => x.Id == id);
            return Mapper.Map<T>(result);
        }

        public virtual IQueryable<T> GetAll(IList<ComplexFilter> filters) 
        {
            var result = Context.Set<U>().AsQueryable();

            if (filters != null && filters.Any())
                result = result.WithFilters(filters);

            return Mapper.ProjectTo<T>(result);
        }

        public virtual async Task<T> Add(T newEntity) 
        {
            var entityForSave = Mapper.Map<U>(newEntity);
            var savedEntity = await Context.Set<U>().AddAsync(entityForSave);

            await SaveChanges();
            return Mapper.Map<T>(savedEntity.Entity);
        }

        public virtual async Task AddRange(IEnumerable<T> newEntities) 
        {
            var entitiesForSave = newEntities.Select(Mapper.Map<U>);
            await Context.Set<U>().AddRangeAsync(entitiesForSave);

            await SaveChanges();
        }

        public virtual async Task<T> Update(T entity) 
        {
            var entityForSave = Mapper.Map<U>(entity);
            Context.Set<U>().Update(entityForSave);

            await SaveChanges();
            return Mapper.Map<T>(entityForSave);
        }

        public virtual async Task UpdateRange(IEnumerable<T> entities) 
        {
            var entitiesForSave = entities.Select(Mapper.Map<U>);
            Context.Set<U>().UpdateRange(entitiesForSave);

            await SaveChanges();
        }

        public virtual async Task<T> Delete(T entity) 
        {
            entity.IsActual = false;

            var entityForSave = Mapper.Map<U>(entity);
            Context.Set<U>().Update(entityForSave);

            await SaveChanges();
            return Mapper.Map<T>(entityForSave);
        }

        public virtual async Task<T> Remove(T entity) 
        {
            var entityToDelete = Mapper.Map<U>(entity);

            Context.Set<U>().Remove(entityToDelete);

            await SaveChanges();
            return Mapper.Map<T>(entityToDelete);
        }

        public virtual async Task RemoveRange(IEnumerable<T> entities) 
        {
            var entitiesToDelete = entities.Select(Mapper.Map<U>);

            Context.Set<U>().RemoveRange(entitiesToDelete);

            await SaveChanges();
        }

        /// <summary>
        /// Сохраняет изменения в базу данных
        /// </summary>
        /// <returns>Возвращает кол-во добавленных/изменённых строк</returns>
        protected virtual async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }

    }
}