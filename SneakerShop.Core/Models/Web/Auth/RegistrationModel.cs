namespace SneakerShop.Core.Models.Web.Auth
{
    /// <summary>
    /// Данные для регистрации
    /// </summary>
    public class RegistrationModel : LoginModel
    {

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Е-маил
        /// </summary>
        public string Email { get; set; }

    }
}