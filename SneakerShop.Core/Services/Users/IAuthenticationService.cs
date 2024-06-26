﻿using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Models.Web;
using SneakerShop.Core.Models.Web.Auth;

namespace SneakerShop.Core.Services.Users
{
    /// <summary>
    /// Сервис для работы с пользователями и их аутификацией
    /// </summary>
    public interface IAuthenticationService
    {

        /// <summary>
        /// Получить текущего пользователя (<see cref="AppUser"/>)
        /// </summary>
        Task<Result<AppUser>> GetCurrentUser();

        /// <summary>
        /// Вход
        /// </summary>
        /// <returns>Возвращает пользователя (<see cref="AppUser"/>)</returns>
        Task<Result<AppUser>> LogIn(LoginModel loginData);

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <returns>Возвращает нового пользователя (<see cref="AppUser"/>)</returns>
        Task<Result<AppUser>> SignUp(RegistrationModel registrationData);

        /// <summary>
        /// Выход
        /// </summary>
        Task SignOut();

    }
}