using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Repositories.Intf;
using SneakerShop.Core.Services.Impl;
using SneakerShop.Core.Services.Users;

namespace SneakerShop.Core.Services.Entities.Impl
{
    public class DiscountTypesService : BaseEntityService<DiscountType>, IDiscountTypesService
    {
        public DiscountTypesService(IDbEntitiesRepository<DiscountType> dbRepository, IAuthenticationService authenticationService) 
            : base(dbRepository, authenticationService)
        {

        }
    }
}