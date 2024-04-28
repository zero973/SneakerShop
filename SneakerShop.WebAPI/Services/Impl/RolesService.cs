using Microsoft.AspNetCore.Identity;

namespace SneakerShop.Core.Services.Users.Impl
{
    public class RolesService : IRolesService
    {

        private readonly RoleManager<IdentityUserRole<Guid>> _RoleManager;

        public RolesService()
        {
            
        }



    }
}