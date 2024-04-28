namespace SneakerShop.DataAdapters.Models.Entities
{
    /// <summary>
    /// Подтип товара (футболка, майка, кеды, кроссовки, рюкзаки, толстовки)
    /// </summary>
    public class GoodSubtype : BaseEntity
    {

        public string Name { get; set; }

        public Guid GoodTypeId { get; set; }

        public GoodType? GoodType { get; set; }

        public ICollection<Good> Goods { get; set; }

        public ICollection<Size> Sizes { get; set; }

        public GoodSubtype()
        {
            
        }

        public GoodSubtype(string name, Guid goodTypeId)
        {
            Name = name;
            GoodTypeId = goodTypeId;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, GoodTypeId: {GoodTypeId}";
        }

    }
}