namespace SneakerShop.Core.Models.Entities
{
	/// <summary>
	/// Производитель
	/// </summary>
	public class Manufacturer : BaseEntity
	{

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Manufacturer()
		{
			
		}

		public Manufacturer(string name, string description, string imageUrl)
		{
			Name = name;
			Description = description;
			ImageUrl = imageUrl;
		}

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}, Description: {Description}";
		}

	}
}