using AutoMapper;
using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Services.Auth;
using SneakerShop.Core.Services.Impl;
using SneakerShop.DataAdapters.Contracts.Repositories.Intf;

namespace SneakerShop.Core.Services.Entities.Impl
{
    public class GoodTypesService : BaseEntityService<GoodType, DataAdapters.Contracts.Models.Entities.GoodType>, IGoodTypesService
    {

        public GoodTypesService(IDbEntitiesRepository dbRepository, IAutificationService autificationService, IMapper mapper)
            : base(dbRepository, autificationService, mapper)
        {

        }

    }
}