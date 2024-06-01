using System.ComponentModel.DataAnnotations;

namespace SneakerShop.DAL.Models.Entities
{
	/// <summary>
	/// Товар
	/// </summary>
	public class Good : BaseEntity
	{

        public Guid GoodSubtypeId { get; set; }

        public GoodSubtype GoodSubtype { get; set; }

        public Guid ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(200)]
        public string ImageUrl { get; set; }

        public ICollection<OrderedGood> OrderedGoods { get; set; }

        public ICollection<BasketElement> BasketElements { get; set; }

        public ICollection<Discount> Discounts { get; set; }

        public Good()
		{

		}

        public Good(Guid goodSubtypeId, Guid manufacturerId, string name, decimal price, string description, string imageUrl)
        {
            GoodSubtypeId = goodSubtypeId;
            ManufacturerId = manufacturerId;
            Name = name;
            Price = price;
            Description = description;
            ImageUrl = imageUrl;
        }

        public override string ToString()
		{
			return $"Id: {Id}, GoodSubtypeId: {GoodSubtypeId}, ManufacturerId: {ManufacturerId}, Name: {Name}, Price: {Price}, Description: {Description}, ImageURL: {ImageUrl}";
		}

	}
}