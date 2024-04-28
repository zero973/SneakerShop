using SneakerShop.Core.Models.Auth;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Models.Web.Auth;

namespace SneakerShop.Core.Services.Users
{
    /// <summary>
    /// Сервис для работы с пользователями и их аутификацией
    /// </summary>
    public interface IAutificationService
    {

        /// <summary>
        /// Получить текущего пользователя (<see cref="AppUser"/>)
        /// </summary>
        Task<Result> GetCurrentUser();

        /// <summary>
        /// Вход
        /// </summary>
        /// <returns>Возвращает пользователя (<see cref="AppUser"/>)</returns>
        Task<Result> LogIn(LoginModel loginData);

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <returns>Возвращает нового пользователя (<see cref="AppUser"/>)</returns>
        Task<Result> SignUp(RegistrationModel registrationData);

        /// <summary>
        /// Выход
        /// </summary>
        Task SignOut();

        /// <summary>
        /// 
        /// </summary>
        Task<Result> AddNewUser(AppUser user);

        /// <summary>
        /// 
        /// </summary>
        Task<Result> UpdateUser(AppUser user);

        /// <summary>
        /// 
        /// </summary>
        Task<Result> RemoveUser(AppUser user);

    }
}