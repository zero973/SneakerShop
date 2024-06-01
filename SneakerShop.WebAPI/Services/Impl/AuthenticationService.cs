using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SneakerShop.Core.ApplicationContext;
using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Models.Web.Auth;
using SneakerShop.Core.Services.Users;

namespace SneakerShop.WebAPI.Services.Impl
{
    /// <summary>
    /// Сервис для работы с аутентификацией пользователей
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {

        private readonly SignInManager<DAL.Models.Entities.AppUser> _signInManager;

        private readonly UserManager<DAL.Models.Entities.AppUser> _userManager;

        private readonly IMapper _mapper;

        public AuthenticationService(SignInManager<DAL.Models.Entities.AppUser> signInManager, 
            UserManager<DAL.Models.Entities.AppUser> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Result<AppUser>> GetCurrentUser()
        {
            if (_signInManager.Context.User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(_signInManager.Context.User.Identity.Name);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    user.Roles = roles;
                    return new Result<AppUser>(true, _mapper.Map<AppUser>(user));
                }
            }
            return new Result<AppUser>(false, null, "Пользователь не найден !");
        }

        public async Task<Result<AppUser>> LogIn(LoginModel loginData)
        {
            var result = await _signInManager.PasswordSignInAsync(loginData.Login, loginData.Password, true, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginData.Login);
                return new Result<AppUser>(true, _mapper.Map<AppUser>(user));
            }
            return new Result<AppUser>(false, null, "Пользователь не найден !");
        }

        public async Task<Result<AppUser>> SignUp(RegistrationModel registrationData)
        {
            var user = await _userManager.FindByNameAsync(registrationData.Login);
            if (user != null)
                return new Result<AppUser>(false, null, "Пользователь с таким логином уже существует !");

            user = new DAL.Models.Entities.AppUser() 
            { 
                UserName = registrationData.Login,
                Email = registrationData.Email,
                FirstName = registrationData.FirstName,
                LastName = registrationData.LastName
            };

            var createUserResult = await _userManager.CreateAsync(user, registrationData.Password);

            if (createUserResult.Succeeded)
            {
                var addToRoleResult = await _userManager.AddToRoleAsync(user, Constants.CustomerUserRoleName);

                if (!addToRoleResult.Succeeded)
                    return new Result<AppUser>(false, null, 
                        $"Не удалось добавить роль пользователю. {string.Join(Environment.NewLine, addToRoleResult.Errors)}");

                await _signInManager.SignInAsync(user, true);
                return new Result<AppUser>(true, _mapper.Map<AppUser>(user));
            }

            return new Result<AppUser>(false, null, $"Регистрация не удалась. {string.Join(Environment.NewLine, createUserResult.Errors)}");
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

    }
}