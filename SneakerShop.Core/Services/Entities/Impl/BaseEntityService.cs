using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Entities.Intf;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Repositories.Intf;
using SneakerShop.Core.Services.Users;

namespace SneakerShop.Core.Services.Impl
{
    /// <summary>
    /// Базовый класс для работы с сущностями
    /// </summary>
    public abstract class BaseEntityService<T> : IEntityService<T>
        where T : class, IEntity
    {

        protected readonly IDbEntitiesRepository<T> DbRepository;

        protected readonly IAuthenticationService AuthenticationService;

        protected BaseEntityService(IDbEntitiesRepository<T> dbRepository, IAuthenticationService authenticationService)
        {
            DbRepository = dbRepository;
            AuthenticationService = authenticationService;
        }

        public virtual async Task<Result<T>> Get(BaseListParams baseParams)
        {
            var id = Guid.Parse(baseParams.GetFilterValue("Id").ToString());
            var result = await DbRepository.Get(id);
            return new Result<T>(true, result);
        }

        public virtual async Task<Result<List<T>>> GetAll(BaseListParams baseParams)
        {
            var result = DbRepository.GetAll(baseParams.Filters)
                .WithOrdering(baseParams)
                .WithPagination(baseParams);
            return new Result<List<T>>(true, await result.ToListAsync());
        }

        public virtual async Task<Result<T>> Add(BasePostParams postParams)
        {
            var userResult = await AuthenticationService.GetCurrentUser();
            var user = userResult.Data;
            var entity = postParams.ToEntity<T>();

            if (user == null || entity == null)
                return new Result<T>(false, null, "Не найден пользователь или не удалось сконвертировать сущность");

            entity.CreatedUserId = user.Id;

            entity = await DbRepository.Add(entity);

            return new Result<T>(true, entity);
        }

        public virtual async Task<Result<T>> Update(BasePostParams postParams)
        {
            var userResult = await AuthenticationService.GetCurrentUser();
            var user = userResult.Data;
            var entity = postParams.ToEntity<T>();

            if (user == null || entity == null)
                return new Result<T>(false, null, "Не найден пользователь или не удалось сконвертировать сущность");

            entity.UpdatedUserId = user.Id;
            entity.UpdateDate = DateTime.Now;

            entity = await DbRepository.Update(entity);

            return new Result<T>(true, entity);
        }

        public virtual async Task<Result<T>> Delete(BasePostParams postParams)
        {
            var userResult = await AuthenticationService.GetCurrentUser();
            var user = userResult.Data;
            var entity = postParams.ToEntity<T>();

            if (user == null || entity == null)
                return new Result<T>(false, null, "Не найден пользователь или не удалось сконвертировать сущность");

            entity = await DbRepository.Get(entity.Id);
            entity.DeletedUserId = user.Id;
            entity.DeleteDate = DateTime.Now;

            entity = await DbRepository.Delete(entity);

            return new Result<T>(true, entity);
        }

    }
}