using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Entities;
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

        private readonly IDbEntitiesRepository<T> DbRepository;

        private readonly IAutificationService _AutificationService;

        public BaseEntityService(IDbEntitiesRepository<T> dbRepository, IAutificationService autificationService)
        {
            DbRepository = dbRepository;
            _AutificationService = autificationService;
        }

        public virtual async Task<Result> Get(BaseListParams baseParams)
        {
            var id = Guid.Parse(baseParams.GetFilterValue("Id").ToString());
            var result = await DbRepository.Get(id);
            return new Result(true, result);
        }

        public virtual async Task<Result> GetAll(BaseListParams baseParams)
        {
            var result = DbRepository.GetAll(baseParams.Filters)
                .WithOrdering(baseParams)
                .WithPagination(baseParams);
            return new Result(true, await result.ToListAsync());
        }

        public virtual async Task<Result> Add(BasePostParams postParams)
        {
            var userResult = await _AutificationService.GetCurrentUser();
            var entity = postParams.Entity as IEntity;

            if (userResult == null || entity == null)
                return new Result(false, null, "Не найден пользователь или не удалось сконвертировать сущность");

            var user = userResult.Data as AppUser;
            entity.CreatedUserId = user.Id;

            return new Result(true, entity);
        }

        public virtual async Task<Result> Update(BasePostParams postParams)
        {
            var userResult = await _AutificationService.GetCurrentUser();
            var entity = postParams.Entity as IEntity;

            if (userResult == null || entity == null)
                return new Result(false, null, "Не найден пользователь или не удалось сконвертировать сущность");

            var user = userResult.Data as AppUser;
            entity.UpdatedUserId = user.Id;
            entity.UpdateDate = DateTime.Now;

            return new Result(true, entity);
        }

        public virtual async Task<Result> Delete(BasePostParams postParams)
        {
            var userResult = await _AutificationService.GetCurrentUser();
            var entity = postParams.Entity as IEntity;

            if (userResult == null || entity == null)
                return new Result(false, null, "Не найден пользователь или не удалось сконвертировать сущность");

            var user = userResult.Data as AppUser;

            entity.DeletedUserId = user.Id;
            entity.DeleteDate = DateTime.Now;

            return new Result(true, entity);
        }

    }
}