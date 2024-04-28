using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Repositories.Intf;
using SneakerShop.Core.Services.Impl;
using SneakerShop.Core.Services.Users;

namespace SneakerShop.Core.Services.Entities.Impl
{
    public class DiscountsService : BaseEntityService<DiscountType>, IDiscountsService
    {
        public DiscountsService(IDbEntitiesRepository<DiscountType> dbRepository, IAutificationService autificationService) 
            : base(dbRepository, autificationService)
        {

        }
    }
}