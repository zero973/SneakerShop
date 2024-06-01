using System.ComponentModel.DataAnnotations;

namespace SneakerShop.DAL.Models.Entities
{
	/// <summary>
	/// Производитель
	/// </summary>
	public class Manufacturer : BaseEntity
	{

		[MaxLength(200)]
        public string Name { get; set; }

		[MaxLength(200)]
        public string Description { get; set; }

		[MaxLength(200)]
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