using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Services.Auth;
using SneakerShop.Core.Services.Entities;
using SneakerShop.DataAdapters.Contracts.Repositories.Intf;

namespace SneakerShop.Core.Services.Impl
{
    public class GoodsService : BaseEntityService<Good, DataAdapters.Contracts.Models.Entities.Good>, IGoodsService
    {

        public GoodsService(IDbEntitiesRepository dbRepository, IAutificationService autificationService, IMapper mapper)
            : base(dbRepository, autificationService, mapper)
        {

        }

        public async Task<Result> GetGoodsWithAnyDiscount(BaseListParams baseParams)
        {
            var goods = GetActualEntities(baseParams)
                .Where(x => x.Discounts.Any())
                .WithFilter(baseParams);

            return new Result(true, await goods.ToListAsync());
        }

    }
}