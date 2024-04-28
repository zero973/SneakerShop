using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Repositories.Intf;
using SneakerShop.Core.Services.Impl;
using SneakerShop.Core.Services.Users;

namespace SneakerShop.Core.Services.Entities.Impl
{
    public class GoodSubtypesService : BaseEntityService<GoodSubtype>, IGoodSubtypesService
    {
        public GoodSubtypesService(IDbEntitiesRepository<GoodSubtype> dbRepository, IAutificationService autificationService) 
            : base(dbRepository, autificationService)
        {

        }
    }
}