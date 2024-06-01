namespace SneakerShop.Core.Models.Entities
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

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Discount> Discounts { get; set; }

        public Good()
		{

		}

        public override string ToString()
		{
			return $"Id: {Id}, GoodSubtype: {GoodSubtype.Name}, Manufacturer: {Manufacturer.Name}, Name: {Name}, Price: {Price}, Description: {Description}, ImageURL: {ImageUrl}";
		}

	}
}