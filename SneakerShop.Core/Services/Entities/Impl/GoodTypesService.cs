﻿using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Repositories.Intf;
using SneakerShop.Core.Services.Impl;
using SneakerShop.Core.Services.Users;

namespace SneakerShop.Core.Services.Entities.Impl
{
    public class GoodTypesService : BaseEntityService<GoodType>, IGoodTypesService
    {
        public GoodTypesService(IDbEntitiesRepository<GoodType> dbRepository, IAuthenticationService authenticationService) 
            : base(dbRepository, authenticationService)
        {

        }
    }
}