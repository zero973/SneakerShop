namespace SneakerShop.Core.Models.Web
{
    /// <summary>
    /// Результат операции/действия
    /// </summary>
    public class Result
    {

        /// <summary>
        /// Состояние результата
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// Данные
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string? Message { get; set; }

        public Result() { }

        /// <summary>
        /// Конструктор для ошибок
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public Result(string message)
        {
            IsSuccess = false;
            Message = message;
        }

        /// <summary>
        /// Конструктор при успешной отработке операции
        /// </summary>
        /// <param name="isSuccess">Предполагается, что = true</param>
        /// <param name="data">Данные</param>
        /// <param name="message">Сообщение об успешном выполнении</param>
        public Result(bool isSuccess, dynamic data, string? message = null)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
        }

    }
}