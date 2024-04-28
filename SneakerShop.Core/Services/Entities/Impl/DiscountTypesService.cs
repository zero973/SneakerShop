using AutoMapper;
using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Services.Auth;
using SneakerShop.Core.Services.Impl;
using SneakerShop.DataAdapters.Contracts.Repositories.Intf;

namespace SneakerShop.Core.Services.Entities.Impl
{
    public class DiscountTypesService : BaseEntityService<DiscountType, DataAdapters.Contracts.Models.Entities.DiscountType>, IDiscountTypesService
    {

        public DiscountTypesService(IDbEntitiesRepository dbRepository, IAutificationService autificationService, IMapper mapper)
            : base(dbRepository, autificationService, mapper)
        {

        }

    }
}