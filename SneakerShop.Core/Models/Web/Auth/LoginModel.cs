namespace SneakerShop.Core.Models.Web.Auth
{
    /// <summary>
    /// Данные для входа
    /// </summary>
    public class LoginModel
    {

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

    }
}