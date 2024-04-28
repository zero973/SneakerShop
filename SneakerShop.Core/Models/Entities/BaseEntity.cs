using SneakerShop.Core.Models.Entities.Intf;

namespace SneakerShop.Core.Models.Entities
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public abstract class BaseEntity : IEntity
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsActual { get; set; } = true;

        public Guid? CreatedUserId { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public Guid? UpdatedUserId { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Guid? DeletedUserId { get; set; }

        public DateTime? DeleteDate { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} IsActual: {IsActual}";
        }

        public override bool Equals(object? obj)
        {
            var other = obj as BaseEntity;
            return Id == other?.Id;
        }
    }
}