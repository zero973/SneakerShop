﻿namespace SneakerShop.Core.Models.Entities
{
	/// <summary>
	/// Действующая скидка на определённом товаре
	/// </summary>
	public class Discount : BaseEntity
    {

        public Guid GoodId { get; set; }

        public Good Good { get; set; }

        public Guid DiscountTypeId { get; set; }

        public DiscountType DiscountType { get; set; }

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
			return $"Id: {Id}, Good: {Good.Name}, DiscountType: {DiscountType.Name}, StartDate: {StartDate.ToShortDateString()}, EndDate: {EndDate.ToShortDateString()}";
		}

	}
}