namespace SneakerShop.DataAdapters.Map
{
    /// <summary>
    /// Параметры мапинга
    /// </summary>
    public class MapParams
    {

        /// <summary>
        /// Тип 1
        /// </summary>
        public Type SourceType { get; set; }

        /// <summary>
        /// Тип 2
        /// </summary>
        public Type DestinationType { get; set; }

        /// <summary>
        /// Является ли мапинг двусторонним
        /// </summary>
        public bool IsMutual { get; set; }

        public MapParams(Type sourceType, Type destinationType, bool isMutual = false)
        {
            SourceType = sourceType;
            DestinationType = destinationType;
            IsMutual = isMutual;

            if (sourceType == destinationType)
                throw new ArgumentException($"Добавлены два одинаковых объекта в мапинг ! ({sourceType.Name}, {destinationType.Name})");
        }

        /// <summary>
        /// Вернуть этот объект, но с переставленными местами <see cref="SourceType"/> и <see cref="DestinationType"/>
        /// </summary>
        public MapParams SwapTypes()
        {
            if (IsMutual)
                return new MapParams(DestinationType, SourceType, true);
            throw new InvalidOperationException($"Невозможно свапнуть типы объектов, т.к. объект не {nameof(IsMutual)}.");
        }

        public override string ToString()
        {
            return $"Source: {SourceType.Name}, Destination: {DestinationType.Name}, IsMutual: {IsMutual}";
        }

        public override bool Equals(object? obj)
        {
            var prms = obj as MapParams;
            if (prms == null) 
                return false;

            if (prms.SourceType == SourceType && prms.DestinationType == DestinationType)
                return true;

            if (prms.IsMutual && prms.SourceType == DestinationType && prms.DestinationType == SourceType)
                return true;

            return false;
        }

    }
}