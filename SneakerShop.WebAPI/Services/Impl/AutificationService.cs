using Microsoft.AspNetCore.Identity;
using SneakerShop.Core.Models.Auth;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Models.Web.Auth;
using SneakerShop.Core.Services.Users;

namespace SneakerShop.WebAPI.Services.Impl
{
    /// <summary>
    /// Сервис для работы с пользователями и их аутификацией
    /// </summary>
    public class AutificationService : IAutificationService
    {

        private readonly SignInManager<AppUser> _SignInManager;

        private readonly UserManager<AppUser> _UserManager;

        private readonly RoleManager<IdentityUserRole<Guid>> _RoleManager;

        public AutificationService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, 
            RoleManager<IdentityUserRole<Guid>> roleManager)
        {
            _SignInManager = signInManager;
            _UserManager = userManager;
            _RoleManager = roleManager;
        }

        #region Аутентификация пользователей

        public async Task<Result> GetCurrentUser()
        {
            if (_SignInManager.Context.User.Identity.IsAuthenticated)
            {
                var user = await _UserManager.FindByNameAsync(_SignInManager.Context.User.Identity.Name);
                if (user != null)
                {
                    var role = await _UserManager.GetRolesAsync(user).;
                    return new Result(true, user);
                }
            }
            return new Result(false, null, "Пользователь не найден !");
        }

        public async Task<Result> LogIn(LoginModel loginData)
        {
            var result = await _SignInManager.PasswordSignInAsync(loginData.Login, loginData.Password, true, false);
            if (result.Succeeded)
            {
                var user = await _UserManager.FindByNameAsync(loginData.Login);
                return new Result(true, user);
            }
            return new Result(false, null, "Пользователь не найден !");
        }

        public async Task<Result> SignUp(RegistrationModel registrationData)
        {
            var user = await _UserManager.FindByNameAsync(registrationData.Login);
            if (user != null)
                return new Result(false, null, "Пользователь с таким логином уже существует !");
            user = new AppUser() 
            { 
                UserName = registrationData.Login,
                Email = registrationData.Email,
                FirstName = registrationData.FirstName,
                LastName = registrationData.LastName
            };
            var result = await _UserManager.CreateAsync(user, registrationData.Password);
            if (result.Succeeded)
            {
                await _SignInManager.SignInAsync(user, true);
                return new Result(true, user);
            }
            return new Result(false, null, $"Регистрация не удалась. {string.Join(Environment.NewLine, result.Errors)}");
        }

        public async Task SignOut()
        {
            await _SignInManager.SignOutAsync();
        }

        #endregion

        #region Непосредственная работа с сущностями

        public async Task<Result> AddNewUser(AppUser user)
        {
            return null;
        }

        public async Task<Result> UpdateUser(AppUser user)
        {
            return null;
        }

        public async Task<Result> RemoveUser(AppUser user)
        {
            return null;
        }

        #endregion

        private async Task<AppUser?> GetUserByLoginAndPassword(LoginModel loginData)
        {
            var user = await _UserManager.FindByNameAsync(loginData.Login);
            if (user != null)
            {
                if (user.PasswordHash == "")
                    return user;
            }
            return null;
        }

        private string GetPasswordHash(string password)
        {
            var hasher = new PasswordHasher<AppUser>();
            return hasher.HashPassword(null, password);
        }

    }
}