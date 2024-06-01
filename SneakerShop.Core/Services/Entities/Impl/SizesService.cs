using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Repositories.Intf;
using SneakerShop.Core.Services.Impl;
using SneakerShop.Core.Services.Users;

namespace SneakerShop.Core.Services.Entities.Impl
{
    public class SizesService : BaseEntityService<Size>, ISizesService
    {
        public SizesService(IDbEntitiesRepository<Size> dbRepository, IAuthenticationService authenticationService) 
            : base(dbRepository, authenticationService)
        {

        }
    }
}