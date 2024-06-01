using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Repositories.Intf;
using SneakerShop.Core.Services.Users;

namespace SneakerShop.Core.Services.Impl
{
    public class BasketService : BaseEntityService<BasketElement>, IBasketService
    {

        public BasketService(IDbEntitiesRepository<BasketElement> dbRepository, IAuthenticationService authenticationService) 
            : base(dbRepository, authenticationService)
        {

        }

    }
}