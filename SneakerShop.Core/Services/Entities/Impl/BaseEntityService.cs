using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Services.Users;
using SneakerShop.DataAdapters.Contracts.Models.Entities;
using SneakerShop.DataAdapters.Contracts.Repositories.Intf;
using System.Text.Json;

namespace SneakerShop.Core.Services.Impl
{
    /// <summary>
    /// Базовый класс для работы с сущностями
    /// </summary>
    /// <typeparam name="T">Тип для веба</typeparam>
    /// <typeparam name="U">Тип в БД</typeparam>
    public class BaseEntityService<T, U> : IEntityService<T>
        where T : class, IEntity
        where U : class, IEntity
    {

        private readonly IDbEntitiesRepository DbRepository;

        private readonly IAutificationService _AutificationService;

        public BaseEntityService(IDbEntitiesRepository dbRepository, IAutificationService autificationService, IMapper mapper)
        {
            DbRepository = dbRepository;
            _AutificationService = autificationService;
            _Mapper = mapper;
        }

        #region Result methods

        public virtual async Task<Result> Get(BaseListParams baseParams)
        {
            return new Result(true, GetEntity(baseParams));
        }

        public virtual async Task<Result> GetAll(BaseListParams baseParams)
        {
            return new Result(true, GetAllEntities(baseParams));
        }

        public virtual async Task<Result> GetActuals(BaseListParams baseParams)
        {
            return new Result(true, GetActualEntities(baseParams));
        }

        public virtual async Task<Result> Add(BasePostParams postParams)
        {
            return new Result(true, AddEntity(postParams));
        }

        public virtual async Task<Result> Update(BasePostParams postParams)
        {
            return new Result(true, UpdateEntity(postParams));
        }

        public virtual async Task<Result> Delete(BasePostParams postParams)
        {
            return new Result(true, DeleteEntity(postParams));
        }

        #endregion

        #region Entity methods

        /// <summary>
        /// Получить сущность с мапингом
        /// </summary>
        protected virtual async Task<T> GetEntity(BaseListParams baseParams)
        {
            var id = Guid.Parse(baseParams.GetFilterValue("Id").ToString());
            var result = await DbRepository.Get<U>(id);
            return _Mapper.Map<T>(result);
        }

        /// <summary>
        /// Получить все сущности с фильтрацией, пагинацией, сортировкой и мапингом
        /// </summary>
        protected virtual IQueryable<T> GetAllEntities(BaseListParams baseParams)
        {
            var result = DbRepository.GetAll<U>()
                .WithFilter(baseParams)
                .WithOrdering(baseParams)
                .WithPagination(baseParams);
            return _Mapper.ProjectTo<T>(result);
        }

        /// <summary>
        /// Получить все АКТИВНЫЕ сущности с фильтрацией, пагинацией, сортировкой и мапингом
        /// </summary>
        protected virtual IQueryable<T> GetActualEntities(BaseListParams baseParams)
        {
            var result = DbRepository.GetAll<U>()
                .Where(x => x.IsActual)
                .WithFilter(baseParams)
                .WithOrdering(baseParams)
                .WithPagination(baseParams);
            var sql = result.ToQueryString();
            return _Mapper.ProjectTo<T>(result);
        }

        /// <summary>
        /// Добавить сущность с мапингом
        /// </summary>
        protected virtual async Task<T> AddEntity(BasePostParams postParams)
        {
            var user = _AutificationService.GetCurrentUser();
            var entity = JsonSerializer.DeserializeAsync(postParams.Entity);

            entity.CreatedUserId = user.Id;

            return await DbRepository.Add(_Mapper.Map<U>(entity));
        }

        /// <summary>
        /// Изменить сущность с мапингом
        /// </summary>
        protected virtual async Task<T> UpdateEntity(BasePostParams postParams)
        {
            var user = _AutificationService.GetCurrentUser();
            var entity = JsonSerializer.DeserializeAsync(postParams.Entity);

            entity.UpdatedUserId = user.Id;
            entity.UpdateDate = DateTime.Now;

            return await DbRepository.Update(_Mapper.Map<U>(entity));
        }

        /// <summary>
        /// Удалить сущность с мапингом
        /// </summary>
        protected virtual async Task<T> DeleteEntity(BasePostParams postParams)
        {
            var user = _AutificationService.GetCurrentUser();
            var entity = JsonSerializer.DeserializeAsync(postParams.Entity);

            entity.DeletedUserId = user.Id;
            entity.DeleteDate = DateTime.Now;

            return await DbRepository.Delete(_Mapper.Map<U>(entity));
        }

        #endregion

    }
}