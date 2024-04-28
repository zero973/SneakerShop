using AutoMapper;
using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Services.Auth;
using SneakerShop.DataAdapters.Contracts.Repositories.Intf;

namespace SneakerShop.Core.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class BasketService : BaseEntityService<BasketElement, DataAdapters.Contracts.Models.Entities.BasketElement>, IBasketService
    {

        public BasketService(IDbEntitiesRepository dbRepository, IAutificationService autificationService, IMapper mapper) 
            : base(dbRepository, autificationService, mapper)
        {
            
        }

    }
}