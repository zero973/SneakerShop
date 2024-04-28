namespace SneakerShop.Core.Models.Entities
{
	/// <summary>
	/// Дейсвующая скидка на определённом товаре
	/// </summary>
	public class Discount : BaseEntity
    {

        public Good Good { get; set; }

        public DiscountType _DiscountType { get; set; }

        /// <summary>
        /// Дата начала действия скидки
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата начала окончания скидки
        /// </summary>
        public DateTime EndDate { get; set; }

        public Discount()
		{

		}

        public override string ToString()
		{
			return $"Id: {Id}, Good: {Good.Name}, DiscountType: {_DiscountType.Name}, StartDate: {StartDate.ToShortDateString()}, EndDate: {EndDate.ToShortDateString()}";
		}

	}
}