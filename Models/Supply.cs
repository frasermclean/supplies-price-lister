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

    public abstract class Supply : ISupply
    {
        public string Id { get; }
        public string Description { get; }
        public virtual float Price { get; }
        public string UnitOfMeasurement { get; }
    }
}
