namespace SuppliesPriceLister.Models
{
    public interface ISupply
    {
        /// <summary>
        /// Unique identifier of supply.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Descriptive name of the supply.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Price in AUD
        /// </summary>
        public float Price { get; }

        /// <summary>
        /// Unit of measurement for the supply.
        /// </summary>
        public string UnitOfMeasurement { get; }
    }
}
