using SneakerShop.Core.Enums.Web;

namespace SneakerShop.Core.Models.Web
{
    /// <summary>
    /// Фильтр данных
    /// </summary>
    public class ComplexFilter
    {

        /// <summary>
        /// Анализируемое поле
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Операция
        /// </summary>
        public ComplexFilterOperators Operator { get; set; }

        /// <summary>
        /// Сравниваемое значение
        /// </summary>
        public object Value { get; set; }

        public override string ToString()
        {
            return $"Field: {Field}, Operator: {Operator}, Value: {Value}";
        }

    }
}