namespace SneakerShop.Core.Models.Entities
{
    /// <summary>
    /// Подтип товара (футболка, майка, кеды, кроссовки, рюкзаки, толстовки)
    /// </summary>
    public class GoodSubtype : BaseEntity
    {

        public string Name { get; set; }

        public Guid GoodTypeId { get; set; }

        public GoodType GoodType { get; set; }

        public ICollection<Size> Sizes { get; set; }

        public GoodSubtype()
        {
            
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, GoodType: {GoodType.Name}";
        }

    }
}