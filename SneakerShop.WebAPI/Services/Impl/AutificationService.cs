using Microsoft.AspNetCore.Identity;
using SneakerShop.Core.ApplicationContext;
using SneakerShop.Core.Models.Entities;
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

        public AutificationService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _SignInManager = signInManager;
            _UserManager = userManager;
        }

        public async Task<Result> GetCurrentUser()
        {
            if (_SignInManager.Context.User.Identity.IsAuthenticated)
            {
                var user = await _UserManager.FindByNameAsync(_SignInManager.Context.User.Identity.Name);
                if (user != null)
                {
                    var roleResult = await _UserManager.GetRolesAsync(user);
                    var role = roleResult.First();
                    return new Result(true, role);
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

            var createUserResult = await _UserManager.CreateAsync(user, registrationData.Password);

            if (createUserResult.Succeeded)
            {
                var addToRoleResult = await _UserManager.AddToRoleAsync(user, Constants.CustomerUserRoleName);

                if (addToRoleResult.Succeeded)
                    return new Result(false, null, $"Не удалось добавить роль пользователю. {string.Join(Environment.NewLine, addToRoleResult.Errors)}");

                await _SignInManager.SignInAsync(user, true);
                return new Result(true, user);
            }

            return new Result(false, null, $"Регистрация не удалась. {string.Join(Environment.NewLine, createUserResult.Errors)}");
        }

        public async Task SignOut()
        {
            await _SignInManager.SignOutAsync();
        }

    }
}