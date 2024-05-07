namespace SneakerShop.DataAdapters.Models.Entities
{
	/// <summary>
	/// Производитель
	/// </summary>
	public class Manufacturer : BaseEntity
	{

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public ICollection<Good> Goods { get; set; }

        public Manufacturer()
        {
        }

        public Manufacturer(string name, string description, string imageURL)
		{
			Name = name;
			Description = description;
            ImageURL = imageURL;
        }

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}, Description: {Description}, ImageURL: {ImageURL}";
		}

	}
}