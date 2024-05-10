namespace SneakerShop.DAL.Models.Entities
{
	/// <summary>
	/// Товар
	/// </summary>
	public class Good : BaseEntity
	{

        public Guid GoodSubtypeId { get; set; }

        public GoodSubtype _GoodSubtype { get; set; }

        public Guid ManufacturerId { get; set; }

        public Manufacturer _Manufacturer { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public ICollection<OrderedGood> OrderedGoods { get; set; }

        public ICollection<BasketElement> BasketElements { get; set; }

        public ICollection<Discount> Discounts { get; set; }

        public Good()
		{

		}

        public Good(Guid goodSubtypeId, Guid manufacturerId, string name, decimal price, string description, string imageURL)
        {
            GoodSubtypeId = goodSubtypeId;
            ManufacturerId = manufacturerId;
            Name = name;
            Price = price;
            Description = description;
            ImageURL = imageURL;
        }

        public override string ToString()
		{
			return $"Id: {Id}, GoodSubtypeId: {GoodSubtypeId}, ManufacturerId: {ManufacturerId}, Name: {Name}, Price: {Price}, Description: {Description}, ImageURL: {ImageURL}";
		}

	}
}