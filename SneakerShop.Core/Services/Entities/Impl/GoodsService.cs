using Microsoft.EntityFrameworkCore;
using SneakerShop.Core.Extensions;
using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Repositories.Intf;
using SneakerShop.Core.Services.Entities;
using SneakerShop.Core.Services.Users;

namespace SneakerShop.Core.Services.Impl
{
    public class GoodsService : BaseEntityService<Good>, IGoodsService
    {

        private readonly IDbEntitiesRepository<Good> DbRepository;

        public GoodsService(IDbEntitiesRepository<Good> dbRepository, IAutificationService autificationService) 
            : base(dbRepository, autificationService)
        {
            DbRepository = dbRepository;
        }

        public async Task<Result<List<Good>>> GetGoodsWithAnyDiscount(BaseListParams baseParams)
        {
            var result = DbRepository.GetAll(baseParams.Filters)
                .Where(x => x.Discounts.Any())
                .WithOrdering(baseParams)
                .WithPagination(baseParams);

            return new Result<List<Good>>(true, await result.ToListAsync());
        }

    }
}